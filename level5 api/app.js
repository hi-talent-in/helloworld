const express = require('express');
const app = express();

const port = 8080;

app.get('/',(req,res)=>{
    let name = req.query['name'];
    console.log(name)
    if(name.length>0)
    {
        res.send(`<h1>Hello ${name}!</h1>`)
    }
     res.send(`Hello World!`);
     console.log("In app");
})

app.listen(port, ()=>{
    console.log(`App started succesfully at port ${port}`);
})