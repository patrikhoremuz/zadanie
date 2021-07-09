FROM mcr.microsoft.com/mssql/server:2019-latest
CMD /bin/bash /usr/src/app/entrypoint.sh

USER root

RUN mkdir -p /usr/src/app

WORKDIR /usr/src/app
COPY . /usr/src/app

RUN chmod +x /usr/src/app/run-initialization.sh

USER mssql

ENTRYPOINT /bin/bash /usr/src/app/entrypoint.sh

EXPOSE 1434