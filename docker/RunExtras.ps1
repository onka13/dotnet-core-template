Set-Location -Path ../
docker-compose -f "docker/docker-compose.yml" -f "docker/docker-compose.override.yml" -f "docker/docker-compose.extra.yml" up kibana # mssql mongo mongo-express rabbitmq elasticsearch kibana
Set-Location -Path ./docker