FROM fsharp:4.0

COPY ./build /app

EXPOSE 8083

WORKDIR /app

CMD ["mono", "SuaveMusicStore.exe"]