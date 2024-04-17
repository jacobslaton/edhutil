uuidgen > secrets/password.txt
docker secret create edhutil_postgres_password secrets/password.txt
docker volume create edhutil_data

