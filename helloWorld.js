"use strict";

let express = require('express');
let app = express();

app.get('/api/helloworld', function(req, res){
		res.send("Hello World!");
});

app.listen(8080, function(){
	console.log("app listening...");
});
