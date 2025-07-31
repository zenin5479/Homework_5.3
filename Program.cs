using System;
using System.IO;

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
         string nameFileEnter = "a.txt";
         string nameFileInput = "finish.txt";
         int row = VariousMethods.SizeRow();
         int column = VariousMethods.SizeColumn();
         string pathFileEnter = Path.GetFullPath(nameFileEnter);
         double[,] source = VariousMethods.EnterArrayDouble(row, column);
         if (source.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileEnter);
         }
         else
         {
            double[,] inputArray = VariousMethods.InputArrayDouble(source, row, column);
            double[] summa = SumRowElements(inputArray);
            EnterArrayDouble(summa);
            Console.WriteLine();

            BubbleSort(inputArray, summa);
            string pathFileInput = Path.GetFullPath(nameFileInput);
            File.Create(pathFileInput).Close();
         }

         //EnterArrayDouble(inputArray);
         //BubbleSort(summa);
         //Console.WriteLine();
         //Console.WriteLine();
         //BubbleSortByRows(number);

         Console.ReadKey();
      }

      public static void BubbleSort(double[,] array, double[] data)
      {
         Console.WriteLine("Двумерный числовой массив");
         int i = 0;
         while (i < data.Length)
         {
            int j = i + 1;
            while (j < data.Length)
            {
               if (data[i] < data[j])
               {
                  double tеmpData = data[i];
                  data[i] = data[j];
                  data[j] = tеmpData;

                  int k = 0;
                  while (k < array.GetLength(1))
                  {
                     double tempArray = array[i, k];
                     array[i, k] = array[j, k];
                     array[j, k] = tempArray;
                     k++;
                  }
               }

               j++;
            }

            i++;
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

      // Пузырьковая сортировка по столбцам двумерного массива
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
      
      public static double[] SumRowElements(double[,] array)
      {
         double[] inputArray = new double[array.GetLength(0)];
         for (int i = 0; i < array.GetLength(0); i++)
         {
            double sum = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
               sum += array[i, j];
            }

            inputArray[i] = sum;
         }

         return inputArray;
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