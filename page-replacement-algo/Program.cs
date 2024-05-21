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

            while(!quit)
            {
                Console.WriteLine("1 - Показать обращения\n" +
                                  "2 - Показать страничные блоки\n" +
                                  "3 - Добавить страничный блок\n" +
                                  "4 - Удалить страничный блок\n" +
                                  "5 - Изменить режим отображения логов\n" +
                                  "6 - Прерывания при алгоритме FIFO\n" +
                                  "7 - Прерывания при алгоритме LRU\n" +
                                  "0 - Выход\n" +
                                  "Отображение логов - " + flag + '\n');

                Console.Write("Выберите пункт меню: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Обращения");
                        foreach(int i in appeals)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine('\n');
                        break;

                    case 2:
                        Console.WriteLine("Страничные блоки");
                        foreach(int i in pageBlocks)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine('\n');
                        break;

                    case 3:
                        pageBlocks.Insert(0, -1);
                        Console.WriteLine("Страничный блок добавлен\n");
                        break;

                    case 4:
                        if (pageBlocks.Count > 0)
                        {
                            pageBlocks.RemoveAt(0);
                            Console.WriteLine("Страничный блок удален\n");
                        }
                        else
                        {
                            Console.WriteLine("Страничные блоки отсутствуют\n");
                        }
                        break;

                    case 5:
                        if (flag) flag = false;
                        else flag = true;
                        Console.WriteLine("Отображение логов: " + flag + '\n');
                        break;

                    case 6:
                        Console.WriteLine("Количество прерываний: " + FIFO.CountInterruptions(appeals, pageBlocks, flag) + '\n');
                        break;

                    case 7:
                        Console.WriteLine("Количество прерываний: " + LRU.CountInterruptions(appeals, pageBlocks, flag) + '\n');
                        break;

                    case 0:
                        quit = true;
                        break;
                }
            }
            Console.WriteLine("Пока");
        }
    }
}
