FROM node:alpine

WORKDIR /usr/src/app

# Wildcard used to copy to container "package.json" AND "package-lock.json"
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD ["npm","start"]
