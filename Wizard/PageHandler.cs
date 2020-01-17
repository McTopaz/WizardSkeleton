﻿using System;
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
        static Stack<Page> PageStack { get; set; } = new Stack<Page>();
        static vmMainWindow Container { get; set; }
        public static Title Title { get; set; }

        public static void PageContainer(vmMainWindow mainWindow)
        {
            Container = mainWindow;
        }

        public static void SetStartPage(Page page)
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
            var current = PageStack.Peek();
            if (current == null) return false;
            var isNoPage = current.Next is NoPage;
            return !isNoPage;
        }

        private static void BackButton_Callback()
        {
            if (PageStack.Count == 0) return;
            var page = PageStack.Pop();         // Remove current page.
            HidePage(page);                     // Hide current page.
        }

        private static void HidePage(Page page)
        {
            page.Closing();
            var previous = PageStack.Peek();    // Previous page.
            ShowPage(previous);         // Show previous page.
        }

        private static void NextButton_Callback()
        {
            var current = PageStack.Peek();

            // Check if "next page" happens to be a non existing page.
            // Then prevent from displaying the next page.
            if (current is NoPage) return;

            current.Closing();           // Close current displayed page.

            var next = current.Next;
            PageStack.Push(next);   // Store next page.
            ShowPage(next);         // Show next page.
        }

        private static void ShowPage(Page page)
        {
            page.Opening();
            UpdateHeaderTitle(page.Title);
            Container.Page = page.Content;              // Show next page.
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
                page.Closing();
                page.Dispose();
            }
        }
    }
}
