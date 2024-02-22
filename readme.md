# Rainfall API

## Overview
Rainfall API is web API built using .NET Core 8.0 and provides rainfall reading data. 

## Base URL
`http://localhost:3000/api/rainfall`

## Endpoints

### Get Rainfall Readings


`GET /api/Rainfall/id/{stationId}/readings?count={count}`

#### Description

Get the rainfall readings for the station ID in the request. Count is used to limit the number of responses.

#### Parameters

- `stationId` (required): The ID of the target station.
- `count` (optional): The number of response readings. Default value is 10 if none provided.

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