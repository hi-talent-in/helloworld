FROM python:latest
RUN mkdir /app
WORKDIR /app/
ADD . /app/
EXPOSE 5000
COPY requirements.txt requirements.txt
RUN pip install -r requirements.txt
CMD [ "python3","app.py"]