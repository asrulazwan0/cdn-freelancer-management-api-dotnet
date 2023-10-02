## Description

This is a backend application built using ASP.NET Core. It serves as the server-side component for a Freelancer Management System.

## How to use

Download the example [or clone the repo](https://github.com/asrulazwan0/cdn-freelancer-management-api-dotnet):

Install it and run:

```bash
dotnet restore
dotnet run
```

## Configuring the Environment

Before running the application, make sure to configure your environment variables. An env.example file is provided in the project directory as a template. Copy the env.example file and rename the copy to .env.

```bash
cp .env.example .env
```

Then, open the .env file and set the following variables:

```bash
ALLOWED_HOSTS: A comma-separated list of all the hosts your application is allowed to serve.
ALLOWED_ORIGINS: A comma-separated list of all the origins your application is allowed to serve.
DB_HOST: The hostname of your database server.
DB_PORT: The port number your database server is listening on.
DB_USER: The username for your database.
DB_PASS: The password for your database.
DB_NAME: The name of your database.
```

## Docker Instructions

### Building the Docker Image

```bash
docker build -t myapp .
```

### Running the Docker Container

```bash
docker run -p 8000:80 myapp
```

### Docker Compose

To start and stop the application with Docker Compose, use:

```bash
docker-compose up
docker-compose down
```

Replace `myapp` with your application's name and adjust the port numbers as needed.

## Client-side
The client-side of this application can be found in a separate repository: https://github.com/asrulazwan0/cdn-freelancer-management-client-react

## Stay in touch

- Author - [Asrul Azwan](https://www.linkedin.com/in/asrul-azwan)
- Website - [https://asrulazwan.com](https://asrulazwan.com)
- Twitter - [@asrlazwn](https://twitter.com/asrlazwn)

## License

This project is licensed under the MIT License.