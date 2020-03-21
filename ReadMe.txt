Instructions
------------
1. Publish database from Database project. Provide Database name: Angular-Core.

2. In ClientApp, install packages:
	--run command 'npm install'

3. In Angular, change base address in global.const.ts. This will be the root url of hosted environment.
-----------------------------------

IIS Hosting
-----------
1. Install Core Hosting Bundle (if not installed)
https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.2-windows-hosting-bundle-installer

2. Publish the Core.WebApi project to /Angular-Core-App/Publish

3. Create the Site in IIS.

4. Change the credential in application pool, if needed.