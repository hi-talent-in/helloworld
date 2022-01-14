from unicodedata import name
from flask import Flask
app=Flask(__name__)
@app.route('/',defaults={'name':'World'})
@app.route('/<name>')

def index(name):
        return "Hello"+" "+ name +"!"


      


    
    
if __name__== "__main__" :
    app.debug=False
    app.run()
    