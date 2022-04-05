
from sqlalchemy.orm import Session

import models, schemas

def get_name_by_name(db: Session, name: str):
    return db.query(models.Record).filter(models.Record.name == name).first()

def create_name(db: Session, name: schemas.Record):
    db_name = models.Record(name=name.name)
    db.add(db_name)
    db.commit()
    db.refresh(db_name)
    return db_name