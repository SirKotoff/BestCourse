namespace BestCourse.Web.Models;

public class Currency
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Curr { get; set;}
    public DateTime Date { get; set;}
    public string BestCurrencySale { get; set;}
    public string BestCurrencyBuy { get; set;}
}