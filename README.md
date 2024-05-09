# research-data-api-builder-swa-auth
Possibility to run Data API builder solution within Static Web App (SWA default authorization).

### Local DEV (app and DAB hosted together by SWA CLI with 5000 port fix)
- run command `swa start`
- in web browser go to `127.0.0.1:4280`

### Problems
- Local DEV: swa start - use `127.0.0.1`:4280 instead of `localhost` (for emulating login) 
- DAB authentication when hosted on local with Docker, isn't working with local SWA CLI authentication emulator
- roles change could take some time so it can be taken as authorization don't validate roles when checking instantly 

### 5000 port fix (that was on my machine) - `Intel(R) Graphics Command Center Service`
- navigate to `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\igccservice`
- append after the quotes: --urls `http://127.0.0.1:YOURPORT`
- restart service

### Links
- [Shared auth in Azure Static Web Apps, Blazor](https://medium.com/@manuelspinto/shared-authentication-in-azure-static-web-apps-using-only-net-blazor-and-c-functions-003dfed7047c)
- [Repo: Shared auth in Azure Static Web Apps, Blazor](https://github.com/manuelspinto/azure-staticwebapp-dotnet)