using Microsoft.ML.Data;

namespace DataPreProcessingOne
{
    public class PurchaseList
    {
        [LoadColumn(0)]
        public string Country { get; set; }

        [LoadColumn(1)]
        public int Age { get; set; }

        [LoadColumn(2)]
        public int Salary { get; set; }

        [LoadColumn(3)]
        public string Purchased { get; set; }

    }
}