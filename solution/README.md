#powerplant-coding-challenge solution by Abdelkadir KEBIR

## Overview

The power plant challenge at [Challenge]https://github.com/akqira/powerplant-coding-challenge is resolved in this repo and organized as following :

- .NET 8 API Project
- Unit test project
- Domain and Application projects holding business related rules

## How run this solution

- Clone the repo locally
- ensure that you have .net 8 sdk or runtime installed on your machine
- on your terminal navigate to EnergyPlanner.Api folder and run `dotnet run` command
- on your terminal you will see that app is up and running on https://localhost:8888
- the API is offering swagger interface to test endpoint, you can go to https://localhost:8888/swagger/index.html
- you can also use external tool to call endpoint like POSTMAN or Thunder (vscode) or even using curl
- exposed endpoint /ProductionPlan uses POST method and expect following payload format :

```json
{
  "load": 910,
  "fuels": {
    "gas(euro/MWh)": 13.4,
    "kerosine(euro/MWh)": 50.8,
    "co2(euro/ton)": 20,
    "wind(%)": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredbig2",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredsomewhatsmaller",
      "type": "gasfired",
      "efficiency": 0.37,
      "pmin": 40,
      "pmax": 210
    },
    {
      "name": "tj1",
      "type": "turbojet",
      "efficiency": 0.3,
      "pmin": 0,
      "pmax": 16
    },
    {
      "name": "windpark1",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 150
    },
    {
      "name": "windpark2",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 36
    }
  ]
}
```
- response for previous sample will be :
```json
{
  "apiVersion": "1.0",
  "errorCode": "",
  "errorMessage": "",
  "errorDetails": "",
  "success": true,
  "data": {
    "name": "Production Plan 18/08/2024 17:55:22",
    "productionOutputs": [
      {
        "powerPlantName": "windpark1",
        "generatedLoad": 90.0
      },
      {
        "powerPlantName": "windpark2",
        "generatedLoad": 21.6
      },
      {
        "powerPlantName": "gasfiredbig1",
        "generatedLoad": 460.0
      },
      {
        "powerPlantName": "gasfiredbig2",
        "generatedLoad": 338.4
      }
    ],
    "requestedLoad": 910,
    "totalGeneratedLoad": 910.0
  }
}
```