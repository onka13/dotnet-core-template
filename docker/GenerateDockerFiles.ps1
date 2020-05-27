# use below command on console in order to run;
# powershell -ExecutionPolicy Bypass -File GenerateDockerFiles.ps1

param (
  [string]$solution = "../dotnet-core-template.sln"
)

# DockerfileTemplate.txt    => DockerFile
# DockerIgnoreTemplate.txt  => .dockerignore

# Projects which DockerFile and .dockerignore will be created
$projects = @(
  'Application/CoreTemplate.Application.OcelotApiGateway/CoreTemplate.Application.OcelotApiGateway.csproj',
  'Application/CoreTemplate.Application.API/CoreTemplate.Application.API.csproj',
  'Modules/ModuleAccount.API/ModuleAccount.API.csproj',
  'Modules/ModuleAdmin.API/ModuleAdmin.API.csproj',
  'Modules/ModuleTest.API/ModuleTest.API.csproj'
)

$solutionDirName = (get-item "./GenerateDockerFiles.ps1").Directory.Parent.Name

$dockerTemplate = Get-Content -Path .\DockerfileTemplate.txt -Encoding UTF8 -Raw

$projectList = (Select-String -Path $solution -Pattern ', "(.*?\.csproj)"' | ForEach-Object { $_.Matches.Groups[1].Value.Replace("\", "/") } | Sort-Object | ForEach-Object { 
  if ($_ -like "*_Extensions*") { return }
  if ($_ -like "*Tests*") { return }
  if ($_ -like "*dotnet-core-common*") { 
    $x = $_.Substring($_.IndexOf("dotnet-core-common"))
    "COPY ""$x"" ""$x""`r`n"
    return 
  }
  "COPY ""$solutionDirName/$_"" ""$solutionDirName/$_""`r`n"
})

foreach ($project in $projects) {
  $item = (get-item "../$project")
  $outfile = "$($item.Directory.FullName)/Dockerfile"
  
  $content = $dockerTemplate
  $content = [Regex]::Replace($content, "#SOLUTION_DIRNAME", $solutionDirName)
  $content = [Regex]::Replace($content, "#PROJECTS", "#PROJECTS`r`n $projectList")
  $content = [Regex]::Replace($content, "#CSPROJ_FULL", $project)
  $content = [Regex]::Replace($content, "#CSPROJ_DIR", $project.replace($item.Name, ""))
  $content = [Regex]::Replace($content, "#PROJECT_NAME", $item.Name.replace(".csproj", ""))

  Set-Content -Path $outfile -Value $content -Encoding UTF8

  # copy ignore file
  Copy-Item -Path "DockerIgnoreTemplate.txt" -Destination "$($item.Directory.FullName)/.dockerignore" -Force

  "$project"
}

"DONE"
