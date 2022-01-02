from django.db import models
import psycopg2

# Create your models here.

class Name(models.Model):
	name = models.CharField(max_length=50)
