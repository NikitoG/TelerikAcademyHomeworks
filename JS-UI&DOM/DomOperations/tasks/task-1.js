/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neither `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (element, contents) {
        var i,
            len,
            div,
            cloneElement,
            documentFragment,
            domElement,
            isDomElement = element instanceof HTMLElement;

        if (arguments.length < 2) {
            throw new Error('Any of the function params is missing!')
        }

        if (!(contents instanceof Array)) {
            throw new Error('Any of the function params is not as described!');
        }

        if (isDomElement) {
            domElement = element;
        } else if (typeof element === 'string') {
            domElement = document.getElementById(element);
        } else {
            throw new Error('First parameter is neither string or existing Dom element!');
        }

        if (domElement === null) {
            throw new Error('There is no element that has such an id!')
        }


        div = document.createElement('div');
        documentFragment = document.createDocumentFragment();

        for (i = 0, len = contents.length; i < len; i += 1) {
            if (!(typeof contents[i] === 'number') && !(typeof contents[i] === 'string')) {
                throw new Error('Contents contains not a number or string!')
            }
            cloneElement = div.cloneNode(true);
            cloneElement.innerHTML = contents[i];

            documentFragment.appendChild(cloneElement);
        }

        domElement.innerHTML = '';
        domElement.appendChild(documentFragment);
    };
};


