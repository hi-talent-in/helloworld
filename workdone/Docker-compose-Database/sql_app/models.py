from sqlalchemy import Column, Integer, String
from database import Base

# database table
class Record(Base):
    __tablename__ = "record"
    
    id = Column(Integer,primary_key=True,index=True)
    name = Column(String(255), index=True)
    