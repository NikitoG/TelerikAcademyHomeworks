/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName` and `lastName` properties
 *   **Finds** all students whose `firstName` is before their `lastName` alphabetically
 *   Then **sorts** them in descending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   Then **prints** the fullname of founded students to the console
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (students) {

        function findStudentsWhoseFirstNameISBeforeLastName (student) {
            return student.firstName < student.lastName;
        }

        function setFullName(student) {
            return student.fullname = student.firstName + ' ' + student.lastName;
        }

        function printFullName(student) {
            console.log(student.fullname);
        }

        var result = _.chain(students)
            .filter(findStudentsWhoseFirstNameISBeforeLastName)
            .each(setFullName)
            .sortBy('fullname')
            .reverse()
            .each(printFullName)
            .value();
    };
}

/*var result = solve();
var students = [
    {firstName: 'Nikolay', lastName:'Georgiev'},
    {firstName: 'Ana', lastName:'Todorova'},
    {firstName: 'Kaloyan', lastName:'Vylkov'},
    {firstName: 'Doncho', lastName:'Minkov'},
    {firstName: 'Ivylo', lastName:'Kenov'}
];

result(students);*/

module.exports = solve;