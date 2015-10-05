## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?

	- A database is a collection of information that is organized so that it can easily be accessed, managed, and updated. In one view, databases can be classified according to types of content: bibliographic, full-text, numeric, and images.
	
	-  Database systems can be based on different data models or database models respectively. A data model is a collection of concepts and rules for the description of the structure of the database. Structure of the database means the data types, the constraints and the relationships for the description or storage of data respectively. 
	
	-  The most often used data	models are:
		-  Network Model and Hierarchical Model
		-  Relational Model
		-  Object-oriented Model
		-  Object-relational Model
		 
1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?

	- Provides data to be stored in tables
	- Persists data in the form of rows and columns
	- Provides facility primary key, to uniquely identify the rows
	- Creates indexes for quicker data retrieval
	- Provides a virtual table creation in which sensitive data can be stored and simplified query can be applied.(views)
	- Sharing a common column in two or more tables(primary key and foreign key)
	- Provides multi user accessibility that can be controlled by individual users
	
1.  Define what is "table" in database terms.

	- The data in RDBMS is stored in database objects called tables. The table is a collection of related data entries and it consists of columns and rows. A table is the most common and simplest form of data storage in a relational database

1.  Explain the difference between a primary and a foreign key.

	- Primary key uniquely identify a record in the table.	- Foreign key is a field in the table that is primary key in another table.
	- Primary Key can't accept null values.	- Foreign key can accept multiple - null value.
	- By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index.	- Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
	- We can have only one Primary key in a table. -	We can have more than one foreign key in a table.
	
1.  Explain the different kinds of relationships between tables in relational databases.

	- One-to-one: Both tables can have only one record on either side of the relationship. Each primary key value relates to only one (or no) record in the related table. They're like spouses—you may or may not be married, but if you are, both you and your spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.

	- One-to-many: The primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.

	- Many-to-many: Each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship
	
1.  When is a certain database schema normalized?
  * What are the advantages of normalized databases?
	  * Database normalization is a series of steps followed to obtain a database design that allows for consistent storage and efficient access of data in a relational database .These steps reduce data redundancy and the risk of data becoming inconsistent
  
1.  What are database integrity constraints and when are they used?

	Integrity constraints provide a mechanism for ensuring that data conforms to guidelines specified by the database administrator. The most common types of constraints include:

	- UNIQUE constraints
	
		- To ensure that a given column is unique
	
	- NOT NULL constraints
	
		- To ensure that no null values are allowed
	
	- FOREIGN KEY constraints
	
		- To ensure that two keys share a primary key to foreign key relationship
	
	Constraints can be used for these purposes in a data warehouse:
	
	- Data cleanliness
	
		- Constraints verify that the data in the data warehouse conforms to a basic level of data consistency and correctness, preventing the introduction of dirty data.
	
	- Query optimization
	
		- The Oracle Database utilizes constraints when optimizing SQL queries. Although constraints can be useful in many aspects of query optimization, constraints are particularly important for query rewrite of materialized views.
	
	Unlike data in many relational database environments, data in a data warehouse is typically added or modified under controlled circumstances during the extraction, transformation, and loading (ETL) process. Multiple users normally do not update the data warehouse directly, as they do in an OLTP system.

1.  Point out the pros and cons of using indexes in a database.

	- Advantages: use an index for quick access to a database table specific information. The index is a structure of the database table the value of one or more columns to sort
As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table. The index take up disk space and reduce to add, delete, and update the line speed. In most cases, the speed advantages of indexes for data retrieval greatly exceeds it. 

	- Disadvantages: too index will affect the speed of update and insert, because it requires the same update each index file. For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes. In some cases, the indexing words may not be fast, for example, the index is placed in a contiguous memory space, which will increase the burden of disk read, which is optimal, it should be through the actual use of the environment to be tested.


1.  What's the main purpose of the SQL language?

	- SQL is short for Structured Query Language. It is a standard programming language used in the management of data stored in a relational database management system. It supports distributed databases, offering users great flexibility

1.  What are transactions used for?
  * Give an example
  
		- There are following commands used to control transactions:

			COMMIT: to save the changes.
				
				SQL> DELETE FROM CUSTOMERS
				     WHERE AGE = 25;
				SQL> COMMIT;
			
			ROLLBACK: to rollback the changes.
			
				SQL> DELETE FROM CUSTOMERS
 					 WHERE AGE = 25;
				SQL> ROLLBACK;

			SAVEPOINT: creates points within groups of transactions in which to ROLLBACK

				SQL> SAVEPOINT SP1;
				Savepoint created.
				SQL> DELETE FROM CUSTOMERS WHERE ID=1;
				1 row deleted.
				SQL> SAVEPOINT SP2;
				Savepoint created.
               
			SET TRANSACTION: Places a name on a transaction.

				SET TRANSACTION [ READ WRITE | READ ONLY ];

1.  What is a NoSQL database?
	- Not using the relational model
	- Running well on clusters
	- Mostly open-source
	- Built for the 21st century web estates
	- Schema-less
	
1.  Explain the classical non-relational data models.

	- Key-values Stores

	The main idea here is using a hash table where there is a unique key and a pointer to a particular item of data. The Key/value model is the simplest and easiest to implement. But it is inefficient when you are only interested in querying or updating part of a value, among other disadvantages.

	Examples: Tokyo Cabinet/Tyrant, Redis, Voldemort, Oracle BDB, Amazon SimpleDB, Riak

	- Column Family Stores

	These were created to store and process very large amounts of data distributed over many machines. There are still keys but they point to multiple columns. The columns are arranged by column family.

	Examples: Cassandra, HBase

	- Document Databases

	These were inspired by Lotus Notes and are similar to key-value stores. The model is basically versioned documents that are collections of other key-value collections. The semi-structured documents are stored in formats like JSON. Document databases are essentially the next level of Key/value, allowing nested values associated with each key.  Document databases support querying more efficiently.

	Examples: CouchDB, MongoDb

	- Graph Databases

	Instead of tables of rows and columns and the rigid structure of SQL, a flexible graph model is used which, again, can scale across multiple machines. NoSQL databases do not provide a high-level declarative query language like SQL to avoid overtime in processing. Rather, querying these databases is data-model specific. Many of the NoSQL platforms allow for RESTful interfaces to the data, while other offer query APIs.
	
1.  Give few examples of NoSQL databases and their pros and cons.

	- MongoDB

	Mongodb is one of the most popular document based NoSQL database as it stores data in JSON like documents. It is non-relational database with dynamic schema. It has been developed by the founders of DoubleClick, written in C++ and is currently being used by some big companies like The New York Times, Craigslist, MTV Networks. The following are some of MongoDB benefits and strengths:

		- Speed
		- Scalability
		- Manageable
		- Dynamic Schema
		
	- CouchDB

	CouchDB is also a document based NoSQL database. It stores data in form of JSON documents. The following are some of CouchDB benefits and strengths:

		- Schema-less
		- HTTP query
		- Conflict Resolution
		- Easy Replication

	- Redis

	Redis is another Open Source NoSQL database which is mainly used because of its lightening speed. It is written in ANSI C language. The following are some of Redis benefits and strengths:

		- Data structures
		- Redis as Cache
		- Very fast