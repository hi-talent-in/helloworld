// config.js
const config = {
    app: {
      port: 3000
    },
    db: {
      host: 'localhost',
      port: 27017,
      name: 'db'
    }
   };
   
   module.exports = config;
   
   // db.js
   const mongoose = require('mongoose');
   const config = require('./config');
   
   const { db: { host, port, name } } = config;
   const connectionString = `mongodb://${host}:${port}/${name}`;
   mongoose.connect(connectionString);
   
   // app.js
   const express = require('express');
   const config = require('./config');
   
   const app = express();
   app.listen(config.app.port);