docker stop edhutil-api
docker rm edhutil-api
docker build ./Models -t edhutil-models:latest
docker build ./EdhutilApi -t edhutil-api:latest
docker run --name edhutil-api -d -p 5000:80 edhutil-api:latest

