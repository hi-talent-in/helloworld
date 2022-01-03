from django.db import models

# Create your models here.
class Name(models.Model):
    user_name = models.CharField(max_length=100)