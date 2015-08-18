/* globals $ */

function solve() {

    return function (selector) {

        var template = '<table class="items-table">' +
                            '<thead>'+
                                '<tr>'+
                                    '<th>#</th>'+
                                    '{{#headers}}'+
                                    '<th>{{this}}</th>'+
                                    '{{/headers}}'+
                                '</tr>'+
                            '</thead>'+
                            '<tbody>'+
                                '{{#each items}}'+
                                '<tr>'+
                                    '<td>{{@index}}</td>'+
                                    '<td>{{col1}}</td>'+
                                    '<td>{{col2}}</td>'+
                                    '<td>{{col3}}</td>'+
                                '</tr>'+
                                '{{/ each}}'+
                            '</tbody>'+
                        '</table>';
         $(selector).html(template);
    };
};

module.exports = solve;