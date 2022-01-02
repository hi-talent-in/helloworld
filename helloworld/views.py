from django.shortcuts import render, HttpResponse
from rest_framework.response import Response
from django.core.cache import cache
from .models import * 
from . views import *
from rest_framework.views import APIView
 
# Create your views here.

class HelloWorld(APIView):

	def get(self, request):
		name = request.query_params['name']			
		db = ['PostgreSQL', 'Redis']		
		db_idx = 0

		if name == 'suraj-sh':
				if not cache.ttl('name'):
					name = Name.objects.first().name
					cache.set('name', name, timeout=10)
					cache.delete('count')
					cache_count = 0 
				else:
					name = cache.get('name')
					db_idx = 1 		 

				cache_count = cache.get('count', 0)
				cache.set('count', cache_count+1) 

				return Response(
					{
						'Message': f'Hello {name}! {cache_count}',
						'DB': db[db_idx],
						'TTL': cache.ttl('name')
					}
				)	
		
		else:
			return Response(
				{
					"Message": "Hello, World!"
				}
			)

						