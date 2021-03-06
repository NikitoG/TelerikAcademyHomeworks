var chatDb = require('./chat-db');
//inserts a new user records into the DB
chatDb.registerUser({user: 'NikolayKostov', pass: '123456q'});
//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'NikolayKostov',
    to: 'DonchoMinkov',
    text: 'How are you!'
});
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov'
});