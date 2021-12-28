const express = require('express');

const PORT = 8080;

const app = express();

app.get('/', (req, res) => {
    res.send('This is my USername image(rush27_hello)');
});

app.listen(PORT);
console.log('Running on port ${PORT}');