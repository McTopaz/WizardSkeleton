using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using Wizard.Misc;
using Wizard.Views.Pages;

namespace Wizard
{
    class Page : IPage, IDisposable
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

        public virtual void Opening()
        {
        }

        public virtual void Closing()
        {
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Page()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
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
