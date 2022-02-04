const express = require('express');
const app = express();

const host = '127.0.0.1';
const port = 3000;

app.get('/',(req,res)=>{
    let name = req.query['name'];
    console.log(name)
    if(name.length>0)
    {
        res.send(`<h1>Hello ${name}!</h1>`)
    }
    res.send(`<h1>Hello World!</h1>`);
})

app.listen(port, ()=>{
    console.log(`App started succesfully at ${host}:${port}`);
})

