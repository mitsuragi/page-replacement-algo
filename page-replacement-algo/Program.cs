using page_replacement_algo.Algorithms;

namespace page_replacement_algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] appeals = { 7, 8, 9, 2, 1, 0, 8, 9, 2, 4, 6, 8, 2, 1, 8, 9 };
            List<int> pageBlocks = new List<int> { 8, 2, 9, 6 };
            bool flag = false;
            bool quit = false;
            int input;

            Console.WriteLine("1 - Display Appeals\n" +
                              "2 - Display PageBlocks\n" +
                              "3 - Add Page Block\n" +
                              "4 - Remove Page Block\n" +
                              "5 - Switch Flag\n" +
                              "6 - FIFO Interruptions\n" +
                              "7 - LRU Interruptions\n" +
                              "0 - Quit\n" +
                              "Flag status - " + flag);

            while(!quit)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                switch(input)
                {
                    case 1:
                        Console.WriteLine("Appeals");
                        foreach(int i in appeals)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("PageBlocks");
                        foreach(int i in pageBlocks)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        pageBlocks.Insert(0, -1);
                        Console.WriteLine("Page Block Added");
                        break;

                    case 4:
                        if (pageBlocks.Count > 0)
                        {
                            pageBlocks.RemoveAt(0);
                            Console.WriteLine("Page Block Removed");
                        }
                        else
                        {
                            Console.WriteLine("PageBlocks is already clear");
                        }
                        break;

                    case 5:
                        if (flag) flag = false;
                        else flag = true;
                        Console.WriteLine("Flag Status: " + flag);
                        break;

                    case 6:
                        Console.WriteLine("FIFO Interruptions: " + FIFO.CountInterruptions(appeals, pageBlocks, flag));
                        break;

                    case 7:
                        Console.WriteLine("LRU Interruptions: " + LRU.CountInterruptions(appeals, pageBlocks, flag));
                        break;

                    case 0:
                        quit = true;
                        break;
                }
            }
            Console.WriteLine("Bye");
        }
    }
}
