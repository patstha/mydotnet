namespace hellolib;

public class BackoffException
{
    public async Task BackoffSelfinflictedException(string name, int stopAfter = 0, int currentIteration = 0)
    {
        try
        {
            await Task.Run(() => { throw new ApplicationException("just testing"); });

            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            int delay = 0;

            if (stopAfter > 0)
            {
                currentIteration++;
            }

            while (currentIteration < stopAfter || stopAfter == 0)
            {
                try
                {
                    await BackoffSelfinflictedException(name, stopAfter, currentIteration);
                    return;
                }
                catch
                {
                    await Task.Delay(delay);
                    delay += 1000;
                    if (stopAfter > 0)
                    {
                        currentIteration++;
                    }
                    if (stopAfter > 0 && currentIteration >= stopAfter)
                    {
                        break;
                    }
                }
            }
        }
    }
}
