from django.http import HttpResponse

def search(request):
    if 'name' in request.GET.keys():
        message = 'Hello %r' % request.GET['name']
    else:
        message = 'Hello World'
    return HttpResponse(message)