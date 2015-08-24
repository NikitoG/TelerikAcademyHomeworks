//Problem 25. Extract text from HTML

//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

using System;
using System.Text.RegularExpressions;

class ExtractText
{
    static void Main()
    {
        string htmlText = @"<html>
                            <head><title>News</title></head>
                            <body><p><a href=""http://academy.telerik.com"">
                            Telerik Academy</a>aims to provide free real-world practical
                            training for young people who want to turn into
                            skilful .NET software engineers.</p></body>
                            </html>";
        string result = ExtractHtmlInnerText(htmlText);
        Console.WriteLine(result);
    }
    public static string ExtractHtmlInnerText(string htmlText)
    {
        //Match any Html tag (opening or closing tags) 
        // followed by any successive whitespaces
        //consider the Html text as a single line

        Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

        // replace all html tags (and consequtive whitespaces) by spaces
        // trim the first and last space

        string resultText = regex.Replace(htmlText," ").Trim();

        return resultText;
    }
}

