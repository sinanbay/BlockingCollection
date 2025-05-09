using WebApplicationBlockingCollection.Queue.Base;
using WebApplicationBlockingCollection.Queue.JobQueue;

namespace WebApplicationBlockingCollection.Queue.Processor
{
    public class XJobProcessor : IXJobProcessor<long>
    {
        private readonly IYJobQueue _nextXQueue;

        public XJobProcessor(IYJobQueue nextQueue)
        {
            _nextXQueue = nextQueue;
        }

        public async Task ProcessAsync(long job)
        {
            Console.WriteLine($"X işi işlendi: {job}");
            _nextXQueue.Enqueue(job); // Y işine aktar
            await Task.Delay(5000); // Simülasyon
        }
    }
}
