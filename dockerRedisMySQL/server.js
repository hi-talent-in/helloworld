const express = require('express');
// Import Redis
const redis = require('redis');
//Import Mysql
const mysql = require('mysql');
const app = express();
// 'createClient()' usually takes an URL connection path, or the path of a host to connect to.
// In our case use the name of the service from 'docker-compose.yml', 'test-redis'.
// Redis server itself usually runs on Port '6379'
const redisClient = redis.createClient({
  host: 'test-redis',
  port: 6379
});

const database = mysql.createConnection({
    host: 'mysql_server',
    user: 'abhi',
    password: 'dbpass',
    database: 'entry_dtb'
});

const sqlQuery =  'CREATE TABLE IF NOT EXISTS Entries(id int AUTO_INCREMENT, name VARCHAR(50), count int, PRIMARY KEY(id))';
const insertQuery = 'INSERT INTO Entries (name,count)values (?,?)';
const updtQuery = 'update Entries set count = count+1 where name=?';
const checkQuery = 'SELECT * FROM Entries WHERE name = ?';

database.query(sqlQuery, (err,result)=>{
    if(err) console.log(err);
    console.log("Database created Successfully");
});

// GET route
app.get('/', function(req, res) {
    // redisClient.get('numVisits', function(err, numVisits) {
    //     numVisitsToDisplay = parseInt(numVisits) + 1;
    //     if (isNaN(numVisitsToDisplay)) {
    //         numVisitsToDisplay = 1;
    //     }
    //     res.send('Number of visits is: ' + numVisitsToDisplay);
    //     numVisits++;
    //     redisClient.set('numVisits', numVisits); 
    // });
    const key = req.query['name'];
    redisClient.get(key, function(err, counts) {
        const countsTodisp = parseInt(counts)+1;
        if(isNaN(countsTodisp)) {
            database.query(checkQuery,[key], (errc, result)=>{
                if(errc) throw errc;
                console.log(result);
                if(result.length>0)
                {
                    let gotcount = result[0].count
                    gotcount++;
                    redisClient.set(key,gotcount);

                    database.query(updtQuery,[key], (erru,result)=>{
                        if(erru) throw erru;
                        else{
                            console.log("Found this member in db... Updated count");
                        }
                    });
                    res.send(`Hello ${key}! ${gotcount}    found in database and updated count and also in redis :) `);
                }
                else
                {
                    redisClient.set(key,1);
                    database.query(insertQuery,[key,1], (erri,result)=>{
                        if(erri) throw erri;
                        else
                        {
                            console.log("Found new member and added to database");
                        }
                    });

                    res.send(`Hello ${key}! 1    inserted new response in database and also in redis :) `)
                }
            });
        }
        else{
            res.send(`Hello ${key}! ${countsTodisp}    found in redis :) `);
            counts++;
            redisClient.set(key,counts);
            database.query(updtQuery,[key], (err,result)=>{
                if(err) throw err;
                else{
                    console.log("Found this member in db... Updated count")
                }
            });       
        }
    });

});

app.listen(3000, function() {
    console.log('Web app is listening on port 3000');
});
