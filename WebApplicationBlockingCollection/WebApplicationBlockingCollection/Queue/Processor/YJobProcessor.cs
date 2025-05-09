using WebApplicationBlockingCollection.Queue.Base;

namespace WebApplicationBlockingCollection.Queue.Processor
{
    public class YJobProcessor : IJobProcessor<long>
    {
        public YJobProcessor()
        {
        }
        public async Task ProcessAsync(long job)
        {
            Console.WriteLine($"Y işi işledi : {job}");
            await Task.Delay(5000); // Simülasyon
        }
    }

}
