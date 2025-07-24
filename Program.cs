using System;

// Разработка программ с самостоятельным выделением подзадач
// Требуется выделить подзадачи, реализовать их решения подпрограммами, а затем собрать из них программу для решения всей задачи
// Данные должны передаваться через параметры подпрограмм, глобальные переменные использовать не следует
// Проанализировать особые случаи (возможное отсутствие искомых элементов, неоднозначность ответа) и предусмотреть их обработку в программе
// A – заданный двумерный массив
// Если не оговорено другое, то количество столбцов отличается от количества строк
// Изменить двумерный массив A так, чтобы на первом месте стояла строка с максимальной,
// а на последнем месте строка с минимальной суммой элементов, сохранив все элементы исходного массива

namespace Homework_5._3
{
   internal class Program
   {
      static void Main(string[] args)
      {
         int[,] mas = new int[5, 5];
         Random rnd = new Random();
         // заполняем массив случайными числами от 0 до 9
         for (int i = 0; i < 5; i++)
         {
            for (int j = 0; j < 5; j++)
            {

               mas[i, j] = rnd.Next(10);
               Console.Write(mas[i, j] + "\t");
            }
            Console.WriteLine();
         }
         // определяем строку с минимальным  и максимальным элементом
         int min = mas[1, 1];
         int max = mas[1, 1];
         int minstr = 0, maxstr = 0;
         // определяем минимальную строку
         for (int i = 1; i < 5; i++)
         {
            for (int j = 0; j < 5; j++)
            {
               if (mas[i, j] < min)
               {
                  min = mas[i, j];
                  minstr = i;
               }
            }
         }
         // определяем максимальную строку
         for (int i = 1; i < 5; i++)
         {
            for (int j = 0; j < 5; j++)
            {
               if (mas[i, j] > max)
               {
                  max = mas[i, j];
                  maxstr = i;
               }
            }
         }

         Console.WriteLine("Меняем местами строки {0} и {1} строку", minstr + 1, maxstr + 1);
         // перестановка строк
         int[] tempmas = new int[5];
         //Заносим минимальную строку во временный массив
         for (int i = minstr, j = 0, k = 0; j < 5; j++, k++)
         {
            tempmas[k] = mas[i, j];
         }
         //Заменяем минимальную строку максимальной
         for (int j = 0; j < 5; j++)
         {
            mas[minstr, j] = mas[maxstr, j];
         }
         //Заменяем максимальную строку минимальной
         for (int j = 0; j < 5; j++)
         {
            mas[maxstr, j] = tempmas[j];
         }

         // вывод измененного массива
         Console.WriteLine("------------------------");
         for (int i = 0; i < 5; i++)
         {
            for (int j = 0; j < 5; j++)
            {
               Console.Write(mas[i, j] + "\t");
            }
            Console.WriteLine();
         }

         Console.ReadKey();

         int[] array = { -93, -84, 84, 95, 93, 71, -36, -8, 37, -11, -3, -73, -31, -27, -14, -55, 1, 45, 81, 47 };
         int[] expected = { 55, -23, 35, -56, 90, 59, 72, -53, 63, 68, -71, 87, -9, -63, 24, -88, 24, 80, 41, 30 };

         int[] arrayOne = SortArray(array);
         foreach (int i in arrayOne)
         {
            Console.Write(i + " ");
         }

         Console.WriteLine();

         int[] arrayTwo = SortArray(expected);
         foreach (int j in arrayTwo)
         {
            Console.Write(j + " ");
         }

         Console.WriteLine();

         //int[] arrayThree = SortOptimizedArray(array);
         //foreach (int k in arrayThree)
         //{
         //   Console.Write(k + " ");
         //}

         //Console.WriteLine();

         //int[] arrayFour = SortOptimizedArray(expected);
         //foreach (int l in arrayFour)
         //{
         //   Console.Write(l + " ");
         //}

         //Console.WriteLine();
      }

      private void SwitchRows(int[,] array)
      {
         var iMax = array.GetLength(0);
         var jMax = array.GetLength(1);

         for (int i = 0; i < iMax; i = i + 2)
         {
            if (i + 1 == iMax)
               break;

            for (int j = 0; j < jMax; j++)
            {
               var a = array[i, j];
               array[i, j] = array[i + 1, j];
               array[i + 1, j] = a;
            }
         }
      }

      void ChangeArray(int[,] array)
      {
         for (int i = 0; i < array.GetLength(0); i++)
         {
            for (int j = 0; j < array.GetLength(1); j++)
            {
               if (i > 0 && i < array.GetLength(1))
               {
                  int temporary = array[i, j];
                  array[i, j] = array[i, j];
                  array[i, j] = temporary;
               }
               else
               {
                  int temporary = array[i, j];
                  array[i, j] = array[(array.GetLength(1) - 1), j];
                  array[(array.GetLength(1) - 1), j] = temporary;
               }
            }
         }
      }

      public static int[] SortArray(int[] numArray)
      {
         int x = 0;
         int n = numArray.Length;
         int i = 0;
         while (i < n - 1)
         {
            int j = 0;
            while (j < n - 1 - i)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
               }

               x++;
               j++;
            }

            i++;
         }

         Console.WriteLine(x);
         return numArray;
      }

      public static int[] SortOptimizedArray(int[] numArray)
      {
         int x = 0;
         int y = 0;
         int n = numArray.Length;
         int i = 0;
         while (i < n - 1)
         {
            bool swapRequired = false;
            int j = 0;
            while (j < n - 1 - i)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
                  swapRequired = true;
               }

               x++;
               j++;
            }

            if (swapRequired == false)
            {
               y++;
               break;
            }

            i++;
         }

         Console.WriteLine(x + ", " + y);
         return numArray;
      }
   }
}