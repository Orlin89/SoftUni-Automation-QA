FROM node:14

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 3030
EXPOSE 3300

CMD ["npm", "start"]
