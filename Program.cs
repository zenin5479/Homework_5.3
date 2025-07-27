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
         double[,] number =
         {
            {77.39, -12.38, -58.93, -6.05, -77.40 },
            {-48.09, 51.51, -48.36, -71.55, 47.46},
            {86.13, -18.24, -75.57, 82.51, -5.61},
            {25.65, 31.89, 37.29, -3.93, -12.94},
         };

         double[] summa = Sum(number);
         EnterArrayDouble(summa);
         Console.WriteLine();
         EnterArrayDouble(number);
         BubbleSort(summa);
         Console.WriteLine();
         BubbleSort(number, summa);
         Console.ReadKey();
      }

      void BubbleSortByRows(int[,] array)
      {
         int rows = array.GetLength(0);
         int cols = array.GetLength(1);

         for (int row = 0; row < rows; row++)
         {
            for (int i = 0; i < cols - 1; i++)
            {
               for (int j = 0; j < cols - i - 1; j++)
               {
                  if (array[row, j] > array[row, j + 1])
                  {
                     Swap(ref array[row, j], ref array[row, j + 1]);
                  }
               }
            }
         }
      }

      public static void BubbleSort(double[,] array, double[] data)
      {
         Console.WriteLine("Двумерный числовой массив");
         for (int i = 0; i < array.GetLength(0); i++)
         {
            for (int j = 0; j < array.GetLength(1); j++)
            {
               for (int k = i + 1; k < array.GetLength(0); k++)
               {
                  if (data[i] > data[k])
                  {
                     double tmp = array[i, j];
                     array[i, j] = array[k, j];
                     array[k, j] = tmp;
                  }
               }
            }
         }

         int l = 0;
         while (l < array.GetLength(0))
         {
            int m = 0;
            while (m < array.GetLength(1))
            {
               Console.Write(array[l, m] + " ");
               //Console.Write("{0:f} ", array[l, m]);
               //Console.Write("{0:f2} ", array[l, m]);
               m++;
            }

            l++;
            Console.WriteLine();
         }
      }

      public static void BubbleSort(double[] array)
      {
         Console.WriteLine("Одномерный числовой массив");
         int i = 0;
         while (i < array.Length)
         {
            int j = i + 1;
            while (j < array.Length)
            {
               if (array[i] < array[j])
               {
                  double tmp = array[i];
                  array[i] = array[j];
                  array[j] = tmp;
               }

               j++;
            }

            i++;
         }

         int k = 0;
         while (k < array.GetLength(0))
         {
            //Console.Write(array[k] + " ");
            Console.Write("{0:f} ", array[k]);
            //Console.Write("{0:f2} ", array[k]);
            k++;
         }
      }

      public static void EnterArrayDouble(double[,] num)
      {
         Console.WriteLine("Двумерный числовой массив");
         int i = 0;
         while (i < num.GetLength(0))
         {
            int j = 0;
            while (j < num.GetLength(1))
            {
               Console.Write(num[i, j] + " ");
               //Console.Write("{0:f} ", num[i, j]);
               //Console.Write("{0:f2} ", num[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }
      }

      public static void EnterArrayDouble(double[] num)
      {
         Console.WriteLine("Одномерный числовой массив");
         int i = 0;
         while (i < num.GetLength(0))
         {
            //Console.Write(num[i] + " ");
            Console.Write("{0:f} ", num[i]);
            //Console.Write("{0:f2} ", num[i]);
            i++;
         }
      }

      public static double[] Sum(double[,] arr)
      {
         double[] y = new double[arr.GetLength(0)];
         for (int i = 0; i < arr.GetLength(0); i++)
         {
            double sum = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
               sum += arr[i, j];
            }

            y[i] = sum;
         }

         return y;
      }

      public static void SwitchRows(int[,] array)
      {

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