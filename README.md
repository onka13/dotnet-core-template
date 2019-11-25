## .NET Core 3.0 Project Templates

Provides a good start for large scale projects.
Project architecture considers software concepts such as DDD, TDD, Solid etc.
Aims to provide microservice structure that includes independent modules.
Contains user modules basicly for now.

## Installation

- Install Visual Studio Extension
- Create a new project.
- Select 'Onka Core Template Project'
- Clone [dotnet-common-project](https://github.com/onka13/dotnet-core-common) to parent directory.

***

- `/Projects/dotnet-common-project`
- `/Projects/your project`

# Structure of the project

- `/ApiModules` - contains api modules
    - `ApiModuleAccount` - contains user based api routes
    - `ApiModuleCommon` - shared api module for api modules
- `/Application` - api, worker, console, web projects etc.
    - `XXX.Application.API` - api project
    - `XXX.Application.WorkerService` - background services project
- `/Business` - project business logics
    - `XXX.Business.Service` - main project business logic project
- `/Modules` - contains modules
    - `ModuleAccount` - user module
    - `ModuleCommon` - shared module for modules
- `/Tests` - test project
    - `XXX.Tests.General` - unit test project

### Add Modules

- Add a new project.
- Select 'Onka Core Module'

### Add Api Modules

- Add a new project.
- Select 'Onka Core Api Module'
- Add a reference to `XXX.Application.API`
- Add a reference to `XXX.Application.WorkerService`

## Todo

- [ ] Create documentation
- [ ] Add more functionality for user module
- [ ] Add a react js based admin ui panel
- [ ] Code generator for modules

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.