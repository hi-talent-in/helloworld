from flask import Flask, render_template, url_for, request, make_response

app = Flask(__name__)

@app.route('/')
@app.route('/home')
def home():
    return render_template("index.html")



@app.route('/result',methods=['POST', 'GET'])
def result():
    output = request.form.to_dict()
    print(output)
    name = output ["name"]
    resp=make_response(render_template('index.html',name=name))
    resp.set_cookie('name',name)
    return resp       
   # return render_template('index.html', name = name)
    


if __name__ == "__main__":
    app.run(debug=True)