# stage 1
FROM node:alpine AS node-build
ARG skip_client_build=false
WORKDIR /app
COPY WebSPA .

RUN if [ "$skip_client_build" == true ]; then echo "Skipping npm install"; else npm install && npm run build; fi
 
# stage 2
 
FROM nginx:alpine
COPY --from=node-build /app/dist/online-shopping-app /usr/share/nginx/html
EXPOSE 80
