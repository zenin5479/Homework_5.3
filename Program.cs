using LibraryFor2DArray;
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
      static void Main()
      {
         string nameFileEnter = "a.txt";
         string nameFileInput = "finish.txt";
         int row = MethodsForArray.SizeRow();
         int column = MethodsForArray.SizeColumn();
         string pathFileEnter = Path.GetFullPath(nameFileEnter);
         double[,] source = MethodsForArray.EnterArrayDouble(row, column, pathFileEnter);
         if (source.GetLength(0) == 0)
         {
            Console.WriteLine("Файл {0} пуст", nameFileEnter);
         }
         else
         {
            double[,] inputArray = MethodsForArray.InputArrayDouble(source, row, column);
            double[] sumRow = MethodsForArray.SumRowElements(inputArray);
            double[,] sortArray = MethodsForArray.BubbleSortArray(inputArray, sumRow);
            string pathFileInput = Path.GetFullPath(nameFileInput);
            File.Create(pathFileInput).Close();
            string[] arrayLines = MethodsForArray.OutputArrayString(sortArray);
            MethodsForArray.FileWriteArrayString(arrayLines, nameFileInput);
         }

         Console.ReadKey();
      }
   }
}