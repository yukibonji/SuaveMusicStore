#!/usr/bin/env bash

export DB_IMG_NAME=suavemusicstore_db
export DB_CNTNR_ID=`docker ps -aq -f name=$DB_IMG_NAME`

export APP_IMG_NAME=suavemusicstore_app
export APP_CNTNR_ID=`docker ps -aq -f name=$APP_IMG_NAME`

if [ -n "$DB_CNTNR_ID" ]; then
	docker stop $DB_CNTNR_ID
	docker rm $DB_CNTNR_ID
fi

if [ -b "$APP_CNTNR_ID" ]; then
	docker stop $APP_CNTNR_ID
	docker stop $APP_CNTNR_ID
fi

docker run --name $DB_IMG_NAME -e POSTGRES_PASSWORD=mysecretpassword -d theimowski/suavemusicstoredb:0.1
docker run --name $APP_IMG_NAME -d theimowski/suavemusicstore:0.1
