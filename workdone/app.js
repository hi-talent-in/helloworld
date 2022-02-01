const express = require('express');
const app = express();
const port = 3000;

app.get("/", (req, res) => {
    if (req.query.name==undefined) res.send("Hello world!");
    else res.send("heloo " + req.query.name + "!");
});

app.listen(port);

console.log('Server running at: ' + port);