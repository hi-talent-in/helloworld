const express = require('express');
const jwt = require('jsonwebtoken');

const app  = express();

app.get('/api/', (req, res) => {
    res.json({
        message: 'Welcome to the WebPage'
    });
});

app.listen(5000, () => console.log('Server started on port 5000'));