import uvicorn
import redis
import time
from fastapi import FastAPI
from typing import Optional

app = FastAPI()

cache = redis.Redis(host='redis', port=8337)

def get_hit_count():
    retries = 5
    while True:
        try:
            return cache.incr('hits')
        except redis.exceptions.ConnectionError as exc:
            if retries == 0:
                raise exc
            retries -= 1
            time.sleep(0.5)

def get_name_count():
    retries = 5
    while True:
        try:
            return cache.incr('name')
        except redis.exceptions.ConnectionError as exc:
            if retries == 0:
                raise exc
            retries -= 1
            time.sleep(0.5)

def get_user_count():
    retries = 5
    while True:
        try:
            return cache.incr('user')
        except redis.exceptions.ConnectionError as exc:
            if retries == 0:
                raise exc
            retries -= 1
            time.sleep(0.5)


@app.get("/")
def index():
    count = get_hit_count()
    return "Hello world!" +" "+"{} Times.".format(count)
 

@app.get("/greet")
def ashish(name: Optional[str]= "user"):
      if (name!="user"):
        count = get_name_count()
      else:
        count = get_user_count()
      return "Heloo"+" "+ name +" "+"{} Times.".format(count)

if __name__ == "__main__" :
    uvicorn.run("main:app")