(function(){
    'use strict';

    function getExtension(fileName) {
        return fileName.substring(fileName.lastIndexOf('.'));
    }

    var http = require('http'),
        path = require('path'),
        fs = require('fs'),
        uuid = require('node-uuid'),
        jade = require('jade'),
        port = 9876,
        pathUpload = '../files';

    var Busboy = require('busboy');

    http.createServer(function(req, res){
        switch(req.url) {
            case '/':
                homePage(req, res);
                break;
            case '/upload':
                uploadPage(req, res);
                break;
            case '/all':
                listAllFiles(req, res);
                break;
            default:
                var splitUrl = req.url.split('/');
                if ((splitUrl[1] === 'files') && (splitUrl.length === 3)) {
                    downloadFile(req, res, splitUrl);
                } else {
                    res.writeHead(303, { Connection: 'close', Location: '/' });
                    res.end();
                }
        }
    }).listen(port);

    function homePage(req, res) {
        fs.readFile('../views/home.html', function(error, html){
            if(error) {
                console.log(error);
            } else {
                res.writeHead(200, { 'content-type': 'text/html' });
                res.end(html);
            }
        });
    }

    function uploadPage(req, res) {
        if(req.method.toLowerCase() === 'post')
        {
            if (req.method === 'POST') {
                var busboy = new Busboy({ headers: req.headers });
                busboy.on('file', function(fieldname, file, filename, encoding, mimetype) {
                    var name = uuid.v1() + getExtension(filename),
                        saveTo = path.join(pathUpload, path.basename(name));
                    file.pipe(fs.createWriteStream(saveTo));
                });
                busboy.on('finish', function() {
                    res.writeHead(303, { Connection: 'close', Location: '/all' });
                    res.end();
                });
                return req.pipe(busboy);
            }
            res.writeHead(404);
            res.end();
        } else {
            fs.readFile('../views/upload.html', function(error, html){
                if(error) {
                    console.log(error);
                } else {
                    res.writeHead(200, { 'content-type': 'text/html' });
                    res.end(html);
                }
            });
        }
    }

    function listAllFiles(req, res) {
        fs.readFile('../views/all.jade', function (err, jadeFile) {
            if(err) {
                res.end(err);
                return;
            }

            fs.readdir('../files/', function (error, files) {
                if(error) {
                    res.end(error);
                    return;
                }

                var output = jade.compile(jadeFile)({
                    files: files.map(f => f.split('.')[0])
                });

                res.end(output);
            })
        });
    }

    function downloadFile(req, res, splitUrl){
        var fileName = splitUrl[2];

        fs.readdir('../files/', function (err, files) {

            for (var i = 0, len = files.length; i < len; i += 1) {
                var splitFileName = files[i].split('.');

                if (fileName === splitFileName[0]) {
                    res.writeHead(200, {
                        'Content-Disposition': `attachment; filename=${files[i]};`
                    });

                    let readStream = fs.createReadStream(`../files/${files[i]}`);
                    readStream.pipe(res);
                    return;

                }
            }

            res.end('<p>File not found!</p>');

        });
    }

    console.log('Server is running on port ' + port);
}());