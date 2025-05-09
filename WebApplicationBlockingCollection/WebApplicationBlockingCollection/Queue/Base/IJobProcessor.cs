namespace WebApplicationBlockingCollection.Queue.Base
{
    public interface IJobProcessor<T>
    {
        Task ProcessAsync(T job);
    }
}
