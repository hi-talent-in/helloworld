const express = require('express');
const app = express();

const port = 3000;

app.get('/', (req, res)=>{
    let name = req.query['name'];
    if(name) {
        res.send("Heloo " + name + "!");
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