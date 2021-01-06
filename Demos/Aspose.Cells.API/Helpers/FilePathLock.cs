using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Aspose.Cells.API.Helpers
{
    internal sealed class FilePathLock
    {
        private static readonly FilePathLock filePathLock = new FilePathLock();

        public static IDisposable Use(string path)
        {
            var lockWasTaken = false;
            var lockObj = filePathLock[path];
            Monitor.Enter(lockObj, ref lockWasTaken);

            return new Disposable(() =>
            {
                if (lockWasTaken)
                    Monitor.Exit(lockObj);
            });
        }

        private readonly ConcurrentDictionary<string, object> locks = new ConcurrentDictionary<string, object>();
        public object this[string path] => locks.GetOrAdd(path, p => new object());

        private class Disposable : IDisposable
        {
            private readonly Action dispose;

            public void Dispose() => dispose();

            public Disposable(Action dispose)
            {
                this.dispose = dispose;
            }
        }
    }
}