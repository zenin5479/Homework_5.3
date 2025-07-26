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
            {-87.39, -12.38, -88.93, -6.05, 73.40, -35.01, -56.16, 42.12, -99.55, 53.52 },
            {-48.09, 59.51, -91.36, -71.55, 47.46, -0.57, -5.72, -73.92, 8.37, 18.60 },
            {-86.13, -18.24, 55.57, -77.51, -5.61, -2.62, 68.96, 47.36, -24.51, 65.83 },
            {-75.65, -26.89, -47.29, -3.93, -12.94, -99.92, -87.51, -98.39, 22.97, 44.00},
            {-65.25, -92.37, 33.10, -40.81, 39.64, 45.73, -11.94, 89.37, -46.13, 73.43},
            {2.23, 2.99, -72.07, -7.00, 15.44, 57.75, 15.24, -98.13, 73.88, 66.98},
            {-84.66, -33.08, -69.47, -46.32, -20.73, -42.17, -19.94, -66.76, 23.69, 83.48 }
         };

         double[] summa = Sum(number);
         EnterArrayDouble(summa);
         Console.WriteLine();
         //EnterArrayDouble(number);
         Puzurek(summa);
         Puzurek(number);
         Console.ReadKey();
      }

      static void Puzurek(double[,] num)
      {
         Console.WriteLine("Двумерный числовой массив");
         for (int i = 0; i < num.GetLength(0); i++)
         {
            for (int j = 0; j < num.GetLength(1); j++)
            {
               for (int k = i + 1; k < num.Length; k++)
               {
                  if (num[i, j] < num[k, j])
                  {
                     double tmp = num[i, j];
                     num[i, j] = num[k, j];
                     num[k, j] = tmp;
                  }
               }
            }
         }

         int x = 0;
         while (x < num.GetLength(0))
         {
            int z = 0;
            while (z < num.GetLength(0))
            {
               Console.Write(num[x, z] + " ");
               Console.Write("{0:f2} ", num[x, z]);
               Console.Write("{0:f} ", num[x, z]);
               z++;
            }

            x++;
         }
      }

      static void Puzurek(double[] sum)
      {
         Console.WriteLine("Двумерный числовой массив");
         for (int i = 0; i < sum.Length; i++)
         {
            for (int j = i + 1; j < sum.Length; j++)
            {
               if (sum[i] < sum[j])
               {
                  double tmp = sum[i];
                  sum[i] = sum[j];
                  sum[j] = tmp;
               }
            }
         }

         int x = 0;
         while (x < sum.GetLength(0))
         {
            //Console.Write(sum[x] + " ");
            //Console.Write("{0:f2} ", sum[x]);
            Console.Write("{0:f} ", sum[x]);
            x++;
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
               //Console.Write("{0:f2} ", num[i, j]);
               //Console.Write("{0:f} ", num[i, j]);
               Console.Write(num[i, j] + " ");
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
            //Console.Write("{0:f2} ", num[i]);
            Console.Write("{0:f} ", num[i]);
            i++;
         }
      }

      private static double[] Sum(double[,] arr)
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

      private static void SwitchRows(int[,] array)
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