namespace WebApplicationBlockingCollection.Queue.Base
{
    public class Worker<T>
    {
        private readonly IJobQueue<T> _queue;
        private readonly IJobProcessor<T> _processor;
        private readonly int _workerCount;

        public Worker(IJobQueue<T> queue, IJobProcessor<T> processor, int workerCount = 2)
        {
            _queue = queue;
            _processor = processor;
            _workerCount = workerCount;
        }

        public void Start()
        {
            for (int i = 0; i < _workerCount; i++)
            {
                int workerId = i + 1;

                Task.Run(async () =>
                {
                    while (true)
                    {
                        if (_queue.TryDequeue(out var job))
                        {
                            await _processor.ProcessAsync(job);
                        }

                        await Task.Delay(100); // polling süresi
                    }
                });
            }
        }
    }
}
