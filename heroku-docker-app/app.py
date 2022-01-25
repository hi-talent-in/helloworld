from flask import Flask

app=Flask(__name__)

@app.route('/',)
def Humairaa():
    return "Hello World!"

if __name__== "__main__" :
    
    app.debug=False
    
    app.run()