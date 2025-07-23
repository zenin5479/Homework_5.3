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
         int[] array = { 73, 57, 49, 99, 133, 20, 1 };
         int[] expected = { 1, 20, 49, 57, 73, 99, 133 };

         int[] expe = SortArray(array);
         foreach (int s in expe)
         {
            Console.Write(s + " ");
         }
         Console.WriteLine();

         int[] expe2 = SortArray(expected);
         foreach (int r in expe)
         {
            Console.Write(r + " ");
         }
         Console.WriteLine();

         int[] exp = SortOptimizedArray(array);
         foreach (int z in exp)
         {
            Console.Write(z + " ");
         }
         Console.WriteLine();

         int[] exp2 = SortOptimizedArray(expected);
         foreach (int l in exp2)
         {
            Console.Write(l + " ");
         }
         Console.WriteLine();
      }

      public static int[] SortArray(int[] numArray)
      {
         int n = numArray.Length;
         for (int i = 0; i < n - 1; i++)
         {
            for (int j = 0; j < n - i - 1; j++)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
               }
            }
         }

         return numArray;
      }

      public static int[] SortOptimizedArray(int[] numArray)
      {
         int n = numArray.Length;
         bool swapRequired;
         for (int i = 0; i < n - 1; i++)
         {
            swapRequired = false;
            for (int j = 0; j < n - i - 1; j++)
            {
               if (numArray[j] > numArray[j + 1])
               {
                  int tempVar = numArray[j];
                  numArray[j] = numArray[j + 1];
                  numArray[j + 1] = tempVar;
                  swapRequired = true;
               }
            }

            if (swapRequired == false)
               break;
         }

         return numArray;
      }
   }
}