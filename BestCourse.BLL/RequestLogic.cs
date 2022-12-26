using AngleSharp.Html.Parser;
using AngleSharp;
using System.Net;

namespace BestCourse.BLL;

public class RequestLogic
{
    private string GetRequest(string path)
    {
        string result = "";
        try
        {
            if (string.IsNullOrEmpty(path))
            {
                return "[path = null]";
            }
            else
            {
                var request = (HttpWebRequest)WebRequest.Create($"{path}");
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();
                using var streamReader = new StreamReader(response.GetResponseStream());
                result = streamReader.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return result;
    }

    public string GetDataFromRequest(string path)
    {
        string body = GetRequest(path);
        HtmlParser parser = new HtmlParser();
        var config = Configuration.Default;
        var document =  parser.ParseDocument(body);
        using var context = BrowsingContext.New(config);

       var curr = document.QuerySelector("tr#bank-row-20 td span.accent.best").TextContent;

        return curr;
    }
}