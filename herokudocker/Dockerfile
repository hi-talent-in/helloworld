FROM python:3

ADD app.py /

WORKDIR /




COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt
COPY . .

ENTRYPOINT [ "python", "app.py" ]