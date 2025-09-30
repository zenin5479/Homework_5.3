using System;
using System.IO;
using System.Text;

namespace Homework_4._8
{
   public class MethodsForArray
   {
      public static int SizeRow()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива:");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn()
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива:");
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static int MultipleElement()
      {
         int multiple;
         do
         {
            Console.WriteLine("Введите величину:");
            int.TryParse(Console.ReadLine(), out multiple);
            //multiple = Convert.ToInt32(Console.ReadLine());
            if (multiple <= 0 || multiple > 99)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (multiple <= 0 || multiple > 99);

         return multiple;
      }

      public static int[,] EnterArrayInt(string path, string nameFile)
      {
         // Двумерный целочисленный массив 
         int[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в int
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new int[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter != line[countCharacter])
                     {
                        stringModified.Append(line[countCharacter]);
                     }
                     else
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToInt32(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToInt32(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static int[,] InputArrayInt(int[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный целочисленный массив:");
         int[,] outputArray = new int[n, m];
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               outputArray[i, j] = inputArray[i, j];
               Console.Write("{0} ", outputArray[i, j]);
            }

            Console.WriteLine();
         }

         return outputArray;
      }

      public static void SplittingLines(int[,] input, int multiple, string nameFile)
      {
         int counterMultiple = 0;
         int[] lines = new int[input.GetLength(1)];
         int i = 0;
         while (i < input.GetLength(0))
         {
            int j = 0;
            while (j < input.GetLength(1))
            {
               lines[j] = input[i, j];
               j++;
            }

            if (SearchingMultiple(lines, multiple))
            {
               string lineFound = "В массиве найдена строка " + (i + 1) + " с элементом, кратным " + multiple;
               Console.WriteLine(lineFound);
               FileAppendStringArray(lineFound, nameFile);
               counterMultiple++;
            }

            Array.Clear(lines, 0, lines.Length);
            i++;
         }

         if (counterMultiple == 0)
         {
            string lineNotFound = "В массиве не найдено строк с элементом, кратным " + multiple;
            Console.WriteLine(lineNotFound);
            FileAppendStringArray(lineNotFound, nameFile);
         }
      }

      public static bool SearchingMultiple(int[] lines, int multiple)
      {
         int i = 0;
         while (i < lines.Length)
         {
            if (lines[i] % multiple == 0)
            {
               return true;
            }

            i++;
         }

         return false;
      }

      public static void FileAppendStringArray(string line, string nameFile)
      {
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Добавление массива строк в файл
         string filePath = AppContext.BaseDirectory + nameFile;
         File.AppendAllLines(filePath, stringArray);
      }
   }
}