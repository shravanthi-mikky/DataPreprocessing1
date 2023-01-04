using Microsoft.ML;
using Microsoft.ML.Transforms;
using System;

namespace DataPreProcessingOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            float sumOfAge = 0, sumOfSalary = 0,meanOfSalary, meanOfAge, salaryValue;

            var context = new MLContext();

            IDataView data = context.Data.LoadFromTextFile<PurchaseList>("C:/Users/Admin/Desktop/WebPractice/MachineLearning/DataPreprocessing1/DataPreProcessingOne/data_preprocessing.csv", hasHeader:true,separatorChar:',');

            //To print the content of data that is been loaded from csv file
            var preview = data.Preview();
            foreach (var col in preview.Schema)
            {
                if (col.Name == "Features")
                {
                    continue;
                }
                Console.Write(col.Name + "\t");
            }
            Console.WriteLine();

            //Row view
            foreach (var row in preview.RowView)
            {
                Console.WriteLine();
                foreach (var col in row.Values)
                {
                    if (col.Key == "Features")
                    {
                        continue;
                    }
                    Console.Write($"{col.Value}\t");
                }
            }
            Console.WriteLine("\nCount: {0}\n", preview.RowView.Length);
            

            //Column view
            foreach (var row in preview.ColumnView)
            {
                string ColumnName = row.Column.Name.ToString();
                if(ColumnName == "Age")
                {
                    foreach (var col in row.Values)
                    {
                        int ageValue = Convert.ToInt32(col);
                        //Calculating the sum of all values in age column
                        sumOfAge += ageValue;
                    }
                }
                if (ColumnName == "Salary")
                {
                    foreach (var col in row.Values)
                    {
                        Console.WriteLine(col +" \t" + col.GetType());
                        salaryValue = Convert.ToInt32(col);
                        //Calculating the sum of all values in slaary column
                        sumOfSalary += salaryValue;
                    }
                }
            }
            //calculating the mean for age and salary
            meanOfSalary = sumOfSalary / preview.RowView.Length;
            meanOfAge = sumOfAge / preview.RowView.Length;
            Console.WriteLine("Sum of Salary : {0} \t Mean Of Salary : {1} \nSum of Age : {2} \t Mean Of Age : {3}",sumOfSalary, meanOfSalary,sumOfAge,meanOfAge);
            Console.WriteLine("\nCount: {0}\n", preview.RowView.Length);
            //Filling the missing values with mean value
            foreach (var row in preview.ColumnView)
            {
                string ColumnName = row.Column.Name.ToString();
                if (ColumnName == "Age")
                {
                    /*foreach (var col in row.Values)
                    {

                        if(col.Equals(Convert.ToSingle(0)))
                        {
                            Console.WriteLine("*********************");
                            Console.WriteLine(col);
                            //col.Equals(Convert.ToSingle(meanOfAge));
                            //Convert.ToInt32(col) = meanOfAge;
                            Console.WriteLine("*********************");
                            Console.WriteLine(col);
                        }
                    }*/
                    for(int i=0;i< preview.RowView.Length; i++)
                    {
                        if (row.Values[i].Equals(Convert.ToSingle(0)))
                        {
                            Console.WriteLine(row.Values[i]);
                            row.Values[i] = meanOfAge;
                            Console.WriteLine(row.Values[i]);
                        }
                    }
                }
                if (ColumnName == "Salary")
                {
                    foreach (var col in row.Values)
                    {
                        salaryValue = Convert.ToInt32(col);
                        //Calculating the sum of all values in slaary column
                        sumOfSalary += salaryValue;
                    }
                }
            }
            Console.WriteLine("#####################");
            //Column view
            foreach (var row in preview.RowView)
            {
                Console.WriteLine();
                foreach (var col in row.Values)
                {
                    if (col.Key == "Features")
                    {
                        continue;
                    }
                    Console.Write($"{col.Value}\t");
                }
            }


            //IDataView filteredData = context.Data.FilterRowsByColumn(data, "Age", lowerBound: 26, upperBound: 51);

            //IDataView filteredData2 = context.Data.FilterRowsByColumn(data, "Salary", lowerBound: 48000, upperBound: 83000);


            // Define replacement estimator
            var replacementEstimator = context.Transforms.ReplaceMissingValues("Age", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean);

             var replacementEstimator2 = context.Transforms.ReplaceMissingValues("Salary", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean);

            // Fit data to estimator
            // Fitting generates a transformer that applies the operations of defined by estimator
            ITransformer replacementTransformer = replacementEstimator.Fit(data);

            // Transform data
            //IDataView transformedData = replacementTransformer.Transform(data);


            // Define min-max estimator
            //var minMaxEstimator = context.Transforms.NormalizeMinMax("Salary");

            // Fit data to estimator
            // Fitting generates a transformer that applies the operations of defined by estimator
            //ITransformer minMaxTransformer = minMaxEstimator.Fit(data);

            // Transform data
            //IDataView transformedData2 = minMaxTransformer.Transform(data);

            //var split = context.Data.TrainTestSplit(data,testFraction:0.2);
            //var dataProcessPipeline = context.Transforms.Concatenate("Features", new[] { "Country", "Age", "Salary", "Purchased" });
            //var trainer = context.BinaryClassification.Trainers.
        }
    }
}
