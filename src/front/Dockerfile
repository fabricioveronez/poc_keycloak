FROM node:10-alpine as builder
WORKDIR /app
RUN npm install -g @angular/cli@8.3.3 typescript@3.6.2 
COPY package*.json ./
RUN npm install
COPY ./ /app/
RUN ng build --prod --aot --optimization --output-path /app-build/

FROM nginx:alpine
COPY ./nginx.default.conf /etc/nginx/conf.d/default.conf
COPY --from=builder  /app-build/ /usr/share/nginx/html/