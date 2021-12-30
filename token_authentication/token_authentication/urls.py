from django.urls import path, include
from django.contrib import admin
from token_authentication_app import views
from rest_framework.routers import DefaultRouter

#creatting router object
router=DefaultRouter()

#register studentviewset with router
router.register('studentapi',views.StudentModelViewSet,basename='student')

urlpatterns = [
path('admin/', admin.site.urls),
path('api',include(router.urls)),
]