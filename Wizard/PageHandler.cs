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
        static List<Page> Pages { get; set; } = new List<Page>();
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
        }

        private static void Back_Callback()
        {
            PageStack.Pop();
            Container.Page = PageStack.Peek();
        }

        private static void Next_Callback()
        {
            var vm = Container.Page.DataContext as Page;
            PageStack.Push(vm.Next);
            Container.Page = vm.Next;
        }

        private static void Exit_Callback()
        {
            DisposePages();
            Environment.Exit(0);
        }

        static void DisposePages()
        {
            foreach (var page in Pages)
            {
                page.Dispose();
            }
        }
    }
}
