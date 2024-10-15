
using System.Collections.Concurrent;

namespace ConsoleApp1;

internal class Program
{

    static ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();
    static void Main(string[] args)
    {
        _queue.Enqueue(1);
        _queue.Enqueue(2);
        _queue.Enqueue(3);

        var t = new Thread(Poller);
        t.Start();
        Console.WriteLine("Press a key to quit!");
        Console.ReadKey();
    }

    private static void Poller(object? obj)
    {
        while (_queue.TryDequeue(out var result))
        {
            // this is the work around, clears all thread errors before continue
            //var x = new VbClassLibrary1.Class1();
            //x.ClearErrors();

            try
            {
                ProcessItem(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error processing item {result}:");
                Console.WriteLine(e.ToString());
            }

        }
    }

    private static void ProcessItem(int result)
    {

        var x = new VbClassLibrary1.Class1();
        x.Log(result);
        switch (result)
        {
            case 1:
                break;
            case 2:
                var y = new VbClassLibrary1.Class1();
                y.vbtrycatch();
                break;
            case 3:
                break;
        }

    }
}