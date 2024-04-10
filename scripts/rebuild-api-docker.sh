docker stop edhutil-api
docker rm edhutil-api
docker build ./EdhutilApi -t edhutil-api:latest
docker run --name edhutil-api -d -p 5000:80 edhutil-api:latest

