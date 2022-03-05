const express = require('express');

const app = express();
const port = 8000;

app.listen(port,() => {
    console.log('listen run on port 8000');
})
//create api 
app.get('/hello_world',(req,res) =>{
    res.send('Hello World!');
})