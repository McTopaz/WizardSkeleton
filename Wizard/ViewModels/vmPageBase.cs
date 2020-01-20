using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using Wizard.Misc;
using Wizard.Views.Pages;

namespace Wizard
{
    abstract class vmPageBase : IDisposable
    {
        public Title Title { get; protected set; } = new Title();
        public UserControl Next { get; protected set; }
        public IPage Container { get; set; }

        /// <summary>
        /// The page is being opened.
        /// </summary>
        /// <param name="direction">The direction of where the application is going.</param>
        public virtual void Opening(Direction direction)
        {
        }

        /// <summary>
        /// The page is being closed.
        /// </summary>
        /// <param name="direction">The direction of where the application is going.</param>
        public virtual void Closing(Direction direction)
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
        // ~vmPageBase()
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
}
