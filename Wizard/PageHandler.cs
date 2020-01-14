using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using Wizard.Misc;
using Wizard.ViewModels;

namespace Wizard
{
    static class PageHandler
    {
        static Stack<UserControl> PageStack { get; set; } = new Stack<UserControl>();
        static vmMainWindow Container { get; set; }

        public static void SetDisplayingPage(vmMainWindow mainWindow)
        {
            PageStack.Push(mainWindow.Page);
            Container = mainWindow;
        }

        public static void SetNavigationCommands(RelayCommand back, RelayCommand next, RelayCommand exit)
        {
            back.Callback += Back_Callback;
            next.Callback += Next_Callback;
            exit.Callback += Exit_Callback;

            back.Enable = _ => EnableBack();
            next.Enable = _ => EnableNext();
        }

        private static bool EnableBack()
        {
            return PageStack.Count > 1;
        }

        private static bool EnableNext()
        {
            if (PageStack.Count == 0 || Container == null) return false;
            var vm = Container.Page.DataContext as Page;
            if (vm == null) return false;
            var isNoPage = vm.Next is Views.Pages.NoPage;
            return !isNoPage;
        }

        private static void Back_Callback()
        {
            if (PageStack.Count == 0) return;
            var page = PageStack.Pop();         // Remove current page.
            HidePage(page);                     // Hide current page.
        }

        private static void HidePage(UserControl page)
        {
            var vm = page.DataContext as Page;  // Get view model of current page.
            vm.Closing();                       // Page is closing when no longer displayed.
            var previous = PageStack.Peek();    // Previous page.
            ShowPage(PageStack.Peek());         // Show previous page.
        }

        private static void Next_Callback()
        {
            var vm = Container.Page.DataContext as Page;    // Current displayed page.

            // Check if "next page" happens to be a non existing page.
            // Then prevent from displaying the next page.
            if (vm.Next is Views.Pages.NoPage) return;

            vm.Closing();           // Close current displayed page.
            var next = vm.Next;     // Get next page.
            PageStack.Push(next);   // Store next page.
            ShowPage(next);         // Show next page.
        }

        private static void ShowPage(UserControl page)
        {
            var vm = page.DataContext as Page;  // Get view model of next page.
            vm.Opening();                       // Page is opeinging before it's displayed.
            Container.Page = page;              // Show next page.
        }

        private static void Exit_Callback()
        {
            DisposePages();
            Environment.Exit(0);
        }

        static void DisposePages()
        {
            foreach (var page in PageStack)
            {
                var vm = page.DataContext as Page;
                vm.Closing();
                vm.Dispose();
            }
        }
    }
}
