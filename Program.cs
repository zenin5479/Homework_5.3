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
         int[] array = { 73, 57, 49, 99, 12, -20, 1 };
         int[] expected = { 21, 2, 59, -50, 97, 71, 69, 5 };

         //int[] arrayOne = SortArray(array);
         //foreach (int i in arrayOne)
         //{
         //   Console.Write(i + " ");
         //}

         //Console.WriteLine();

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

      public static int[] SortArray(int[] numArray)
      {
         int x = 0;
         int n = numArray.Length;
         for (int i = 0; i < n - 1; i++)
         {
            for (int j = 0; j < n - 1 - i; j++)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
               }

               x++;
            }
         }

         Console.WriteLine(x);
         return numArray;
      }

      public static int[] SortOptimizedArray(int[] numArray)
      {
         int x = 0;
         int y = 0;
         int n = numArray.Length;
         bool swapRequired;
         for (int i = 0; i < n - 1; i++)
         {
            swapRequired = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
                  swapRequired = true;
               }

               x++;
            }

            if (swapRequired == false)
            {
               y++;
               break;
            }
         }

         Console.WriteLine(x + "" + y);
         return numArray;
      }
   }
}