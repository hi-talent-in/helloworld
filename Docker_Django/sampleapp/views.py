from django.http import HttpResponse
from django.shortcuts import render

def search(request):
    if 'name' in request.GET.keys():
        message = 'Hello %r' % request.GET['name']
    else:
        message = 'Hello World'
    return HttpResponse(message)

def index(request):
    return render(request, 'list.html')