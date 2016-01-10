(function(){
    "use strict";
    var mongoose = require('mongoose');

    var Schema = mongoose.Schema;
    var userSchema = new Schema({
        user: {
            type: String,
            required: true
        },
        pass: {
            type: String,
            required: true
        }
    });

    var minPassLength = 6,
        minUserNameLength = 3;

    userSchema.statics.uniqueUsername = function (username, callback) {
        User.find()
            .where('user').equals(username)
            .exec(function (err, users) {
                if (err) throw err;
                if (users.length !== 0) {
                    throw {
                        message: 'Username already exists'
                    };
                }
                callback();
            });
    };

    userSchema.statics.userExist = function (username, callback) {
        User.find()
            .where('user').equals(username)
            .exec(function (err, users) {
                if (err) throw err;
                if (users.length === 0) {
                    throw {
                        message: 'Username does not exists'
                    };
                }
                callback();
            });
    };

    userSchema.path('user').validate(function(value) {
        return value.length >=minUserNameLength;
    });

    userSchema.path('pass').validate(function(value) {
        return value.length >=minPassLength;
    });

    var User = mongoose.model('User', userSchema);

    module.exports = User;
}());