/* globals $ */

/*
 Create a function that takes a selector and:
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
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {
    return function (selector) {
        var $selectedElement = $(selector),
            $buttons = $selectedElement
                .find('.button')
                .text('hide');

        if (typeof selector !== 'string') {
            throw new Error('Selector must be a string!');
        }

        if (!$selectedElement.size()) {
            throw new Error('Selector does not match any element!');
        }

        $selectedElement.on('click', '.button', onClickEvent);

        function onClickEvent() {
            var $content,
                $this = $(this);

            $content = $($this.nextUntil('.button', '.content')[0])
                .toggleClass('hidden');

            if ($content.hasClass('hidden')) {
                $content.css('display', 'none');
            } else {
                $content.css('display', '');
            }

            if ($content.size()) {
                $(this).text(function (i, text) {
                    return text === 'hide' ? 'show' : 'hide';
                });
            }
        }
    };
}

module.exports = solve;