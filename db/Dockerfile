FROM postgres:latest
USER postgres
EXPOSE 5432
ENV POSTGRES_DB edhutil
ENV POSTGRES_USER admin
COPY AllPrintings.sql /docker-entrypoint-initdb.d/

