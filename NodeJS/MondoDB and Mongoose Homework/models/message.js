(function(){
    "use strict";
    var mongoose = require('mongoose');
    var Schema = mongoose.Schema;
    var messageSchema = new Schema({
        from: {
            type: String,
            required: true
        },
        to: {
            type: String,
            required: true
        },
        text: {
            type: String,
            required: true
        }
    });

    var Message = mongoose.model('Message', messageSchema);

    module.exports = Message;
}());