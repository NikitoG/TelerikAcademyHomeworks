/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	function validateTitle(nameOfCourse) {
		var regex = /[\s]{2,}/;

		if (nameOfCourse.trim() == '') {
			throw new Error('Title must start and end with symbols different of white space, and have at least one character!');
		}
		if (regex.test(nameOfCourse)) {
			throw new Error('Title must start and end with symbols different of white space, and have at least one character!');
		}
		if (nameOfCourse[0] === ' ' || nameOfCourse[nameOfCourse.length - 1] === ' ') {
			throw new Error('Title must start and end with symbols different of white space, and have at least one character!');
		}

	}

	function validatePresentations(listOfPresentations) {
		if (!listOfPresentations.length) {
			throw new Error('Course must have at least 1 presentation!')
		}
		listOfPresentations.forEach(function (item) {
			validateTitle(item);
		})
	}

	function validateNames(name) {
		var i, len;

		if (typeof name === 'undefined') {
			throw new Error('Invalid name!');
		}
		if (name[0] !== name[0].toUpperCase()) {
			throw new Error('Invalid name!');
		}
		for (i = 1, len = name.length; i < len; i += 1) {
			if (name[i] !== name[i].toLowerCase()) {
				throw new Error('Invalid name!');
			}
		}
	}

	var Course = {
		init: function (title, presentations) {
			this.title = title;
			this.presentations = presentations;
			this.students = [];
			return this;
		},
		addStudent: function (name) {
			var fullName = name.split(' ');
			if (fullName.length > 2) {
				throw new Error('Student must have exactly two names!')
			}
			var firstName = fullName[0];
			var lastName = fullName[1];
			var id;

			validateNames(firstName);
			validateNames(lastName);

			id = this.students.length + 1;

			this.students.push({
				firstname: firstName,
				lastname: lastName,
				homeworks: [],
				score: 0,
				id: id,
				get result() {
					var maxScore = 10,
						numberOfHomeworks = this.presentations.length,
						result = 0;
					result += ((this.students.score / maxScore) * 75 / 100);
					result += ((this.students.homeworks.length / numberOfHomeworks) * 25 / 100);

				}
			});

			return id;
		},
		getAllStudents: function () {
			return this.students.slice();
		},
		submitHomework: function (studentID, homeworkID) {
			if (studentID <= 0 || studentID > this.students.length) {
				throw new Error('Invalid student ID!')
			}
			if (homeworkID <= 0 || homeworkID > this.presentations.length) {
				throw new Error('Invalid student ID!')
			}
			this.students[studentID - 1].homeworks.push(homeworkID);
		},
		pushExamResults: function (results) {
			var i,
				j,
				len,
				score,
				studentID;

			if (!(results instanceof Array)) {
				throw new Error('Must be an Array!')
			}

			for (i = 0, len = results.length; i < len; i += 1) {
				score = +results[i].Score;
				studentID = results[i].StudentID;
				if (studentID <= 0 || studentID > this.students.length) {
					throw new Error('Invalid student ID!')
				}
				if (score !== 0 && !score) {
					throw new Error('Score is not a number!');
				}
				for (j = i; j < len; j += 1) {
					if (studentID === results[j].StudentID) {
						throw new Error('He tried to cheat!');
					}
				}
				this.students[studentID - 1].score = score;
			}
		},
		getTopStudents: function () {
			return this.students.sort(function (a, b) {
				return a.result - b.result;
			}).slice(0, 9);
		}
	};


	Object.defineProperties(Course, {
		title: {
			get: function () {
				return Course._title;
			},
			set: function (value) {
				validateTitle(value);
				Course._title = value;
			}
		},
		presentations: {
			get: function () {
				return Course._presentations;
			},
			set: function (value) {
				validatePresentations(value);
				Course._presentations = value;
			}
		}
	});

	return Course;
}


module.exports = solve;
