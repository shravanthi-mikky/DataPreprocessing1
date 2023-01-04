using CsvHelper;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataPreprocessingPruchaseList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int sumOfAge = 0, sumOfSalary = 0, meanOfSalary;
            List<CountryData> itemlist = new List<CountryData>();
            var lines = System.IO.File.ReadAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv").Skip(1).TakeWhile(t => t != null);
            var country = new List<string>();
            foreach (string item in lines)
            {
                var values = item.Split(',');
                itemlist.Add(new CountryData()
                {
                    Country = values[0],
                    Age = int.Parse(values[1]),
                    Salary = int.Parse(values[2]),
                    Purchased = values[3]
                });
            }
            foreach (var item in itemlist)
            {
                Console.WriteLine(item.Country + " " + item.Age + "  " + item.Salary + "  " + item.Purchased);
            }
            for (int i = 1; i < itemlist.Count; i++)
            {
                foreach (var item in itemlist)
                {
                    sumOfAge = sumOfAge + item.Age;
                    sumOfSalary = sumOfSalary + item.Salary;
                    //  Console.WriteLine(sumOfAge);
                }
                break;
            }
            Console.WriteLine("Sum=" + sumOfAge);
            var mean = sumOfAge / itemlist.Count;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Age Mean=" + mean);
            Console.ResetColor();
            Console.WriteLine("\n");

            Console.WriteLine("Sum=" + sumOfSalary);
            meanOfSalary = sumOfSalary / itemlist.Count;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salary Mean=" + meanOfSalary);
            Console.ResetColor();
            Console.WriteLine("\n");

            for (int i = 0; i < itemlist.Count; i++)
            {
                foreach (var item in itemlist)
                {
                    if (item.Age == 0)
                    {
                        item.Age = mean;
                    }
                    if (item.Salary == 0)
                    {
                        item.Salary = meanOfSalary;
                    }
                }
            }
            foreach (var item in itemlist)
            {
                Console.WriteLine(item.Country + "     " + item.Age + "     " + item.Salary + "    " + item.Purchased);
            }
            string path = @"C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv";
            using (StreamWriter sw = new StreamWriter(path))
            {
                using CsvWriter cw = new CsvWriter(sw, System.Globalization.CultureInfo.InvariantCulture);
                cw.WriteRecords(itemlist);
            }


            /// Transform to Numerical data
            /// 
            var context = new MLContext();
            IDataView data = context.Data.LoadFromTextFile<CountryData>("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv", hasHeader: true, separatorChar: ',');

            // A pipeline for one hot encoding the Education column.
            var pipeline = context.Transforms.Categorical.OneHotEncoding(
                "EducationOneHotEncoded", "Country");

            // Fit and transform the data.
            IDataView oneHotEncodedData = pipeline.Fit(data).Transform(data);

            PrintDataColumn(oneHotEncodedData, "EducationOneHotEncoded");

            // We have 3 slots because there are three categories in the
            // 'Education' column.

            // A pipeline for one hot encoding the Education column (using keying).
            var keyPipeline = context.Transforms.Categorical.OneHotEncoding(
                "EducationOneHotEncoded", "Country",
                OneHotEncodingEstimator.OutputKind.Key);

            // Fit and Transform data.
            oneHotEncodedData = keyPipeline.Fit(data).Transform(data);

            var keyEncodedColumn =
                oneHotEncodedData.GetColumn<uint>("EducationOneHotEncoded");

            Console.WriteLine(
                "One Hot Encoding of single column 'Country', with key type " +
                "output.");

            // One Hot Encoding of single column 'Education', with key type output.

            foreach (uint element in keyEncodedColumn)
                Console.WriteLine(element);
        }

        private static void PrintDataColumn(IDataView transformedData,
            string columnName)
        {
            var countSelectColumn = transformedData.GetColumn<float[]>(
                transformedData.Schema[columnName]);

            foreach (var row in countSelectColumn)
            {
                for (var i = 0; i < row.Length; i++)
                    Console.Write($"{row[i]}\t");

                Console.WriteLine();
            }
        }

        private class DataPoint
        {
            public string Education { get; set; }
        }
    }
    
}
