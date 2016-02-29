FROM fsharp/fsharp

COPY . /app

RUN cd ./app && \
    ./build.sh && \
    cd ..

EXPOSE 8083

CMD []
