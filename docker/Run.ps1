Copy-Item "./.dockerignore" -Destination "../../.dockerignore"
Copy-Item "./.env" -Destination "../../.env"
#Set-Location -Path ../../
#docker-compose -f .\docker-compose.yml up #--force-recreate --build
#Set-Location -Path ./dotnet-core-template/docker

Set-Location -Path ../
docker-compose -f "docker/docker-compose.yml" -f "docker/docker-compose.override.yml" up #-d --build --force-recreate
Set-Location -Path ./docker
