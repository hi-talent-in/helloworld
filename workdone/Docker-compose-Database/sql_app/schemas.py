
from pydantic import BaseModel
class Record(BaseModel):
    name:str
    
    class Config:
        orm_mode = True