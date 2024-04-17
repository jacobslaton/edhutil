docker stop edhutil-db
docker rm edhutil-db
docker rmi edhutil-db
rm -rf /var/lib/docker/volumes/edhutil_data/_data
mkdir /var/lib/docker/volumes/edhutil_data/_data
docker build ./db -t edhutil-db:latest
docker run --name edhutil-db -d -p 5432:5432 -e POSTGRES_PASSWORD=$(cat ./secrets/password.txt) -v edhutil_data:/var/lib/postgresql/data edhutil-db:latest

