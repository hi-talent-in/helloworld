const express = require('express');
const mysql = require('mysql');


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
const table = 'CREATE TABLE IF NOT EXISTS Logs(id int AUTO_INCREMENT, name VARCHAR(50), count int, PRIMARY KEY(id))';
console.log("working with docker-compose to use database with app");

let insert = 'INSERT INTO Logs(name,count) values (?,?)';
let update = 'update Logs set count = count+1 where name=?';
let getlogs = 'SELECT * FROM Logs WHERE name = ?';

const app = express();

app.get('/', (req, res) => {
    let name = req.query['name'];
    if (name) {
        res.send(`Hello ${name}!`);

        // check wether it already exeiest or not
        db.query(getlogs,[name], (err, result) => {
            if (err) throw err;
            console.log(result);
            if (result.length>0) {
                db.query(update, [name], (err, result) => {
                    if (err) throw err;
                    else console.log("log is already exiest, count updated")
                });
            }
            else {
                db.query(insert, [name, 1], (err, result) => {
                    if (err) throw err;
                    else console.log("It's new log, added to database");
                });
            }
        });
    }
    else {
        res.send("Hello world!");
        console.log("parameter name is empty!");
    }
});

const port = 3000;
app.listen(port, () => {
    console.log(`Server is live at port: ${port}`);
})