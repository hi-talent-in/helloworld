from django.http.response import HttpResponse
from django.shortcuts import render
from django.views.generic.edit import CreateView
from .models import Name
from django.db.models import Sum

# Create your views here.
class GetName(CreateView):			
    model=Name				
    fields=['user_name']
    template_name="getName.html"
    success_url = '/count/'
        
def PrintName(request):
    x=Name.objects.all()
    count=0
    for i in x:
        count=count+1
    print(count)
    return render(request, 'count.html', {'count':count})
    