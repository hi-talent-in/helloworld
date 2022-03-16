FROM node:17


WORKDIR /apidocker

COPY package*json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD [ "node","app.js" ]
