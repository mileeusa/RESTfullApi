using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInActions.model
{
    public sealed class AsyncReaderWriterLock
    {
        private readonly SemaphoreSlim _readerLock = new(1, 1);
        private readonly SemaphoreSlim _writerLock = new(1, 1);
        private int _readers = 0;

        public async Task<IDisposable> ReaderLockAsync()
        {
            await _readerLock.WaitAsync();
            try
            {
                if (++_readers == 1)
                    await _writerLock.WaitAsync();
            }
            finally
            {
                _readerLock.Release();
            }

            return new Releaser(() =>
            {
                _readerLock.Wait();
                try
                {
                    if (--_readers == 0)
                        _writerLock.Release();
                }
                finally
                {
                    _readerLock.Release();
                }
            });
        }

        public async Task<IDisposable> WriterLockAsync()
        {
            await _writerLock.WaitAsync();
            return new Releaser(() => _writerLock.Release());
        }

        private sealed class Releaser : IDisposable
        {
            private readonly Action _release;
            public Releaser(Action release) => _release = release;
            public void Dispose() => _release();
        }
    }
}
