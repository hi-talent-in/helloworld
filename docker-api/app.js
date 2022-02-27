const express = require('express');


const PORT = 8000;
const HOST = 'localhost';

const app = express()

app.get('/hello_world', (req, res) => {
    res.send('hello world!');
})

app.get('/', (req, res) => {
    res.send('hello world! from base url');
})

app.listen(PORT, ()=>{
    console.log(`Run api on port ${PORT}`);
})
    

