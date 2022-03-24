import uvicorn
from fastapi import FastAPI
from typing import Optional

app = FastAPI()

@app.get("/")
def index():
    return "Hello World!" 

@app.get("/{name}")
def ashish(name: Optional[str]= None):
      return "Heloo"+" "+ name + "!"  


if __name__ == "__main__" :
    uvicorn.run("name-argument:app", port=3000)