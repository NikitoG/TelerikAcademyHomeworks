/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName`, `lastName` and `age` properties
 *   **finds** the students whose age is between 18 and 24
 *   **prints**  the fullname of found students, sorted lexicographically ascending
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (students) {
        function findStudentsWithAgeBetween18And24(student) {
            return student.age >= 18 && student.age <= 24;
        }

        function printFullName(student) {
            var fullName = student.firstName + ' ' + student.lastName;
            console.log(fullName);
        }

        var result = _.chain(students)
            .filter(findStudentsWithAgeBetween18And24)
            .sortBy('lastName')
            .sortBy('firstName')
            .each(printFullName)
            .value();
    };
}

module.exports = solve;
