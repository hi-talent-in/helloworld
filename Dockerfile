# pull official base image
FROM python:3.9-slim-buster

# set work directory
WORKDIR /drf

# set environment variables
ENV PYTHONDONTWRITEBYTECODE 1
ENV PYTHONUNBUFFERED 1


# install psycopg dependencies
RUN apt-get update && apt-get install -y \
    build-essential \
    libpq-dev \
    && rm -rf /var/lib/apt/lists/*

# install dependencies
RUN pip install --upgrade pip
COPY ./requirements.txt /drf/requirements.txt
RUN pip install -r requirements.txt

# copy project
COPY . /drf