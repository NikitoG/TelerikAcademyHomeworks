(function(){
    "use strict";
    var mongoose = require('mongoose');
    var fs = require('fs');

    var models_path = __dirname + '/models';
    fs.readdirSync(models_path).forEach(function (file) {
        if (~file.indexOf('.js')) require(models_path + '/' + file)
    });

    var User = mongoose.model('User'),
        Message = mongoose.model('Message');

    mongoose.connect('mongodb://localhost/chat');

    function registerUser(user){
        if(!user || typeof user !== 'object') {
            console.log('Invalid User!');
            return;
        }

        let newUser = new User(user);
        newUser.save(function(err, createdUser) {
            if(err) {
                return console.error(err);
            }

            console.log(`${createdUser} created successfully!`);
        })
    }

    function sendMessage(message){
        if(!message || typeof message !== 'object') {
            console.log('Invalid message!');
            return;
        }

        let newMessage = new Message(message);
        newMessage.save(function(err, createdMessage) {
            if(err) {
                return console.error(err);
            }

            console.log(`${createdMessage} sent successfully!`);
        })


    }

    function getMessages(chat){
        if(!chat || typeof chat !== 'object' || !chat.with || !chat.and) {
            console.log('Invalid members!');
            return;
        }

        return Message.find()
            .where('from').in([chat.with, chat.and])
            .where('to').in([chat.with, chat.and])
            .exec(function(err, allMessages){
                if(err){
                    console.log(err);
                    return
                }

                allMessages.forEach(function(mess) {
                    console.log(mess.text);
                })
            })
    }

    module .exports = {
        registerUser,
        sendMessage,
        getMessages
    };
}());