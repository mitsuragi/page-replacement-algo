using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace page_replacement_algo.Algorithms
{
    public class LRU
    {
        public static int CountInterruptions(int[] appeals, List<int> pb, bool flag)
        {
            List<int> pageBlocks = new List<int>(pb);
            int counter = 0;

            if(flag)
            {
                for(int i = 0; i < appeals.Length; i++)
                {
                    if (pageBlocks.Contains(appeals[i]))
                    {
                        pageBlocks.RemoveAt(pageBlocks.IndexOf(appeals[i]));
                        pageBlocks.Add(appeals[i]);

                        Console.Write("Обращение к " + appeals[i] + ": Успешно\t");
                        Console.Write("\tСтраничные блоки: ");
                        displayPageBlocks();
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        Console.Write("Обращение к " + appeals[i]);
                        Console.Write(": Прерывание\t");
                        Console.Write("Было -> ");
                        displayPageBlocks();
                        pageBlocks.Add(appeals[i]);
                        pageBlocks.RemoveAt(0);
                        Console.Write("\tСтало -> ");
                        displayPageBlocks();
                        Console.WriteLine();
                        counter++;
                    }
                }
            }
            else
            {
                foreach (int i in appeals)
                {
                    if (pageBlocks.Contains(i))
                    {
                        pageBlocks.RemoveAt(pageBlocks.IndexOf(i));
                        pageBlocks.Add(i);

                        continue;
                    }
                    else
                    {
                        pageBlocks.Add(i);
                        pageBlocks.RemoveAt(0);
                        counter++;
                    }
                }

            }

            void displayPageBlocks()
            {
                foreach (int i in pageBlocks)
                {
                    Console.Write(i + " ");
                }
            }
            return counter;
        }
    }
}
