SonarScanner.MSBuild.exe begin /k:"ITbob_AspRepo" /d:sonar.organization="itbob-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="2803df9e3b24365613c89f2ab6ce5e36c850f1ff"
MSBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.login="2803df9e3b24365613c89f2ab6ce5e36c850f1ff"