using System.Collections.Concurrent;

namespace WebApplicationBlockingCollection.Queue.Base
{
    public abstract class JobQueue<T> : IJobQueue<T>
    {
        private BlockingCollection<T> _queue;

        protected JobQueue(int queueCapacity = 10)
        {
            _queue = new BlockingCollection<T>(queueCapacity);
        }

        public void Enqueue(T item) => _queue.Add(item);

        public bool TryDequeue(out T item) => _queue.TryTake(out item);

        public IEnumerable<T> Snapshot() => _queue.ToArray();
    }
}
