using WebApplicationBlockingCollection.Queue.Base;

namespace WebApplicationBlockingCollection.Queue.JobQueue
{
    public class XJobQueue : JobQueue<long>, IXJobQueue
    {
        public XJobQueue(int queueCapacity = 10):base(queueCapacity) { }
        
    }
}
