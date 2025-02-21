# About
This is an unofficial SDK for using the [Turso Platform API](https://docs.turso.tech/api-reference/introduction) in C#. It supports all available `v1` endpoints.

# Setup
Complete setup information can be found in the [Turso quickstart guide](https://docs.turso.tech/api-reference/quickstart).

1. First [install the Turso CLI](https://docs.turso.tech/cli/installation).
2. Use the CLI to get your account user or organization slug.
	```
	turso org list
	```
3. Create a platform API token.
	```
	turso auth api-tokens mint quickstart
	```

# Usage
Install the package in your project.
```
dotnet add package rthomasv3.TursoPlatformApi
```

The services and methods are a one-to-one mapping with the Turso documentation.

For example, to list all databases:
```c#
await tursoPlatformService.Databases.List();
```
 
| Service     | Usage     |
| ------------- | ------------- |
| ITursoPlatformService | The overall platform service with properties for all other services. |
| ITursoDatabaseService | Manage databases. |
| ITursoGroupService | Manage groups. |
| ITursoLocationService | View locations. |
| ITursoOrganizationsService | Manage organizations. |
| ITursoMembersService | Manage members. |
| ITursoInvitesService | Manage invites. |
| ITursoAuditLogsService | View audit logs. |
| ITursoApiTokensService | Manage platform API tokens. |

## Dependency Injection
The easiest way to use the Turso Platform API Service is using dependency injection.

Add a `TursoPlatformApi` section to your `appsettings.json` file. Use `appsettings.Development.json` to avoid keys ending up in your repo.

```json
{
  "TursoPlatformApi": {
    "DefaultOrganizationSlug": "<your-organization-slug>",
    "AuthToken": "<your-api-token>"
  }
}
```

After that you can add Turso Platform API Service using the provided services extension method. If you prefer, you can pass in your org slug and API key to the `AddTursoPlatformService` method instead of using `appsettings.json`.

```c#
builder.Services.AddTursoPlatformService();
```

Then you can add any of the API services to the constructors in your application.

## Instance
You can also create and use an instance directly if you prefer.

```c#
// create a new instance
var tursoPlatformApi = new TursoPlatformApi.TursoPlatformService("<your-organization-slug>", "<your-api-token>");
var allGroups = await tursoPlatformApi.Groups.List();
```

or 

```c#
// static instance
TursoPlatformApi.TursoPlatformService.Initialize("<your-organization-slug>", "<your-api-token>");
var allDatabases = await TursoPlatformApi.TursoPlatformService.Instance.Databases.List();
```
