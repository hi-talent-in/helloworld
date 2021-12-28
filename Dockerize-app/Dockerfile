FROM node:8

WORKDIR /user/src/app

COPY package*.json ./

NPM run install

COPY . .

EXPOSE 8080

CMD [ "npm", "start"]