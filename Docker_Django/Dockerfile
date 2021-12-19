# Its a lightweight linux OS with python already installed
FROM python:3.8-slim-buster

# The working directory
WORKDIR /app

# Copy requirements.txt 
COPY requirements.txt requirements.txt

# Running the requirements.txt file
RUN pip3 install -r requirements.txt

# Copy all the folders
COPY . .

# Run the commands
CMD ["python3", "manage.py", "runserver", "0.0.0.0:8000"]
