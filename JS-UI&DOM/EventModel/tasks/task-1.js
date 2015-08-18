/* globals $ */

/* 
 Create a function that takes an id or DOM element and:
 * If an id is provided, select the element
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided DOM element is non-existant
 * The id is either not a string or does not select any DOM element
 */

function solve() {
    return function (selector) {
        var i,
            len,
            buttons,
            domElement;

        if (selector instanceof HTMLElement) {
            domElement = selector;
        } else if (typeof selector === 'string') {
            domElement = document.getElementById(selector);
        } else {
            throw new Error('Neither a string or DOM element!')
        }

        if (!domElement) {
            throw new Error('Id not selected any DOM element!');
        }

        buttons = domElement.querySelectorAll('.button');

        for (i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
        }

        domElement.addEventListener('click', onClickEvent);

        function onClickEvent(ev) {
            var topmostContent,
                clickedElement = ev.target,
                nextElement = clickedElement.nextElementSibling;

            if(clickedElement.className.indexOf('button') < 0) {
                return;
            }

            while (nextElement && nextElement.className.indexOf('button') < 0) {
                if (nextElement.className.indexOf('content') >= 0) {
                    topmostContent = nextElement;
                }

                nextElement = nextElement.nextElementSibling;
            }

            if (topmostContent) {
                if (topmostContent.style.display === '') {
                    topmostContent.style.display = 'none';
                    clickedElement.innerHTML = 'show';
                } else {
                    topmostContent.style.display = '';
                    clickedElement.innerHTML = 'hide';
                }
            }
        }
    };
}

module.exports = solve;