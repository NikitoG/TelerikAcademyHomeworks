//Problem 12. Parse URL

//Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] 
//and extracts from it the [protocol], [server] and [resource] elements.

using System;

class URL
{
    static void Main()
    {
        //string url = Console.ReadLine();
        string url = @"https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/06.%20Strings%20and%20Text%20Processing/README.md";
        int startIndex = 0;
        int endIndex = 0;
        endIndex = url.IndexOf("://", startIndex);
        Console.WriteLine("[protocol] = {0}", url.Substring(startIndex,endIndex - startIndex));
        startIndex = endIndex + 3;
        endIndex = url.IndexOf("/", startIndex);
        Console.WriteLine("[server] = {0}", url.Substring(startIndex,endIndex - startIndex));
        startIndex = endIndex + 1;
        endIndex = url.IndexOf("/", startIndex);
        Console.WriteLine("[resource] = {0}", url.Substring(startIndex,url.Length- startIndex));
    }

}

