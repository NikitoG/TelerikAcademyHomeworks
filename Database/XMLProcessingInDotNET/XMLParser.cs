namespace XMLProcessingInDotNET
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Xml.Xsl;
    using System.Xml.Schema;

    class XMLParser
    {
        static void Main()
        {
            var filePath = "../../files/catalog.xml";

            GetDifferentArtistsUsingDOMParser(filePath);
            Console.WriteLine(new String('-', 30));
            GetDifferentArtistsUsingXpath(filePath);
            Console.WriteLine(new String('-', 30));
            DeleteAllAlbumsWithPriceGreaterThanTwentyUsingDomParser(filePath);
            Console.WriteLine(new String('-', 30));
            ExtractAllSongsTitleUsingXmlReader(filePath);
            Console.WriteLine(new String('-', 30));
            ExtractAllSongsTitleUsingXDocumentAndLinq(filePath);
            Console.WriteLine(new String('-', 30));

            var textFile = "../../files/person.txt";
            CreateXmlDocumentReadingDataFromTextFile(textFile);
            Console.WriteLine(new String('-', 30));
            ExtractAllAlbumsAndTheirAuthorsInNewXmlFile(filePath);
            Console.WriteLine(new String('-', 30));

            var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TraverseGivenDirectoryToXmlFile(directoryPath);
            Console.WriteLine(new String('-', 30));
            TraverseGivenDirectoryToXmlFileWithXDocument(directoryPath);
            Console.WriteLine(new String('-', 30));

            ExtractPriceOfAlbumOlderThanFiveYears(filePath);
            Console.WriteLine(new String('-', 30));
            ExtractPriceOfAlbumOlderThanFiveYearWithLinq(filePath);
            Console.WriteLine(new String('-', 30));

            ApplyXsltTransformation(filePath);
            Console.WriteLine(new String('-', 30));

            ValidateSchema(filePath);
            Console.WriteLine(new String('-', 30));
        }

        // Problem 2 - Write program that extracts all different artists which are found in the catalog.xml.
        private static void GetDifferentArtistsUsingDOMParser(string filePath)
        {
            Console.WriteLine("Problem 2: ");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode rootNode = doc.DocumentElement;
            var artists = new Dictionary<string, int>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artist = node["artist"].InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0} haves {1} albums", artist.Key, artist.Value);
            }
        }

        // Problem 3 - Implement the previous using XPath.
        private static void GetDifferentArtistsUsingXpath(string filePath)
        {
            Console.WriteLine("Problem 3: ");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            string xPathQuery = "/catalogue/album/artist";
            XmlNodeList artistsList = doc.SelectNodes(xPathQuery);
            var artists = new Dictionary<string, int>();
            foreach (XmlNode node in artistsList)
            {
                var artist = node.InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0} haves {1} albums", artist.Key, artist.Value);
            }
        }

        // Problem 4 - Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
        private static void DeleteAllAlbumsWithPriceGreaterThanTwentyUsingDomParser(string filePath)
        {
            Console.WriteLine("Problem 4: ");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement rootNode = doc.DocumentElement;
            var childForRemove = new List<XmlNode>();
            foreach (XmlNode node in rootNode)
            {
                var price = node["price"].InnerText;
                if (Decimal.Parse(price) > 20)
                {
                    childForRemove.Add(node);
                }
            }

            foreach (XmlNode node in childForRemove)
            {
                rootNode.RemoveChild(node);
            }

            Console.WriteLine("All albums having price > 20 was deleteted!");

            doc.Save("../../files/" + "albumWithPriceLessThan20.xml");
        }

        // Problem 5 - Write a program, which using XmlReader extracts all song titles from catalog.xml.
        private static void ExtractAllSongsTitleUsingXmlReader(string filePath)
        {
            Console.WriteLine("Problem 5: ");

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                    {
                        Console.WriteLine("album: {0}", reader.ReadElementString());
                    }
                }
            }
        }

        // Problem 6 - Rewrite the same using XDocument and LINQ query
        private static void ExtractAllSongsTitleUsingXDocumentAndLinq(string filePath)
        {
            Console.WriteLine("Problem 6: ");

            XDocument xmlDoc = XDocument.Load(filePath);
            var albumsNames = from album in xmlDoc.Descendants("album")
                              select album.Element("name").Value;
            foreach (var name in albumsNames)
            {
                Console.WriteLine("Album: {0}", name);
            }
        }

        // Problem 7 - In a text file we are given the name, address and phone number of given person (each at a single line).
        // Write a program, which creates new XML document, which contains these data in structured XML format.
        private static void CreateXmlDocumentReadingDataFromTextFile(string textFilePath)
        {
            Console.WriteLine("Problem 7: ");

            var person = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(textFilePath))
                {
                    while (sr.Peek() >= 0)
                    {
                        String line = sr.ReadLine();
                        person.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            XElement personXml = new XElement("person",
                new XElement("name", person[0]),
                new XElement("address", person[1]),
                new XElement("phone-number", person[2]));

            Console.WriteLine(personXml);

            personXml.Save("../../files/person.xml");
        }

        // Problem 8 - Write a program, which (using XmlReader and XmlWriter) 
        //              reads the file catalog.xml and creates the file album.xml, 
        //              in which stores in appropriate way the names of all albums and their authors.

        private static void ExtractAllAlbumsAndTheirAuthorsInNewXmlFile(string filePath)
        {
            Console.WriteLine("Problem 8: ");

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (var writer = XmlWriter.Create("../../files/album.xml", ws))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("catalogue");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "album":
                                    writer.WriteStartElement(reader.Name);
                                    break;
                                case "name":
                                    writer.WriteElementString(reader.Name, reader.ReadElementString());
                                    break;
                                case "artist":
                                    writer.WriteElementString(reader.Name, reader.ReadElementString());
                                    writer.WriteEndElement();
                                    break;
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine("All Albums name and authors was extracted!");
        }

        // Problem 9 - Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
        // Use tags <file> and <dir> with appropriate attributes.
        // For the generation of the XML document use the class XmlWriter.
        private static void TraverseGivenDirectoryToXmlFile(string directoryPath)
        {
            Console.WriteLine("Problem 9: ");

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            using (var writer = XmlWriter.Create("../../files/dir.xml", ws))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(new DirectoryInfo(directoryPath).Name);

                GetDirectoryXml(directoryPath, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("Result in dir.xml");
        }

        public static void GetDirectoryXml(string dirPath, XmlWriter writer)
        {
            foreach (var file in Directory.GetFiles(dirPath))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                writer.WriteAttributeString("extension", Path.GetExtension(file));
                writer.WriteFullEndElement();
            }

            foreach (var subDir in Directory.GetDirectories(dirPath))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", new DirectoryInfo(subDir).Name);
                GetDirectoryXml(subDir, writer);
                writer.WriteEndElement();
            }
        }

        // Problem 10 - Rewrite the last exercises using XDocument, XElement and XAttribute.
        private static void TraverseGivenDirectoryToXmlFileWithXDocument(string directoryPath)
        {
            Console.WriteLine("Problem 10: ");

            var doc = new XDocument(TraverseToXml(directoryPath));

            doc.Save("../../files/dirXDoc.xml");

            Console.WriteLine("Result in dirXDoc.xml");
        }

        public static XElement TraverseToXml(string dirPath)
        {
            var dir = new XElement("dir",
                           new XAttribute("name", new DirectoryInfo(dirPath).Name));

            foreach (var file in Directory.GetFiles(dirPath))
            {
                dir.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("extension", Path.GetExtension(file))));
            }

            foreach (var subDir in Directory.GetDirectories(dirPath))
            {
                dir.Add(TraverseToXml(subDir));
            }

            return dir;
        }

        // Problem 11 - Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
        // Use XPath query
        private static void ExtractPriceOfAlbumOlderThanFiveYears(string filePath)
        {
            Console.WriteLine("Problem 11: ");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            var currentYear = DateTime.Now.Year;
            string xPathQuery = string.Format("/catalogue/album[year < ({0})]", currentYear - 5);

            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode album in albums)
            {
                string priceAlbum = string.Format("{0} - {1} - {2}", album.SelectSingleNode("name").InnerText,
                    album.SelectSingleNode("price").InnerText,
                    album.SelectSingleNode("year").InnerText);
                Console.WriteLine(priceAlbum);
            }
        }

        // Problem 12 - Rewrite the previous using LINQ query
        private static void ExtractPriceOfAlbumOlderThanFiveYearWithLinq(string filePath)
        {
            Console.WriteLine("Problem 12: ");

            var currentYear = DateTime.Now.Year;
            XDocument xmlDoc = XDocument.Load(filePath);
            var oldAlbums =
                from album in xmlDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) < (currentYear - 5)
                select new
                {
                    Name = album.Element("name").Value,
                    Price = album.Element("price").Value,
                    Year = album.Element("year").Value
                };

            foreach (var album in oldAlbums)
            {
                Console.WriteLine("{0} - {1} - {2}", album.Name, album.Price, album.Year);
            }
        }

        // Problem 14 - Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
        private static void ApplyXsltTransformation(string filePath)
        {
            Console.WriteLine("Problem 14: ");

            XslTransform myXslTransform;
            myXslTransform = new XslTransform();
            myXslTransform.Load("../../files/catalog.xslt");
            myXslTransform.Transform(filePath, "../../files/catalog.html");

            Console.WriteLine("Result is in catalog.html");
        }

        // Problem 16 - Using Visual Studio generate an XSD schema for the file catalog.xml.
        //Write a C# program that takes an XML file and an XSD file (schema) and validates the XML file against the schema.
        //Test it with valid XML catalogs and invalid XML catalogs.
        private static void ValidateSchema(string filePath)
        {
            Console.WriteLine("Problem 16: ");
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../files/catalog.xsd");

            XDocument validDoc = XDocument.Load(filePath);
            bool errors = false;
            validDoc.Validate(schemas, (o, e) =>
                {
                    Console.WriteLine("{0}", e.Message);
                    errors = true;
                });

            if (!errors)
            {
                Console.WriteLine("{0} - validated", Path.GetFileName(filePath));
            }

            var invalidFilePath = "../../files/invalidCatalog.xml";
            XDocument invalidDoc = XDocument.Load(invalidFilePath);

            errors = false;
            invalidDoc.Validate(schemas, (o, e) =>
                {
                    Console.WriteLine("{0}", e.Message);
                    errors = true;
                });

            if (!errors)
            {
                Console.WriteLine("{0} - validated", Path.GetFileName(filePath));
            }
        }
    }
}