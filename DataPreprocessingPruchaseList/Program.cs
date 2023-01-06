using CsvHelper;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<int> purchasedList = new List<int>();
            //printing only purchase
            foreach (var item in itemlist)
            {
                Console.WriteLine(item.Purchased);
                if(item.Purchased == "Yes")
                {
                    purchasedList.Add(1);
                }
                else
                {
                    purchasedList.Add(0);
                }
            }
            foreach (var item in purchasedList)
            {
                Console.WriteLine(item);
            }
            for (int i = 1; i < itemlist.Count; i++)
            {
                foreach (var item in itemlist)
                {
                    sumOfAge += item.Age;
                    sumOfSalary +=  item.Salary;
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

            var pipeline2 = context.Transforms.Categorical.OneHotEncoding(
                "PurchasedOneHotEncoded", "Purchased");
            // Fit and transform the data.
            IDataView oneHotEncodedData = pipeline.Fit(data).Transform(data);

           // PrintDataColumn(oneHotEncodedData, "PurchasedOneHotEncoded");
           // PrintDataColumn(oneHotEncodedData, "EducationOneHotEncoded");
           //Replacing function by using code here

            List<float> Encode1 = new List<float>();
            List<float> Encode2 = new List<float>();
            List<float> Encode3 = new List<float>();
            var countSelectColumn = oneHotEncodedData.GetColumn<float[]>(
                oneHotEncodedData.Schema["EducationOneHotEncoded"]);

            List<CountryData2> EncodedList1 = new List<CountryData2>();

            Console.WriteLine("EducationOneHotEncoded");
            foreach (var row in countSelectColumn)
            {
                for (var i = 0; i < row.Length; i++)
                {
                    Console.Write($"{row[i]}\t");
                    if(i == 0)
                    {
                        Encode1.Add(row[i]);
                    }
                    if (i == 1)
                    {
                        Encode2.Add(row[i]);
                    }
                    if (i == 2)
                    {
                        Encode3.Add(row[i]);
                    }
                }
                Console.WriteLine();
            }

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

            // One Hot Encoding of single column 'Country', with key type output.

            /*foreach (uint element in keyEncodedColumn)
                Console.WriteLine(element);
            */

            List<uint> CountryEncoded = new List<uint>();

            foreach (uint element in keyEncodedColumn)
            {
                //Console.WriteLine(element);
                CountryEncoded.Add(element);
            }
            //added the encoded values to list
            foreach(uint element in CountryEncoded)
            {
                Console.WriteLine(element);
            }

            //Adding column to csv file
            List<string> lines2 = File.ReadAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv").ToList();
            //add new column to the header row
            lines2[0] += ",CountryEncoded";
            int index = 1;
            //add new column value for each row.
            lines2.Skip(1).ToList().ForEach(line =>
            {
                //-1 for header
                lines2[index] += "," + CountryEncoded[index - 1];
                index++;
            });


            //write the new content
            File.WriteAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv", lines2);

            //adding purchased List to csv

            List<string> lines3 = File.ReadAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv").ToList();
            //add new column to the header row
            lines3[0] += ",purchasedList";
            int index1 = 1;
            //add new column value for each row.
            lines3.Skip(1).ToList().ForEach(line =>
            {
                //-1 for header
                lines3[index1] += "," + purchasedList[index1 - 1];
                index1++;
            });

            //Adding country France

            lines3[0] += ",Country_France";
            int index2 = 1;
            //add new column value for each row.
            lines3.Skip(1).ToList().ForEach(line =>
            {
                //-1 for header
                lines3[index2] += "," + Encode1[index2 - 1];
                index2++;
            });
            //Adding Country Spain
            lines3[0] += ",Country_Spain";
            int index3 = 1;
            //add new column value for each row.
            lines3.Skip(1).ToList().ForEach(line =>
            {
                //-1 for header
                lines3[index3] += "," + Encode2[index3 - 1];
                index3++;
            });
            //Adding country Germany
            lines3[0] += ",Country_Germany";
            int index4 = 1;
            //add new column value for each row.
            lines3.Skip(1).ToList().ForEach(line =>
            {
                //-1 for header
                lines3[index4] += "," + Encode3[index4 - 1];
                index4++;
            });


            //write the new content
            File.WriteAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv", lines3);

            List<CountryData2> EncodedList = new List<CountryData2>();

            var lines4 = System.IO.File.ReadAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/data_preprocessing.csv").Skip(1).TakeWhile(t => t != null);
            
            foreach (string item in lines4)
            {
                var values = item.Split(',');
                EncodedList.Add(new CountryData2()
                {
                    Age = int.Parse(values[1]),
                    Salary = int.Parse(values[2]),
                    purchasedList = int.Parse(values[5]),
                    Country_France = int.Parse(values[6]),
                    Country_Spain = int.Parse(values[7]),
                    Country_Germany = int.Parse(values[8])
                });
            }
            foreach (var item in EncodedList)
            {
                Console.WriteLine( item.Age + "  " + item.Salary + "  " + item.purchasedList + "  " + item.Country_France + "  " + item.Country_Spain + "  " + item.Country_Germany);
            }

            using (var writer = new StreamWriter("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/Encoded.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(EncodedList);
                
            }

            //File.WriteAllLines("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/Encoded.csv", EncodedList);

            //Normalization
            IDataView dataList = context.Data.LoadFromTextFile<CountryData2>("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreprocessingPruchaseList/Encoded.csv", hasHeader: true, separatorChar: ',');
            var columnPair = new[]
            {
                new InputOutputColumnPair("Age"),
                new InputOutputColumnPair("Salary"),
                new InputOutputColumnPair("purchasedList"),
                new InputOutputColumnPair("Country_France"),
                new InputOutputColumnPair("Country_Spain"),
                new InputOutputColumnPair("Country_Germany")
            };

            //var normalize = context.Transforms.NormalizeMinMax(columnPair, fixZero: false);

            var normalize = context.Transforms.NormalizeMeanVariance(columnPair, fixZero: false);

            //transform.

            var normalizeFixZero = context.Transforms.NormalizeMeanVariance(columnPair, fixZero: true);
            var normalizeTransform = normalize.Fit(dataList);
            var transformedData = normalizeTransform.Transform(dataList);


            
            var normalizeFixZeroTransform = normalizeFixZero.Fit(dataList);
            var fixZeroData = normalizeFixZeroTransform.Transform(dataList);
            var Age = transformedData.GetColumn<float>("Age");
            var Salary = transformedData.GetColumn<float>("Salary");
            var PurchasedList = transformedData.GetColumn<float>("purchasedList");
            var Country_France = transformedData.GetColumn<float>("Country_France");
            var Country_Spain = transformedData.GetColumn<float>("Country_Spain");
            var Country_Germany = transformedData.GetColumn<float>("Country_Germany");

            Console.WriteLine("Printing Normalized Age");
            foreach(var item in Age)
            {
                Console.WriteLine(item);
            }
            List<CountryData2> ListOfAllColumns = new List<CountryData2>();


            var preview = transformedData.Preview();
            foreach (var col in preview.Schema)
            {
                //Console.WriteLine(col.Index); 
                 if (((col.Index % 2 ) == 0 ))
                {
                    Console.Write(col.Name + "\t");
                    
                }
            }
            Console.WriteLine();
            for (int j = 0; j < preview.RowView.Length; j++)
            {
                for (int i = 1; i < 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(preview.RowView[j].Values[i].Value + "\t");
                    }
                }
                Console.WriteLine();
            }
            //Console.WriteLine("Age\tSalary\tPurchasedList\tCountry_France\tCountry_Spain\tCountry_Germany");
            for (int j = 0; j < preview.RowView.Length; j++)
            {
                ListOfAllColumns.Add(new CountryData2()
                {
                    Age = ((float)preview.RowView[j].Values[1].Value),
                    Salary = ((float)preview.RowView[j].Values[3].Value),
                    purchasedList = ((float)preview.RowView[j].Values[5].Value),
                    Country_France = ((float)preview.RowView[j].Values[7].Value),
                    Country_Spain = ((float)preview.RowView[j].Values[9].Value),
                    Country_Germany = ((float)preview.RowView[j].Values[11].Value),
                });
            }
            foreach (var item in ListOfAllColumns)
            {
                Console.WriteLine(item.Age + " " + item.Salary + "  " + item.purchasedList + "  " + item.Country_France + "  " + item.Country_Spain + "  " + item.Country_Germany);
            }

            var dataview = context.Data.LoadFromEnumerable(ListOfAllColumns);
            var split1 = context.Data.TrainTestSplit(dataview, testFraction: 0.2);
            var trainSet = context.Data.CreateEnumerable<CountryData2>(split1.TrainSet, reuseRowObject: false);

            var testSet = context.Data.CreateEnumerable<CountryData2>(split1.TestSet, reuseRowObject: false);

            PrintPreviewRows(trainSet, testSet);


        }

        private static void PrintPreviewRows(IEnumerable<CountryData2> trainSet,
            IEnumerable<CountryData2> testSet)

        {

            Console.WriteLine($"The data in the Train split.\n");
            foreach (var row in trainSet)
                Console.WriteLine($"{row.Age}, {row.Salary},{row.purchasedList},{row.Country_France},{row.Country_Spain},{row.Country_Germany}");

            Console.WriteLine($"\nThe data in the Test split.\n");
            foreach (var row in testSet)
                Console.WriteLine($"{row.Age}, {row.Salary},{row.purchasedList},{row.Country_France},{row.Country_Spain},{row.Country_Germany}");
        }

        private static void PrintDataColumn(IDataView transformedData,
            string columnName)
        {
            var countSelectColumn = transformedData.GetColumn<float[]>(
                transformedData.Schema[columnName]);

            List<CountryData2> EncodedList1 = new List<CountryData2>();

            Console.WriteLine(columnName);
            foreach (var row in countSelectColumn)
            {
                for (var i = 0; i < row.Length; i++)
                    Console.Write($"{row[i]}\t");

                Console.WriteLine();
            }
        }

        private class DataPoint
        {
            public string Country { get; set; }
        }
    }
    
}
