from django.shortcuts import render, HttpResponse

# Create your views here.
def GetApi(request):
    return HttpResponse ("<h1>Django Application</h1>")