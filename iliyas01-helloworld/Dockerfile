#add a line in our Dockerfile that tells Docker what base image we would like to use for our application.
#source like entry point
FROM python:3
#copy program into image
ADD hello-world.py /
#specify path 
WORKDIR /iliyas01-helloworld
#copy command takes 2 parameters(what to,where to)
COPY requirements.txt requirements.txt
#modules are to be installed in image ,so runs whatever in requirements.txt
RUN pip3 install -r requirements.txt
#copy source code to image

COPY . .
#tell docker what command have to run
CMD [ "python3","hello-world.py"]