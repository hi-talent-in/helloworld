const express = require('express');
const app = express();

const host = '127.0.0.1';
const port = 80;

app.get('/',(req,res)=>{
    res.send("Hello World!");
})

app.listen(port, ()=>{
    console.log(`App started succesfully at ${host}:${port}`);
})

