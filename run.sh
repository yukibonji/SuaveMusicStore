#!/usr/bin/env bash

export DB_CNTNR_NAME=suavemusicstore_db
export DB_CNTNR_ID=`docker ps -aq -f name=$DB_CNTNR_NAME`

export APP_CNTNR_NAME=suavemusicstore_app
export APP_CNTNR_ID=`docker ps -aq -f name=$APP_CNTNR_NAME`

if [ -n "$APP_CNTNR_ID" ]; then
	docker stop $APP_CNTNR_ID
	docker rm $APP_CNTNR_ID
fi

if [ -n "$DB_CNTNR_ID" ]; then
	docker stop $DB_CNTNR_ID
	docker rm $DB_CNTNR_ID
fi

docker run \
	--name $DB_CNTNR_NAME \
	-e POSTGRES_PASSWORD=mysecretpassword \
	-d theimowski/suavemusicstoredb:0.1

# how to wait for the postgres to init?
sleep 10

docker run \
	-p 8083:8083 -d \
	--name $APP_CNTNR_NAME \
	--link $DB_CNTNR_NAME:$DB_CNTNR_NAME \
	theimowski/suavemusicstore:0.1 \
	-c "mono ./app/bin/Debug/SuaveMusicStore.exe"
