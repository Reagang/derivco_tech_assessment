# Derivco Technical Assessment
This assessment is designed to test my SQL as well as C# abilities. 

<div>

<p> This Api was written in .NET8 and using Dapper micro ORM to handle the SQL Server database. The project was built to make setting up and getting started seamlessly and easy. You only need to run docker-compose -build and this will create the necessary images and setup the SQL server database. Run docker-compose up and it will spin up your two containers. One for you Database and the other for your API. Project include Swagger for ease of testing the api endpoints.</p>
<p>Please Note: The stored procedure can be found <a href="assessment/api/Scripts"> Here</a>. It was added to this path to automatically run the migrations when the API starts. If I had more information and time on the implementation of this game I could've done the implementation part too in the repositories. </p> <p>Unfortunatley I was on-call last week and we had big deployments which affected my time spend on this. Thanks! I enjoyed the assessment though</p>

<h4> <span> · </span> <a href="https://github.com/Reagang/derivco_tech_assessment/blob/master/README.md"> Documentation </a> <span> · </span> <a href="https://github.com/Reagang/derivco_tech_assessment/issues"> Report Bug </a> <span> · </span> <a href="https://github.com/Reagang/derivco_tech_assessment/issues"> Request Feature </a> </h4>


</div>

# :notebook_with_decorative_cover: Table of Contents

- [About the Project](#star2-about-the-project)
- [Roadmap](#compass-roadmap)


## :star2: About the Project
### :space_invader: Tech Stack
<details> <summary>Tech Choice</summary> <ul>
<li><a href="https://dotnet.microsoft.com/en-us/download/dotnet/8.0">.NET8</a></li>
<li><a href="https://github.com/DapperLib/Dapper">Dapper</a></li>
<li><a href="https://dbup.readthedocs.io/en/latest/">DbUp</a></li>
<li><a href="https://swagger.io/">Swagger</a></li>
</ul> </details>
<details> <summary>Database</summary> <ul>
<li><a href="https://hub.docker.com/_/microsoft-mssql-server/">MS SQL Server</a></li>
</ul> </details>
<details> <summary>DevOps</summary> <ul>
<li><a href="https://docs.docker.com/">Docker</a></li>
</ul> </details>

## :toolbox: Getting Started

### :bangbang: Prerequisites

- Ensure docker is installed if not you can download it <a href="https://docs.docker.com/desktop/install/windows-install/"> Here</a>


### :gear: Installation


```bash
docker-compose build
```

```bash
docker-compose up
```

## Demo Screenshot
![Alt text](assessment/Demo.png?raw=true "Swagger UI")

## :compass: Roadmap

* [x] 1. Write a SQL Stored Procedure (pr_GetOrderSummary)
* [x] 2. Create a C# REST API based around the game of roulette
* [ ] 3. Implementation of the entire assessment (game of roulette).
