# Gruppe-4-Kartverk-Heimevernet
Gruppe 4 repo for 3. semester prosjektet. En webapplikasjon med kart som viser og hjelper til med å håndtere krisesituasjoner.

Opprett endringer i egen branch først, så opprett en PR som vi kan gå gjennom.

GitHub Actions er satt opp for å automatisk teste om systemet bygges ved hver commit/PR.

## Running the application locally

The application targets .NET 10 and uses Entity Framework Core with MariaDB/MySQL. On startup it creates the development database schema and inserts the seed resources.

### Prerequisites

Install and start the following:

- Git
- .NET 10 SDK
- Docker Desktop with Docker Engine running

The development configuration expects MariaDB at `localhost:3306` with these credentials:

| Setting | Value |
| --- | --- |
| Server | `localhost` |
| Port | `3306` |
| Database | `HV_prosjekt` |
| User | `root` |
| Password | `hvpassword` |

These values match `HV_prosjekt/appsettings.Development.json` and are intended for local development only.

### Clone the repository

```powershell
git clone https://github.com/Han-cmd-s/Gruppe-4-Semester-3-oppgave.git
cd Gruppe-4-Semester-3-oppgave
```

### Start MariaDB

Create the database container:

```powershell
docker run --name hv-mariadb `
  -e MARIADB_ROOT_PASSWORD=hvpassword `
  -e MARIADB_DATABASE=HV_prosjekt `
  -p 3306:3306 `
  -d mariadb:10.11
```

If the container already exists, start it instead:

```powershell
docker start hv-mariadb
```

Verify that it is running and accepting connections:

```powershell
docker ps
Test-NetConnection localhost -Port 3306
```

`TcpTestSucceeded` must be `True` before starting the application.

### Run from the terminal

```powershell
dotnet restore .\HV_prosjekt\HV_prosjekt.csproj
dotnet run --project .\HV_prosjekt\HV_prosjekt.csproj --launch-profile http
```

Open <http://localhost:5103>.

### Run from Visual Studio

1. Open `HV_prosjekt.slnx`.
2. Ensure Docker Desktop and the `hv-mariadb` container are running.
3. Select the `http` launch profile.
4. Start the project with **F5** or **Ctrl+F5**.
5. Open <http://localhost:5103> if the browser does not open automatically.

The HTTPS profile is also available at <https://localhost:7063>.

## Troubleshooting

### Unable to connect to MySQL hosts

Check the container and port:

```powershell
docker ps --filter "name=hv-mariadb"
Test-NetConnection localhost -Port 3306
```

If the container is stopped, run `docker start hv-mariadb`. If no container exists, repeat the `docker run` command above.

If port `3306` is already used, choose another host port and update both the Docker mapping and `Port` in `HV_prosjekt/appsettings.Development.json`. For example, use `-p 3307:3306` and `Port=3307`.

### Reset the local development database

The following commands delete the local database container and its data. The application will recreate and seed the schema on the next startup:

```powershell
docker rm -f hv-mariadb
docker run --name hv-mariadb `
  -e MARIADB_ROOT_PASSWORD=hvpassword `
  -e MARIADB_DATABASE=HV_prosjekt `
  -p 3306:3306 `
  -d mariadb:10.11
```

Do not use these development credentials in a production deployment.
