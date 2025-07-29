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
            {1.11, -12.38, -88.93, -6.05, 73.40, -35.01, -56.16, 42.12, -99.55, 53.52 },
            {2.22, 59.51, -91.36, -71.55, 47.46, -0.57, -5.72, -73.92, 8.37, 18.60 },
            {3.33, -18.24, 55.57, -77.51, -5.61, -2.62, 68.96, 47.36, -24.51, 65.83 },
            {4.44, -26.89, -47.29, -3.93, -12.94, -99.92, -87.51, -98.39, 22.97, 44.00},
            {5.55, -92.37, 33.10, -40.81, 39.64, 45.73, -11.94, 89.37, -46.13, 73.43},
            {6.66, 2.99, -72.07, -7.00, 15.44, 57.75, 15.24, -98.13, 73.88, 66.98},
            {7.77, -33.08, -69.47, -46.32, -20.73, -42.17, -19.94, -66.76, 23.69, 83.48 },
            {8.88, 74.65, 60.43, -64.11, -6.15, 81.22, -70.96, 42.83, -75.85, -97.70 }
         };

         double[] summa = Sum(number);
         EnterArrayDouble(summa);
         Console.WriteLine();
         EnterArrayDouble(number);
         //BubbleSort(summa);
         //Console.WriteLine();
         BubbleSort(number, summa);
         //Console.WriteLine();
         //BubbleSortByRows(number);

         Console.ReadKey();
      }

      public static void BubbleSort(double[,] array, double[] data)
      {
         Console.WriteLine("Двумерный числовой массив");
         for (int i = 0; i < array.GetLength(0); i++)
         {
            for (int j = 0; j < array.GetLength(1); j++) // ????
            {
               for (int k = i + 1; k < array.GetLength(0) - i; k++) // ???
               {
                  if (data[i] < data[k])
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

      static void BubbleSortByRows(double[,] array)
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
                     double temp = array[row, j];
                     array[row, j] = array[row, j + 1];
                     array[row, j + 1] = temp;
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