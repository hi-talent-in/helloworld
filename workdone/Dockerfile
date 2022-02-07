# Base image
FROM node:latest

# Working directory
WORKDIR /app

# Copy dependencies
COPY package.json /app

# Download and install dependencies
RUN npm install

# Copy the source files into the image
COPY . /app

# Startup command
CMD ["npm","start"]

# port
EXPOSE 3000