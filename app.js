const express =require('express');
const PORT =7000;
const app =express();
const {Client} = require('pg')


const client = new Client(
    {
        host: "postgresql_database",
        user: "postgres",
        password: "komal",
        database: "student",
        port :5432,
        
    }
);


// Connect
client.connect((err) => {
    if (err) {
        console.log("this is the error.", err);
        throw new Error("can not connect to the db");
    };
    console.log('pgMySql Connected');
});

app.get('/', (req, res) => {
   return res.send('HELLO WORLD');
});


app.get('/student',(req,res)=>{
    let name = req.query['name'];
    console.log(name)
    if(name.length>0) 
    {
        
        const sqlQuery = 'CREATE TABLE IF NOT EXISTS students(id SERIAL, name VARCHAR(45), count int, PRIMARY KEY(id))';
        let insertQuery = 'INSERT INTO students (name,count) values($1,$2);';
        let updateQuery = 'UPDATE students SET count=count+1 where name=$1;';
        let checkQuery = 'SELECT * FROM students WHERE name=$1;';

        client.query(sqlQuery, (err,result)=>{
            if(err) console.log(err);
            console.log("Database created Successfully");
        })

        client.query(checkQuery,[name], (err,result)=>{
          if(err) throw err;
          console.log(result);
            if(result.rowCount>0)
            {

                console.log(result.rows[0].count);
                client.query(updateQuery,[name], (err,result)=>{
                    if(err) throw err;
                    else{
                        console.log("Student is present in db... count is updated");
                    }
                })
            }
            else{
                client.query(insertQuery,[name,1], (err,result)=>{
                    if(err) throw err;
                    else{
                        console.log("Its new student, added to databse");
                    }
                })
            }
        })
    }
    return res.send(`<h1>Hello ${name}</h1>`)

})



app.listen(PORT, () =>
    console.log(`running on ${PORT}`));