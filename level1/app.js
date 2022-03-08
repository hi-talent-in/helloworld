const http = require('http');
const hostname = '127.0.0.1';
const port = 5500;
const url = require('url');


const server = http.createServer((req, res) => {
  console.log(req.url)
  const queryObject = url.parse(req.url,true).query;
  console.log(queryObject.name);
  let name = queryObject.name
  res.statusCode = 200;
  res.setHeader('Content-Type', 'text/plain');
  if(name){
    res.end(`Hello ${name}`)
  }
  else
      res.end('Hello  world!');
});

server.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
  
});