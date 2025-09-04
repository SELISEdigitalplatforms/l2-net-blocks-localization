## Key Timeline API Usage

### Endpoint
`POST /Key/GetTimeline`

### Description
Retrieves a paginated list of Key timeline entries with optional filtering.

### Request Body Example
```json
{
  "pageSize": 10,
  "pageNumber": 1,
  "entityId": "key-item-id-123", // Optional: Filter by specific Key ID
  "userId": "user-id-456", // Optional: Filter by user who made changes
  "createDateRange": { // Optional: Filter by date range
    "startDate": "2024-01-01T00:00:00Z",
    "endDate": "2024-12-31T23:59:59Z"
  },
  "sortProperty": "CreateDate", // Default: "CreateDate"
  "isDescending": true, // Default: true
  "projectKey": "your-project-key"
}
```

### Response Example
```json
{
  "totalCount": 25,
  "timelines": [
    {
      "itemId": "timeline-id-1",
      "entityId": "key-item-id-123",
      "projectKey": "your-project-key",
      "createDate": "2024-08-27T10:30:00Z",
      "lastUpdateDate": "2024-08-27T10:30:00Z",
      "currentData": {
        "itemId": "key-item-id-123",
        "keyName": "welcome.message",
        "moduleId": "auth-module",
        "resources": [...],
        "isPartiallyTranslated": false,
        "isNewKey": false
      },
      "previousData": {
        "itemId": "key-item-id-123",
        "keyName": "welcome.message",
        "moduleId": "auth-module",
        "resources": [...],
        "isPartiallyTranslated": true,
        "isNewKey": true
      },
      "logFrom": "KeyController.Save",
      "userId": "user-id-456",
      "rollbackFrom": null
    }
  ]
}
```

### Features
- **Pagination**: Use `pageSize` and `pageNumber` for pagination
- **Filtering**: Filter by `entityId` (Key ID), `userId`, or date ranges
- **Sorting**: Sort by any property with ascending/descending order
- **Timeline Tracking**: See both current and previous states of Keys
- **Audit Trail**: Track who made changes and when
