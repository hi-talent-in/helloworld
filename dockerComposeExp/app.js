const express = require('express');
const mysql = require('mysql');
const app = express();

require('dotenv').config();

// const database = mysql.createConnection({
//     host: 'localhost',
//     user: 'root',
//     password: 'password',
//     database: 'entry_dtb'
// });

const database = mysql.createConnection({
    host: 'mysql_server',
    user: 'abhi',
    password: 'dbpass',
    database: 'entry_dtb'
});

app.get('/',(req,res)=>{
    let name = req.query['name'];
    console.log(name)
    if(name.length>0)
    {
        let mainres;
        res.send(`<h1>Hello ${name}!</h1>`)
        const sqlQuery =  'CREATE TABLE IF NOT EXISTS Entries(id int AUTO_INCREMENT, name VARCHAR(50), count int, PRIMARY KEY(id))';
        let insertQuery = 'INSERT INTO Entries (name,count)values (?,?)';
        let updtQuery = 'update Entries set count = count+1 where name=?';
        let checkQuery = 'SELECT * FROM Entries WHERE name = ?';

        database.query(sqlQuery, (err,result)=>{
            if(err) console.log(err);
            console.log("Database created Successfully");
        })
        
        database.query(checkQuery,[name], (err, result)=>{
            if(err) throw err;
            console.log(result);
            if(result.length>0)
            {
                database.query(updtQuery,[name], (err,result)=>{
                    if(err) throw err;
                    else{
                        console.log("Found this member in db... Updated count")
                    }
                })
            }
            else
            {
                database.query(insertQuery,[name,1], (err,result)=>{
                    if(err) throw err;
                    else
                    {
                        console.log("Found new member and added to database");
                    }
                })
            }
        })

    }

    res.send(`Hello World!`);



    console.log("In app");
})


app.listen(3000, ()=>{
    console.log(`App started succesfully at port ${3000}`);
})
