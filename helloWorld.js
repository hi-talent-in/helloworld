"use strict";

let express = require('express');
let url = require('url');
let app = express();
let count = 0;
app.get('/api/helloworld', function(req, res){
	const queryData = url.parse(req.url, true).query;
	console.log(queryData.name);
	if (queryData.name != undefined){
		count++;
		let msg = "Hello " + queryData.name + " ( " + count + " )";
		res.write(msg);
	}
	else{
		res.write("Hello World!");
	}
	res.send();
});

app.listen(8080, function(){
	console.log("app listening...");
});
