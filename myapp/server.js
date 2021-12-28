const express = require('express');

const PORT = 8080;

const app = express();

app.get('/', (req, res) => {
    res.send('Hello World Rush First Docker AppS');
});

app.listen(PORT);
console.log('Running on port ${PORT}');