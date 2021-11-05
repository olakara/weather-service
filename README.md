# weather-service

 A simple weather service getting data from Open Weather API

#Store APIKey in secret

Enable Secret storage
`dotnet user-secrets init`

Set a secret
`dotnet user-secrets set "ServiceSettings:ApiKey" "0fe021ea-85b8-4cea-a866-9baef5264407"`


#Install certificates for development

`dotnet dev-certs https --trust`