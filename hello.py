from flask import Flask, request, abort
from flask_restful import Resource, Api
from marshmallow import Schema, fields

class NameSchema(Schema):

	name = fields.Str(required=False)

	'''	If required=True then the query string
		cannot be empty otherwise it will show an error.
		If required=False then it will pass the default 
		name assigned to it.
	''' 
	
app = Flask(__name__)
api = Api(app)
schema = NameSchema()

class HelloWorld(Resource):
	def get(self):
		
		# Default query string set to suraj-sh
		name = request.args.get('name', 'suraj-sh')
		
		errors = schema.validate(request.args)
		if errors:
			abort(400, str(errors))
			
			'''THIS will return the message and the default 
				name assigned to it, if required=False
				otherwise it will return message and any name passed to it. 
			'''
		return 'Hello, World! ' + name

api.add_resource(HelloWorld, '/api/helloworld', endpoint='helloworld')

if __name__ == '__main__':
    app.run(debug=True)