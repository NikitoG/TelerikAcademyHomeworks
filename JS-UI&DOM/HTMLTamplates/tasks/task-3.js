function solve() {
    return function () {
        $.fn.listview = function (data) {
            var $this = $(this),
                i,
                len,
                templateSelector,
                postTemplateHTML,
                postTemplate;

            templateSelector = '#' + $this.attr('data-template');
            postTemplateHTML = $(templateSelector).html();
            postTemplate = handlebars.compile(postTemplateHTML);

            for (i = 0, len = data.length; i < len; i += 1) {
                $this.append(postTemplate(data[i]));
            }

            return this;
        };
    };
}

module.exports = solve;