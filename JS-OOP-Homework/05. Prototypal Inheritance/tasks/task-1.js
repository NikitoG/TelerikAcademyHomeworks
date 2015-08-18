/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * method removeAttribute(attribute)
 * throw Error if attribute does not exist in the domElement
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */

function solve() {
    var domElement = (function () {
        function sortBykeys(obj) {
            var i,
                len,
                sortedObj = {},
                keys = [];

            for (var key in obj) {
                if (obj.hasOwnProperty(key)) {
                    keys.push(key);
                }
            }

            keys = keys.sort();

            for (i = 0, len = keys.length; i < len; i += 1) {
                sortedObj[keys[i]] = obj[keys[i]];
            }

            return sortedObj;
        }

        function getAttribute(obj) {
            var attrs = '';
            if (obj.attribute) {
                var sortedAttribute = sortBykeys(obj.attribute);
                for (var key in sortedAttribute) {
                    if (typeof sortedAttribute[key] != 'undefined') {
                        attrs += ' ' + key + '=' + '"' + sortedAttribute[key] + '"';
                    }

                }
            }

            return attrs;
        }

        function appendChild(obj) {
            var i,
                len,
                child = '';

            for (i = 0, len = obj.children.length; i < len; i += 1) {
                if (typeof obj.children[i] === 'string') {
                    child += obj.children[i];
                } else {
                    child += obj.children[i].innerHTML;
                }
            }

            return child;
        }

        var domElement = {
            init: function (type) {
                this.type = type;
                this.children = [];
                this.content = '';
                return this;
            },
            appendChild: function (child) {
                if (typeof child === 'object') {
                    child.parent = this;
                }
                this.children.push(child);
                return this;
            },
            addAttribute: function (name, value) {
                var regex = /^[\w-]+$/;
                if (!regex.test(name)) {
                    throw new Error('Type must be at least one symbol and contains only digit and letters!');
                }

                if (!this.attribute) {
                    this.attribute = {};
                }
                this.attribute[name] = value;

                return this;
            },
            removeAttribute: function (name) {
                if (!this.attribute[name]) {
                    throw new Error('Attribute with this name not exist!');
                }
                this.attribute[name] = undefined;

                return this;
            },
            get type() {
                return this._type
            },
            set type(value) {
                var regex = /^\w+$/;
                if (!regex.test(value) || !(typeof value == 'string')) {
                    throw new Error('Type must be at least one symbol and contains only digit and letters!');
                }

                this._type = value;
            },
            get content() {
                if (this.children.length) {
                    return '';
                }

                return this._content;
            },
            set content(value) {
                this._content = value;
            },
            get innerHTML() {
                var tag = '';

                tag += '<' + this.type + getAttribute(this) + '>';
                tag += appendChild(this);
                tag += this.content;
                tag += '</' + this.type + '>';

                return tag;
            }
        };
        return domElement;
    }());
    return domElement;
}


module.exports = solve;
