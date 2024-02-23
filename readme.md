# Rainfall API

## Overview
Rainfall API is web API built using .NET Core 8.0 and provides rainfall reading data. 

## Prerequisites
.NET Core 8.0 SDK

## Nuget Packages Used
These can be installed by running `dotnet restore`
### MediatR
Simple mediator implementation in .NET. In-process messaging with no dependencies. 

Supports request/response, commands, queries, notifications and events, synchronous and async with intelligent dispatching via C# generic variance.
### Swashbuckle.AspNetCore
Swagger tooling for APIs built with ASP.NET Core. Generate beautiful API documentation, including a UI to explore and test operations, directly from your routes, controllers and models.

### Swashbuckle.AspNetCore.Annotations
Includes a set of custom attributes that can be applied to controllers, actions and models to enrich the generated Swagger


## How to run
To validate if it compiles:
`dotnet build`

To run the API:
`dotnet run`

For the unit tests, go to the unit test directory and run this command:
`dotnet test`

## Base URL
`http://localhost:3000/api/rainfall`

## Endpoints

### Get Rainfall Readings


`GET /api/Rainfall/id/{stationId}/readings?count={count}`

#### Description

Get the rainfall readings for the station ID in the request. Count is used to limit the number of responses.

#### Parameters

- `stationId` (required): The ID of the target station.
- `count` (optional): The number of response readings. Default value is 10 if none provided. Valid range of values is from 1 to 100.

#### Responses
- **200 OK:** Successful response with a collection of rainfall readings.
```json
{
  "items": [
    {
      "dateMeasured": "2024-02-06T21:30:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-31T21:30:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T00:00:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T00:15:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T00:30:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T00:45:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T01:00:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T01:15:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T01:30:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T01:45:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T02:00:00Z",
      "amountMeasured": 0
    },
    {
      "dateMeasured": "2024-01-24T02:15:00Z",
      "amountMeasured": 0
    }
  ]
}
```

- **400 Bad Request:** Invalid request, with details about the error.
```json
{
  "errors": 
  [
    {
      "message": "Invalid Count",
      "detail": [
        {
          "propertyName": "Count",
          "message": "Count should be between 1 to 100."
        }
      ]
    }
  ]
}
```
- **404 Not Found:** Not Found, with details about the error.
```json
{
  "errors": 
  [
    {
      "message": "No rainfall readings found for Station ID",
      "detail": [
      ]
    }
  ]
}
```
- **500 Internal Server Error:** Internal Server Error, with details about the error.
```json
{
  "errors": 
  [
    {
      "message": "",
      "detail": [
      ]
    }
  ]
}
```