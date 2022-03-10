const express = require('express');
const mysql = require('mysql');
const redis = require('redis');

// create client
const redisClient = redis.createClient({
    host: 'test-redis',
    port: 6379
  });

// Create connection
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'records'
});

// Connect
db.connect((err) => {
    if (err) throw err;
    console.log('MySql Connected...');
});

// create database
const database = 'CREATE DATABASE IF NOT EXISTS records';
// create table
const table = 'CREATE TABLE IF NOT EXISTS Logs(id int AUTO_INCREMENT, name VARCHAR(50), count int, PRIMARY name(id))';

let insert = 'INSERT INTO Logs(name,count) values (?,?)';
let update = 'update Logs set count = count+1 where name=?';
let getlogs = 'SELECT * FROM Logs WHERE name = ?';

const app = express();

app.get('/', (req, res) => {
    const name = req.query['name'];
    redisClient.get(name, (err, counts) => {
        const countsTodisp = parseInt(counts)+1;
        if(isNaN(countsTodisp)) {
            db.query(getlogs,[name], (err, result)=>{
                if(err) throw err;
                console.log(result);
                if(result.length>0){
                    redisClient.set(name,result[0].count+1);
                    db.query(update,[name], (err,result)=>{
                        if(err) throw err;
                        else console.log("log is already exiest in database, count updated");
                    });
                    res.send(`Hello ${name}! log is already exiest in database and redis, count updated `);
                }
                else{
                    redisClient.set(name,1);
                    db.query(insert,[name,1], (err,result)=>{
                        if(err) throw err;
                        else console.log("It's new log in database, added to database");
                    });
                    res.send(`Hello ${name}! It's new log in database and redis`)
                }
            });
        }
        else{
            res.send(`Hello ${name}! ${countsTodisp} log is already exiest in redis`);
            counts++;
            redisClient.set(name,counts);
            db.query(update,[name], (err,result)=>{
                if(err) throw err;
                else console.log("log is already exiest in database, count updated");
            });       
        }
    });
});

const port = 3000;
app.listen(port, () => {
    console.log(`Server is live at port: ${port}`);
});