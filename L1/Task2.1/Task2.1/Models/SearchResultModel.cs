

namespace Task2._1.Models
{
    public class SearchResultModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReviewSummaryResult { get; set; }
        public double Price { get; set; }


        public SearchResultModel(string name,
                                DateTime releaseDate,
                                string reviewSummaryResult,
                                double price)
        {
            Name = name;
            ReleaseDate = releaseDate;
            ReviewSummaryResult = reviewSummaryResult;
            Price = price;
        }
    }
}
