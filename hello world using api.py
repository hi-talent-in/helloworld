#!/usr/bin/env python
# coding: utf-8

# In[2]:


get_ipython().system('pip install flask')


# In[3]:


from flask import Flask,jsonify


# In[ ]:


from flask import Flask
app=Flask(__name__)

@app.route('/')
def api():
    return "Hello world"

if __name__== "__main__" :
    app.run()


# In[ ]:




