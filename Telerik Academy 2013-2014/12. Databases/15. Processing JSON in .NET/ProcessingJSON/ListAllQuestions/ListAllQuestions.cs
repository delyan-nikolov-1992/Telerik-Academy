namespace ListAllQuestions
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Newtonsoft.Json;

    using ParseJSONToPOCO;

    public class ListAllQuestions
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../Telerik Academy Forums - Recent questions and answers/qa.json"))
            {
                string json = reader.ReadToEnd();

                var poco = JsonConvert.DeserializeObject<RootObject>(json);
                var questions = poco.Rss.Channel.Item;

                GenerateHtmlPage(questions);
            }
        }

        private static void GenerateHtmlPage(IList<Item> questions)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=" + "en" + "xmlns=" + "http://www.w3.org/1999/xhtml" + ">");
            html.AppendLine("<head>");
            html.AppendLine("   <meta charset=" + "utf-8" + " />");
            html.AppendLine("   <title>Questions</title>");
            html.AppendLine("   <style>");
            html.AppendLine("       table {");
            html.AppendLine("           border-collapse: collapse;");
            html.AppendLine("       }");
            html.AppendLine();
            html.AppendLine("       table, td, th {");
            html.AppendLine("           border: 1px solid black;");
            html.AppendLine("       }");
            html.AppendLine("   </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("   <table>");
            html.AppendLine("       <tr>");
            html.AppendLine("           <th>Question</th>");
            html.AppendLine("           <th>Category</th>");
            html.AppendLine("           <th>Link</th>");
            html.AppendLine("       </tr>");

            foreach (var currentQuestion in questions)
            {
                html.AppendLine("       <tr>");
                html.AppendLine(string.Format("         <td>{0}</td>", currentQuestion.Title));
                html.AppendLine(string.Format("         <td>{0}</td>", currentQuestion.Category));
                html.AppendLine(string.Format("         <td><a href=" + "{0}" + ">{0}</a></td>", currentQuestion.Link));
                html.AppendLine("       </tr>");
            }

            html.AppendLine("   </table>");
            html.AppendLine("</body>");
            html.Append("</html>");

            File.WriteAllText("../../../Telerik Academy Forums - Recent questions and answers/qa.html", html.ToString());
        }
    }
}