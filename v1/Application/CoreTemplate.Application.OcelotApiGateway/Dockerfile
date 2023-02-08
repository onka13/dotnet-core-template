FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

#PROJECTS
 COPY "dotnet-core-common/CoreCommon.Application.API/CoreCommon.Application.API.csproj" "dotnet-core-common/CoreCommon.Application.API/CoreCommon.Application.API.csproj"
 COPY "dotnet-core-common/CoreCommon.Business.Service/CoreCommon.Business.Service.csproj" "dotnet-core-common/CoreCommon.Business.Service/CoreCommon.Business.Service.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.Domain/CoreCommon.Data.Domain.csproj" "dotnet-core-common/CoreCommon.Data.Domain/CoreCommon.Data.Domain.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.ElasticSearch/CoreCommon.Data.ElasticSearch.csproj" "dotnet-core-common/CoreCommon.Data.ElasticSearch/CoreCommon.Data.ElasticSearch.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.EntityFrameworkBase/CoreCommon.Data.EntityFrameworkBase.csproj" "dotnet-core-common/CoreCommon.Data.EntityFrameworkBase/CoreCommon.Data.EntityFrameworkBase.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.MongoDBBase/CoreCommon.Data.MongoDBBase.csproj" "dotnet-core-common/CoreCommon.Data.MongoDBBase/CoreCommon.Data.MongoDBBase.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.RabbitMQ/CoreCommon.Data.RabbitMQ.csproj" "dotnet-core-common/CoreCommon.Data.RabbitMQ/CoreCommon.Data.RabbitMQ.csproj"
 COPY "dotnet-core-common/CoreCommon.Data.ServiceBus/CoreCommon.Data.ServiceBus.csproj" "dotnet-core-common/CoreCommon.Data.ServiceBus/CoreCommon.Data.ServiceBus.csproj"
 COPY "dotnet-core-common/CoreCommon.Infra/CoreCommon.Infra.csproj" "dotnet-core-common/CoreCommon.Infra/CoreCommon.Infra.csproj"
 COPY "dotnet-core-common/CoreCommon.ModuleBase/CoreCommon.ModuleBase.csproj" "dotnet-core-common/CoreCommon.ModuleBase/CoreCommon.ModuleBase.csproj"
 COPY "dotnet-core-template/Application/CoreTemplate.Application.API/CoreTemplate.Application.API.csproj" "dotnet-core-template/Application/CoreTemplate.Application.API/CoreTemplate.Application.API.csproj"
 COPY "dotnet-core-template/Application/CoreTemplate.Application.OcelotApiGateway/CoreTemplate.Application.OcelotApiGateway.csproj" "dotnet-core-template/Application/CoreTemplate.Application.OcelotApiGateway/CoreTemplate.Application.OcelotApiGateway.csproj"
 COPY "dotnet-core-template/Application/CoreTemplate.Application.WorkerService/CoreTemplate.Application.WorkerService.csproj" "dotnet-core-template/Application/CoreTemplate.Application.WorkerService/CoreTemplate.Application.WorkerService.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccount.API/ModuleAccount.API.csproj" "dotnet-core-template/Modules/ModuleAccount.API/ModuleAccount.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccount.ApiBase/ModuleAccount.ApiBase.csproj" "dotnet-core-template/Modules/ModuleAccount.ApiBase/ModuleAccount.ApiBase.csproj"
 COPY "dotnet-core-template/Modules/ModuleAccount/ModuleAccount.csproj" "dotnet-core-template/Modules/ModuleAccount/ModuleAccount.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdmin.API/ModuleAdmin.API.csproj" "dotnet-core-template/Modules/ModuleAdmin.API/ModuleAdmin.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdmin.ApiBase/ModuleAdmin.ApiBase.csproj" "dotnet-core-template/Modules/ModuleAdmin.ApiBase/ModuleAdmin.ApiBase.csproj"
 COPY "dotnet-core-template/Modules/ModuleAdmin/ModuleAdmin.csproj" "dotnet-core-template/Modules/ModuleAdmin/ModuleAdmin.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommon.API/ModuleCommon.API.csproj" "dotnet-core-template/Modules/ModuleCommon.API/ModuleCommon.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommon.ApiBase/ModuleCommon.ApiBase.csproj" "dotnet-core-template/Modules/ModuleCommon.ApiBase/ModuleCommon.ApiBase.csproj"
 COPY "dotnet-core-template/Modules/ModuleCommon/ModuleCommon.csproj" "dotnet-core-template/Modules/ModuleCommon/ModuleCommon.csproj"
 COPY "dotnet-core-template/Modules/ModuleGrpcClient/ModuleGrpcClient.csproj" "dotnet-core-template/Modules/ModuleGrpcClient/ModuleGrpcClient.csproj"
 COPY "dotnet-core-template/Modules/ModuleGrpcService/ModuleGrpcService.csproj" "dotnet-core-template/Modules/ModuleGrpcService/ModuleGrpcService.csproj"
 COPY "dotnet-core-template/Modules/ModuleRabbitMQ/ModuleRabbitMQ.csproj" "dotnet-core-template/Modules/ModuleRabbitMQ/ModuleRabbitMQ.csproj"
 COPY "dotnet-core-template/Modules/ModuleServiceBus/ModuleServiceBus.csproj" "dotnet-core-template/Modules/ModuleServiceBus/ModuleServiceBus.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplate.API/ModuleTemplate.API.csproj" "dotnet-core-template/Modules/ModuleTemplate.API/ModuleTemplate.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplate.ApiBase/ModuleTemplate.ApiBase.csproj" "dotnet-core-template/Modules/ModuleTemplate.ApiBase/ModuleTemplate.ApiBase.csproj"
 COPY "dotnet-core-template/Modules/ModuleTemplate/ModuleTemplate.csproj" "dotnet-core-template/Modules/ModuleTemplate/ModuleTemplate.csproj"
 COPY "dotnet-core-template/Modules/ModuleTest.API/ModuleTest.API.csproj" "dotnet-core-template/Modules/ModuleTest.API/ModuleTest.API.csproj"
 COPY "dotnet-core-template/Modules/ModuleTest.ApiBase/ModuleTest.ApiBase.csproj" "dotnet-core-template/Modules/ModuleTest.ApiBase/ModuleTest.ApiBase.csproj"
 COPY "dotnet-core-template/Modules/ModuleTest/ModuleTest.csproj" "dotnet-core-template/Modules/ModuleTest/ModuleTest.csproj"


RUN dotnet restore "dotnet-core-template/Application/CoreTemplate.Application.OcelotApiGateway/CoreTemplate.Application.OcelotApiGateway.csproj"
COPY . /src/.
WORKDIR "/src/dotnet-core-template/Application/CoreTemplate.Application.OcelotApiGateway/"
RUN dotnet build "CoreTemplate.Application.OcelotApiGateway.csproj" -c Release -o /app/build
#RUN dotnet build -c $Configuration -o /app
RUN dotnet publish "CoreTemplate.Application.OcelotApiGateway.csproj" --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreTemplate.Application.OcelotApiGateway.dll"]
