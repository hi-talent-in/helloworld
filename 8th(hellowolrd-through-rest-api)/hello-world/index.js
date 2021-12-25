const express = require('express')
const morgan = require('morgan')


const app = express()
app.use(morgan('tiny'))

app.get('/hello-world', (req, res) => {

    res.send('Hello RUSH')

})

const PORT = 4000

app.listen(4000, () => {
    console.log('The app is listening on port = ${PORT}')

})