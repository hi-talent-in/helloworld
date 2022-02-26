const express = require('express');


const PORT = 8000;
const HOST = 'localhost';

const app = express()

app.get('/', (req, res) => {
    res.send('hello_world!');
});

app.listen(PORT, HOST);
    console.log(`Run api on http://${HOST}:${PORT}`);

