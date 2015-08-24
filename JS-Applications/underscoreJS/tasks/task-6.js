/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has propeties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (books) {
        var groupedByAuthor = _.chain(books)
            .groupBy(function (book) {
                return book.author.firstName + ' ' + book.author.lastName;
            })
            .value();

        var biggestNumberBooks = _.max(groupedByAuthor, 'length').length;

        var authorsWithBiggestNumberBooks = _.chain(groupedByAuthor)
            .filter(function(books, author) {
                return books.length === biggestNumberBooks
            })
            .map(function(book) {
                return book[0].author.firstName + ' ' + book[0].author.lastName;
            })
            .sortBy()
            .each(function(author) {
                console.log(author);
            })
            .value();
    };
}
module.exports = solve;
