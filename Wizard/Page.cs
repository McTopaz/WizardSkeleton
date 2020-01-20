using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using Wizard.Misc;
using Wizard.Views.Pages;

namespace Wizard
{
    class Page : IPage
    {
        public UserControl Content { get; set; }
        public Page Next { get; set; }
        public Title Title { get; private set; }
        public vmPageBase ViewModel { get; private set; }

        protected Page()
        {
            // This constructor overload is only for the NoPage derivied class.
        }

        public Page(UserControl content)
        {
            Content = content;
            ViewModel = Content.DataContext as vmPageBase;
            ViewModel.Container = this;
            Title = ViewModel.Title;
            Next = ViewModel.Next == null ? new NoPage() : new Page(ViewModel.Next);
        }

        /// <summary>
        /// The page is being opened.
        /// </summary>
        /// <param name="direction">The direction of where the application is going.</param>
        public void Opening(Direction direction)
        {
            ViewModel.Opening(direction);
        }

        /// <summary>
        /// The page is being closed.
        /// </summary>
        /// <param name="direction">The direction of where the application is going.</param>
        public void Closing(Direction direction)
        {
            ViewModel.Closing(direction);
        }

        public void Dispose()
        {
            ViewModel.Dispose();
        }
    }

    class NoPage : Page
    {
        public NoPage()
        {
        }
    }

    interface IPage
    {
        Page Next { get; set; }
    }
}
