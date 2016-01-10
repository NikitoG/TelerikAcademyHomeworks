(function(){
    "use strict";
    var http = require('http'),
        path = require('path'),
        fs = require('fs'),
        jade = require('jade'),
        data = require('./data'),
        port = 4488;

    http.createServer(function(req, res){
        switch(req.url.toLowerCase()) {
            case '/':
                homePage(req, res);
                break;
            case '/phones':
                phonesPage(req, res);
                break;
            case '/tablets':
                tabletsPage(req, res);
                break;
            case '/wearables':
                wearablesPage(req, res);
                break;
            default:
                res.writeHead(303, { Connection: 'close', Location: '/' });
                res.end();
        }
    }).listen(port);

    function pageRender(req, res, pathTemplate, model) {
        pathTemplate = './views/' + pathTemplate;
            fs.readFile(pathTemplate, 'utf-8', function (err, jadeFile) {
                if(err) {
                    res.end(err);
                } else {
                    var template = jade.compile(jadeFile, {
                        filename: pathTemplate
                    });

                    model = model || {};
                    var output = template(model);

                    res.end(output);
                }
        });
    }

    function homePage(req, res) {
        let pathTemplate = 'home.jade';
        pageRender(req, res, pathTemplate);
    }

    function phonesPage(req, res) {
        let pathTemplate = 'phones.jade';
        pageRender(req, res, pathTemplate, data);
    }

    function tabletsPage(req, res) {
        let pathTemplate = 'tablets.jade';
        pageRender(req, res, pathTemplate, data);
    }

    function wearablesPage(req, res) {
        let pathTemplate = 'wearables.jade';
        pageRender(req, res, pathTemplate, data);
    }

    console.log('Server is running on port ' + port);
}());