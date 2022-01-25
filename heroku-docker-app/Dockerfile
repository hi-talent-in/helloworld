FROM python:3
ADD . /code
WORKDIR /code
COPY requirements.txt requirements.txt
COPY . . 
ENTRYPOINT ["python" , "app.py"]