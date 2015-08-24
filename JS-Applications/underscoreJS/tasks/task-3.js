/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (students) {
        function getAverageMarks(marks) {
            var averageMArks = _.reduce(marks, function (sum, mark) {
                    return sum + mark;
                }, 0) / marks.length;

            return averageMArks;
        }

        function printInfo(student) {
            var studentInfo = student.firstName + ' ' + student.lastName + ' has an average score of ' + student.averageMark;
            console.log(studentInfo)
        }

        var bestStudent = _.chain(students)
            .map(function (student) {
                student.averageMark = getAverageMarks(student.marks);
                return student;
            })
            .max(function (student) {
                return student.averageMark;
            })
            .value();

        printInfo(bestStudent);
    };
}

module.exports = solve;
