const express = require('express');
const redis = require('redis');

const client = redis.createClient({
    port: 6379,
    host: 'redis'
});
client.connect();
client.on('connect', (err)=>{
    if(err) throw err;
    else console.log('Redis Connected..!');
});

const app = express();
app.get('/',async (req,res)=>{
    let key = req.query['name'];
    if(key){
        let value = await client.get(key);
        if(value){
            value++;
            client.set(key,value);
            res.send(`Hello ${key}, ${value}!`);
            console.log(`${key}, ${value}`);
        }
        else{
            value = 1;
            client.set(key,value); 
            res.send(`Hello ${key}, ${value}!`);
            console.log(`${key}, ${value}`);
        }
    }
    else{
        console.log("Name not passed!");
        res.send("Hello World!");
    }
});
const port = 3000;
app.listen(port,()=>{
    console.log(`App is listening at http://localhost:${port}`);
});