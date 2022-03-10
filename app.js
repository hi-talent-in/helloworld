const express = require("express");
const app = express();
const path = require("path");
const name = require("./name");
const PORT = process.env.PORT || 3000;

/*
app.get("/api/name", (req, res) => {
  res.json(name);
});
*/
/*app.get('/api/name/:names',(req,res) =>{

  let val =  name.filter(name=>name.names===req.params.names)
    res.json("Hello "+ val[0].names);
   
});
*/
app.get('/api/helloworld/',(req , res) => {
  const found = name.filter(name=>name.names===req.query.names);
  if (found.length===1){
    res.json("Hello  "+  found[0].names)
  }else{
    res.json('Hello World');
  }
});
//Routes
app.get("/", (req, res) => {
  res.send("HelloWorld");
});
//listening server
app.listen(PORT, () => console.log(`server started on port ${PORT} `));

//connect to db
//const mongoose =require('mongoose');
/*mongoose.connect('mongodb+srv://komalpathak:komal@123@cluster0.ibe3r.mongodb.net/myFirstDatabase?retryWrites=true&w=majority' ,
() => console.log('connected to db'));*/
