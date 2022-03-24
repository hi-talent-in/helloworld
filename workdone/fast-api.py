import uvicorn
from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def ashish():
    return "Hello World" 

if __name__ == "__main__":
    uvicorn.run("fast-api:app", port=3000)