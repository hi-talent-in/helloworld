const express = require('express');
const app = express();

const port = 8000;

app.get('/helloworld', (req, res)=>{
    let name = req.query['name'];
    if(name) {
        res.send("Hello >" + name + "!");
        console.log("parameter name: " + name + " entered.");
    }
    else {
        res.send("Hello world!");
        console.log("parameter name is empty!");
    }
})

app.listen(port, ()=>{
    console.log('Server is live at port: ' + port);
})