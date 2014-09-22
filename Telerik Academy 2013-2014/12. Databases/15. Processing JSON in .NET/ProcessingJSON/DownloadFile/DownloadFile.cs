namespace DownloadFile
{
    using System.Net;

    public class DownloadFile
    {
        public static void Main()
        {
            var webClient = new WebClient();

            webClient.DownloadFile(
                "http://forums.academy.telerik.com/feed/qa.rss",
                "../../../Telerik Academy Forums - Recent questions and answers/qa.rss");
        }
    }
}