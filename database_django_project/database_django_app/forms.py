from .models import Name
from django import forms

class ProductDetails(forms.ModelForm):
    class Meta:
        fields = '__all__'