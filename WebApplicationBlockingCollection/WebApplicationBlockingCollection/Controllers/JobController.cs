using Microsoft.AspNetCore.Mvc;
using WebApplicationBlockingCollection.Queue.Base;
using WebApplicationBlockingCollection.Queue.JobQueue;
using WebApplicationBlockingCollection.Queue.Processor;

namespace WebApplicationBlockingCollection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IXJobQueue xJobQueue;
        private readonly IYJobQueue yJobQueue;
        private readonly IXJobProcessor<long> xJobProcessor;

        public JobController(
                               IXJobQueue xJobQueue,
                               IYJobQueue yJobQueue,
                               IXJobProcessor<long> xJobProcessor)
        {
            this.xJobQueue = xJobQueue;
            this.yJobQueue = yJobQueue;
            this.xJobProcessor = xJobProcessor;
        }

        [HttpGet("StartXWorkerJob")]
        public bool StartXWorkerJob()
        {
            Worker<long> xworker = new Worker<long>(xJobQueue, xJobProcessor);
            Worker<long> yworker = new Worker<long>(yJobQueue, new YJobProcessor());
            xworker.Start();

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    xJobQueue.Enqueue(i);
                }
            });

            return true;
        }

        [HttpGet("StartYWorkerJob")]
        public bool StartYWorkerJob()
        {
            Worker<long> yworker = new Worker<long>(yJobQueue, new YJobProcessor());
            yworker.Start();

            Task.Run(async () =>
            {
                for (int i = 10000; i < 20000; i++)
                {
                    yJobQueue.Enqueue(i);
                }
            });

            return true;
        }

        [HttpGet("GetXJobQueueItems")]
        public List<long> GetXJobQueueItems()
        {
            return xJobQueue.Snapshot().ToList();
        }

        [HttpGet("GetYJobQueueItems")]
        public List<long> GetYJobQueueItems()
        {
            return yJobQueue.Snapshot().ToList();
        }
    }
}
