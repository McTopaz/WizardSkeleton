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
        public static Title Title { get; set; }

        public static void PageContainer(vmMainWindow mainWindow)
        {
            Container = mainWindow;
        }

        public static void SetStartPage(UserControl page)
        {
            PageStack.Push(page);
            ShowPage(page);
        }

        public static void SetNavigationCommands(RelayCommand back, RelayCommand next, RelayCommand exit)
        {
            back.Callback += BackButton_Callback;
            next.Callback += NextButton_Callback;
            exit.Callback += ExitButton_Callback;

            back.Enable = _ => EnableBackButton();
            next.Enable = _ => EnableNextButton();
        }

        private static bool EnableBackButton()
        {
            return PageStack.Count > 1;
        }

        private static bool EnableNextButton()
        {
            if (PageStack.Count == 0 || Container == null) return false;
            var vm = Container.Page.DataContext as Page;
            if (vm == null) return false;
            var isNoPage = vm.Next is Views.Pages.NoPage;
            return !isNoPage;
        }

        private static void BackButton_Callback()
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

        private static void NextButton_Callback()
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
            UpdateHeaderTitle(vm.Title);
            Container.Page = page;              // Show next page.
        }

        private static void UpdateHeaderTitle(Title title)
        {
            Title.Text = title.Text;
            Title.Size = title.Size;
            Title.Color = title.Color;
        }

        private static void ExitButton_Callback()
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
