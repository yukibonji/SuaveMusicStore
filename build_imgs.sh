#!/usr/bin/env bash

pushd postgres
docker build -t theimowski/suavemusicstore_db:0.1 .
popd

docker build -t theimowski/suavemusicstore_app:0.1 .
