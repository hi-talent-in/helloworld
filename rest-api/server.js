const express = require('express');

const app = express();
const port = process.env.PORT || 8080;

// ...

app.param('name', function(req, res, next, name) {
    const modified = name.toUpperCase();
  
    req.name = modified;
    next();
  });
  
  // routes will go here
  // ...
  
  app.get('/api/users/:name', function(req, res) {
    res.send('Hello ' + req.name + '!');
  });
  
  app.listen(port);
  console.log('Server started at http://localhost:' + port);