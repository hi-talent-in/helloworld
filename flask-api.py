from flask import Flask
app=Flask(__name__)

@app.route('/')
def iliyas():
    return "Hello world!"

if __name__== "__main__" :
    app.debug=False
    app.run()