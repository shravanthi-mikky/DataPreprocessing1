using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPreprocessingPruchaseList
{
    public class CountryData
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

    public class CountryData2
    {

        [LoadColumn(0)]
        public int Age { get; set; }

        [LoadColumn(1)]
        public int Salary { get; set; }

        [LoadColumn(2)]
        public int purchasedList { get; set; }

        [LoadColumn(3)]
        public int Country_France { get; set; }

        [LoadColumn(4)]
        public int Country_Spain { get; set; }

        [LoadColumn(5)]
        public int Country_Germany { get; set; }
    }
}
