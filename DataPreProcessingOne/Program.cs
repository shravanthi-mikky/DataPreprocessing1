using Microsoft.ML;
using System;

namespace DataPreProcessingOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<PurchaseList>("./data_preprocessing.csv",hasHeader:true,separatorChar:',');

            var split = context.Data.TrainTestSplit(data,testFraction:0.2);

            var dataProcessPipeline = context.Transforms.Concatenate("Features", new[] { "Country", "Age", "Salary", "Purchased" });

            var trainer = context.BinaryClassification.Trainers.
        }
    }
}
