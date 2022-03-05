const app = require('express')();

const PORT = 8000;

app.listen(
    PORT,
    () => console.log(`Server running on ${PORT}`)
);

app.get('/hello_world', (req, res) => {
    res.send("Hello World!")
});

