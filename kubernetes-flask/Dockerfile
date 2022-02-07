FROM python:latest
RUN mkdir /app
WORKDIR /app/
ADD . /app/
EXPOSE 5000
RUN pip install -r requirements.txt
CMD gunicorn app:app --bind 0.0.0.0:$PORT --reload