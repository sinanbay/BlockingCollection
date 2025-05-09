using WebApplicationBlockingCollection.Queue.Base;

namespace WebApplicationBlockingCollection.Queue.JobQueue
{
    public class YJobQueue : JobQueue<long>, IYJobQueue
    {
        public YJobQueue(int queueCapacity = 10) : base(queueCapacity) { }
    }
}
