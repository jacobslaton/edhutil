<h1 align="center">edhutil</h1>

---

# Contents
- 1 - [Introduction](#1-introduction)
- 2 - [Database Setup](#2-database-setup)

---

# 1. Introduction

---

# 2. Database Setup

To setup the password for the database docker container, put the password in a file and run this command from the repository's root.

```
docker secret create edhutil_postgres_password secrets/password.txt
```

Create a volume for the database.

```
docker volume create edhutil_data
```

Build the image for the database container.

```
sudo docker build ./db -t edhutil-db:latest
```

Create and run the container.

```
sudo docker run --name edhutil-db -d -p 5432:5432 -e POSTGRES_PASSWORD=$(cat ./secrets/password.txt) -v edhutil_data:/var/lib/postgresql/data edhutil-db:latest
```

Restart a stopped container.

```
docker restart edhutil-db
```

