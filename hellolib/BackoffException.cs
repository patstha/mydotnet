using System.Threading.Tasks;

namespace hellolib;

public class BackoffException
{
    public async Task BackoffSelfinflictedException(string name)
    {
        try
        {
            await Task.Run(() => { });
            throw new ApplicationException("just testing");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            int delay = 0;
            while (delay < 30000)
            {
                try
                {
                    await BackoffSelfinflictedException(name);
                }
                catch
                {
                    System.Threading.Thread.Sleep(delay);
                    delay += 1000;
                }
            }
        }
    }
}
