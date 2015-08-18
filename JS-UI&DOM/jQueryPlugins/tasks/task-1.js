function solve() {
    return function (selector) {
        /*(function($){
            $.fn.dropdownList = function () {*/
                var $this = $(selector),
                    i,
                    len,
                    $options,
                    $dropDownList,
                    $dropDownItem,
                    $currentDiv,
                    $optionsContainer;
                $this.css('display', 'none');

                $dropDownList = $('<div />')
                    .addClass('dropdown-list')
                    .append($this)
                    .appendTo($('body'));

                //$('h1').after($dropDownList);

                $currentDiv = $('<div />')
                    .addClass('current')
                    .text('Option 1')
                    .appendTo($dropDownList);

                $optionsContainer = $('<div />')
                    .addClass('options-container')
                    .css({
                        'position': 'absolute',
                        'display': 'none'
                    });

                $options = $('option');

                for (i = 0, len = $options.length; i < len; i+=1) {
                    $dropDownItem = $('<div />')
                        .addClass('dropdown-item')
                        .attr('data-value', $($options[i]).attr('value'))
                        .attr('data-index', i)
                        .text($($options[i]).text())
                        .appendTo($optionsContainer);
                }

                $dropDownList.append($optionsContainer);

                $currentDiv.on('click', function(){
                    $currentDiv.text('Select a value');
                    $optionsContainer.css('display', '');
                });

                $optionsContainer.on('click', 'div', function(ev) {
                    $this.val($(this).attr('data-value'));
                    var clickedElement = ev.target;
                    $currentDiv.text($(clickedElement).text());
                    $optionsContainer.css({
                        'display': 'none'});

                });
/*
                return $this;
            };
        }(jQuery));

        $(selector).dropdownList();*/
    };
}

module.exports = solve;