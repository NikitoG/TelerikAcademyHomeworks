/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person;
	Person = (function () {
		function Person(firstName, lastName, age) {
			var obj = this;
			if (arguments.length < 3) {
				throw new Error();
			}
			function validateNames(name) {
				if (name.length < 3 || name.length > 20) {
					throw  new Error();
				}
			}

			validateNames(firstName);
			validateNames(lastName);

			if (age < 0 || age > 150) {
				throw new Error();
			}

			this.firstname = firstName;
			this.lastname = lastName;
			this.age = +age;


			Object.defineProperty(obj, 'fullname', {
				get: function () {
					return (obj.firstname + ' ' + obj.lastname)
				},
				set: function (newValue) {
					var temp = newValue.split(' ');
					obj.firstname = temp[0];
					obj.lastname = temp[1];
				}
			});
		}

		Person.prototype.introduce = function () {
			return ('Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old');
		};

		return Person;
	}());
	return Person;
}
module.exports = solve;