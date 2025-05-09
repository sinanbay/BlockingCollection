namespace WebApplicationBlockingCollection.Queue.Base
{
    public interface IJobQueue<T>
    {
        void Enqueue(T item);
        bool TryDequeue(out T item);
        IEnumerable<T> Snapshot();
    }
}
