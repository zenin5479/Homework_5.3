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
         int[,] num =
         {
            { -71, -22, -70, 26, 74, 53, 43, -25, -44, -16 },
            {-40, 10, 11, 7, 47, 10, 4, 30, 35, 7},
            {37, -36, -31, -56, -36, 14, -17, 4, -62, 79},
            {64, 69, -20, -42, 66, 40, 50, 11, 53, -77},
            {-62, -46, 80, -30, 24, 8, -16, 66, -70, -40},
            {26, 83, 68, 98, 41, -73, -39, 19, -97, -95},
            {84, 29, 3, -34, -2, -92, -52, 85, 57, -98},
            {64, -27, -29, -49, 59, -91, 7, 40, -3, 88},
            {77, 69, -68, -63, 29, 28, 18, -66, 5, -57},
            {86, -3, 86, -13, -83, -48, -72, -23, 33, 42}
         };

         SwitchRows(num);
         Console.ReadKey();
      }

      private static void SwitchRows(int[,] array)
      {
         int iMax = array.GetLength(0);
         int jMax = array.GetLength(1);
         for (int i = 0; i < iMax; i = i + 2)
         {
            for (int j = 0; j < jMax; j++)
            {
               int a = array[i, j];
               array[i, j] = array[i + 1, j];
               array[i + 1, j] = a;
               Console.Write(a + ", ");
            }

            Console.WriteLine();
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