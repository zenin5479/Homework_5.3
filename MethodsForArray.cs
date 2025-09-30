using System;
using System.IO;
using System.Text;

namespace Homework_5._3
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
               Console.WriteLine("Введено неверное значение");
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
               Console.WriteLine("Введено неверное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static double[,] EnterArrayDouble(int n, int m, string path)
      {
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            //Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               //Console.WriteLine(allLines[indexLines]);
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
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            //Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
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
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        //Console.Write(arrayDouble[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        //Console.Write(arrayDouble[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               //Console.WriteLine();
               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static double[,] InputArrayDouble(double[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный числовой массив для проведения поиска");
         double[,] outputArray = new double[n, m];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < m)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static double[] SumRowElements(double[,] inputArray)
      {
         Console.WriteLine("Одномерный массив сумм элементов строк двумерного массива");
         double[] sumArray = new double[inputArray.GetLength(0)];
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            double sum = 0;
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               sum += inputArray[i, j];
               j++;
            }

            sumArray[i] = sum;

            i++;
         }

         int k = 0;
         while (k < sumArray.Length)
         {
            if (k == sumArray.Length - 1)
            {
               //Console.Write(sumArray[k]);
               Console.Write("{0:f}", sumArray[k]);
               //Console.Write("{0:f2}", sumArray[k]);
            }
            else
            {
               //Console.Write(sumArray[k] + " ");
               Console.Write("{0:f} ", sumArray[k]);
               //Console.Write("{0:f2} ", sumArray[k]);
            }

            k++;
         }

         Console.WriteLine();
         return sumArray;
      }

      public static double[,] BubbleSortArray(double[,] inputArray, double[] data)
      {
         Console.WriteLine("Пузырьковая сортировка по сумме элементов строк двумерного массива");
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
                  while (k < inputArray.GetLength(1))
                  {
                     double tempArray = inputArray[i, k];
                     inputArray[i, k] = inputArray[j, k];
                     inputArray[j, k] = tempArray;
                     k++;
                  }
               }

               j++;
            }

            i++;
         }

         int l = 0;
         while (l < inputArray.GetLength(0))
         {
            int m = 0;
            while (m < inputArray.GetLength(1))
            {
               if (m == inputArray.GetLength(1) - 1)
               {
                  //Console.Write(inputArray[l, m]);
                  Console.Write("{0:f}", inputArray[l, m]);
                  //Console.Write("{0:f2}", inputArray[l, m]);
               }
               else
               {
                  //Console.Write(inputArray[l, m] + " ");
                  Console.Write("{0:f} ", inputArray[l, m]);
                  //Console.Write("{0:f2} ", inputArray[l, m]);
               }

               m++;
            }

            l++;
            Console.WriteLine();
         }

         return inputArray;
      }
      
      public static string[] OutputArrayString(double[,] inputArray)
      {
         // Объединение двумерного массива double[]
         // в одномерный массив строк string[] для записи в файл
         //Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.GetLength(0)];
         string subLine;
         int row = 0;
         while (row < inputArray.GetLength(0))
         {
            int column = 0;
            while (column < inputArray.GetLength(1))
            {
               if (column == inputArray.GetLength(1) - 1)
               {
                  stringModified.Append(inputArray[row, column]);
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }
               else
               {
                  stringModified.Append(inputArray[row, column] + " ");
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }

               column++;
            }

            //Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWriteArrayString(string[] arrayString, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, arrayString);
      }
   }
}