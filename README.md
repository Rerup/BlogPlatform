# BlogPlatform
 FlexyBox case

# Documentation
```bash
https://docs.google.com/document/d/1OURUxINJPQTnuQjUegcf5MYckrd4dMIStqGwI3rOhdA/edit?usp=sharing
```

## Start the project

- Clone the project to store it locally on your PC
```bash
git clone https://github.com/Rerup/BlogPlatform
```

- Start either Visual Studio Code or Visual Studio and open the folder where you stored the project.

  
- Run the project as solution. If you are using Visual Studio Code, then run the dotnet commands in both projects (dotnet run|watch).
  If using Visual Studio then press F5


- Once both projects are running, then you must navigate to the following url in your favorite Browser.

```bash
http://localhost:5037/
```


- Seeding is automatically done upon starting the project.
  But be sure to have the project set to 

```bash
ASPNETCORE_ENVIRONMENT: Development
```
in the launchSettings of the BlogApi project.
