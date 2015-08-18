/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var books = [];
        var categories = [];
        var booksByAuthor = {};

        function validation(book) {
            function validatedLenght(nameProp) {
                if (nameProp.length < 2 || nameProp.length > 100) {
                    throw new Error();
                }
            }

            validatedLenght(book.category);
            validatedLenght(book.title);
            if (book.isbn.length != 10 && book.isbn.length != 13) {
                throw new Error();
            }

            if (!(book.author.trim().length)) {
                throw new Error();
            }


            var checkTitle = books.some(function (item) {
                return (item.title == book.title)
            });
            if (checkTitle) {
                throw new Error();
            }
            var checkIsbn = books.some(function (item) {
                return (item.isbn == book.isbn)
            });
            if (checkIsbn) {
                throw new Error();
            }
        }

        function listBooks(obj) {
            if (!arguments.length) {
                return books.sort(function (a, b) {
                    return a.ID - b.ID;
                });
            }

            if (obj.category !== 'undefined') {
                if (!categories[obj.category]) {
                    return [];
                }
                return categories[obj.category].books;
            }

            if (obj.author !== 'undefined') {
                if (!booksByAuthor[obj.author]) {
                    return booksByAuthor[obj.author] = [];
                }
                return booksByAuthor[obj.author];
            }
        }

        function addBook(book) {
            validation(book);
            if (!categories[book.category]) {
                addCategories(book.category);
            }
            categories[book.category].books.push(book);

            if (!booksByAuthor[book.author]) {
                booksByAuthor[book.author] = [];
            }
            booksByAuthor[book.author].push(book);

            book.ID = books.length + 1;
            books.push(book);
            return book;
        }

        function addCategories(name) {
            categories[name] = {
                books: [],
                ID: categories.length + 1
            }
        }

        function listCategories() {
            function sortByKeys(obj) {
                var keys = [];

                for (var key in obj) {
                    if (obj.hasOwnProperty(key)) {
                        keys.push(key);
                    }
                }

                return keys;
            }

            return sortByKeys(categories);
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}
module.exports = solve;
