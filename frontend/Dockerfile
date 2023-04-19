FROM node:lts-alpine AS angular
WORKDIR /usr/src/app
COPY ["package.json", "package-lock.json*", "npm-shrinkwrap.json*", "./"]
RUN npm install 
RUN npm install -g @angular/cli
COPY . .
RUN npm run build -- --c production

FROM nginx:alpine
COPY --from=angular /usr/src/app /usr/share/nginx/html
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]