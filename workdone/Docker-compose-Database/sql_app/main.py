import uvicorn
from typing import List
from fastapi import Depends, FastAPI, HTTPException
from sqlalchemy.orm import Session
import models
import schemas
import crud
import database
from database import SessionLocal, engine
models.Base.metadata.create_all(database.engine)

app = FastAPI()

# Dependency

def get_db():
    try:
        yield db
    finally:
        db.close()
db = SessionLocal()

@app.get('/')
def index():
    return{"message":"Hello World!"}

# Enter string
@app.post('/record/',response_model=schemas.Record,status_code=200)
def create_name(name: schemas.Record, db: Session = Depends(get_db)):
    db_name = crud.get_name_by_name(db, name=name.name)
    if db_name:
        raise HTTPException(status_code=400, detail="name already registered")
    return crud.create_name(db=db, name=name) 

# Shows the record
@app.get('/records/', response_model=List[schemas.Record],status_code=200)
def show_records():
    records = db.query(models.Record).all()
    return records

if __name__ == "__main__":
    uvicorn.run("main:app")
