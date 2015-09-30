## XML Basics
### _Homework_

1.  What does the XML language represent? What is it used for? 

		- XML stands for EXtensible Markup Language
		- XML is a markup language much like HTML
		- XML was designed to store and transport data
		- XML was designed to be self-descriptive
		
1.  Create XML document `students.xml`, which contains structured description of students.
  * For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).

		DONE

1.  What do namespaces represent in an XML document? What are they used for? 

		XML namespaces provide a simple method for qualifying element and 
		attribute names used in Extensible Markup Language documents by 
		associating them with namespaces identified by URI references.

1.  Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.

		URLs
		Main article: Uniform Resource Locator (URL)
		A URL is a URI that, in addition to identifying a web resource, specifies the means of acting upon or obtaining the representation of it, i.e. specifying both its primary access mechanism and network location. For example, the URL http://example.org/wiki/Main_Page refers to a resource identified as /wiki/Main_Page whose representation, in the form of HTML and related code, is obtainable via HyperText Transfer Protocol (http) from a network host whose domain name is example.org.

		URNs
		Main article: Uniform Resource Name (URN)
		A URN is a URI that identifies a resource by name in a particular namespace. A URN can be used to talk about a resource without implying its location or how to access it.
		
		The International Standard Book Number (ISBN) system for uniquely identifying books provides a typical example of the use of URNs. ISBN 0-486-27557-4 cites unambiguously a specific edition of Shakespeare's play Romeo and Juliet. The URN for that edition would be urn:isbn:0-486-27557-4. To gain access to this object and read the book, its location is needed, for which a URL would have to be specified.

1.  Add default namespace for students "`urn:students`".

		DONE

1.  Create XSD Schema for `students.xml` document.
  * Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.

		DONE

1.  Write an XSL stylesheet to visualize the students as HTML.
  * Test it in your favourite browser.

		DONE
