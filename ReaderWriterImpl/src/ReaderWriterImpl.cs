using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderWriterInActions.src
{
    public class ReaderWriterImpl
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private int data = 0;

        public int Read()
        {
            _lock.EnterReadLock();

            try
            {
                return data;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Write(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                this.data = value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
