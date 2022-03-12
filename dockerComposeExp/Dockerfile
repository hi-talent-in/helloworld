FROM node:14

# Create app directory
WORKDIR /usr/src/app

# install app dependencies
COPY package*.json ./
RUN npm install

# Bundle app source
COPY . .

EXPOSE 3000

CMD ["npm","start"]