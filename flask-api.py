from flask import Flask
app=Flask(__name__)

@app.route('/')
def api():
    return "Hello world"

if __name__== "__main__" :
    app.run()