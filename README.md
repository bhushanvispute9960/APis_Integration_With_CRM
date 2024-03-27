**Overview**
This document provides detailed guidance on using the API to retrieve lead data from Dynamics CRM. The API uses Azure Active Directory (Azure AD) for authentication, ensuring secure access to data.

**Authentication:**
**1. Azure AD Setup**
Register an Application in Azure AD: Before using the API, we must register our application in Azure AD to obtain the client_id, tenant_id, and client_secret.
Navigate to the Azure portal.
Select "Azure Active Directory" > "App registrations" > "New registration".
Follow the prompts to complete the registration.
Permissions: Assign the necessary permissions to our application in Azure AD to access
Dynamics CRM data.
Go to "API permissions" > "Add a permission" > "Dynamics CRM".
Add permissions as required (e.g., Leads. Read).
Grant Admin Consent: Ensure that an administrator grants consent for the permissions requested by our application.

**2. Obtaining Access Tokens**
To authenticate API requests, you must obtain an access token from Azure AD.
Endpoint: https://login.microsoftonline.com/{tenant_id}/oauth2/v2.0/token
Method: POST
Headers:
Content-Type: application/x-www-form-URL-encoded
Body:
client_id={your_client_id}
scope=https://graph.microsoft.com/.default
client_secret={your_client_secret}
grant_type=client_credentials

**3. API Reference**
**1. Get Lead Data**
Retrieves lead data from Dynamics CRM.
URL: /api/leads
Method: GET
Authentication: Bearer Token (obtained from Azure AD)
Sample Request:
GET: /api/leads
Authorization: Bearer {access_token}


Response
Status Code: 200 OK
Body:
[
  {
    "emailAddress1": "gabriela@adatum.com",
    "address1Composite": "2345 Birchwood Dr\r\nRedmond, Washington 98101\r\nUnited States",
    "companyName": "A. Datum Corporation",
    "jobTitle": "Purchasing Manager"
  },
  {
    "emailAddress1": "josiah@alpineskihouse.com",
    "address1Composite": "3456 B Southampton Rd\r\nDallas, Texas 75073\r\nUnited States",
    "companyName": "Alpine Ski House",
    "jobTitle": "Store Manager"
  },
  {
    "emailAddress1": "harrison@fabrikam.com",
    "address1Composite": "6789 Edwards Ave.\r\nLynnwood, Tennessee 37010\r\nUnited States",
    "companyName": "Fabrikam, Inc.",
    "jobTitle": "Purchasing Manager"
  },
  {
    "emailAddress1": "jermaine@adatum.com",
    "address1Composite": "2345 Birchwood Dr\r\nRedmond, Washington 98101\r\nUnited States",
    "companyName": "A. Datum Corporation",
    "jobTitle": "Cafeteria Manager"
  },
  {
    "emailAddress1": "gerald@alpineskihouse.com",
    "address1Composite": "3456 B Southampton Rd\r\nDallas, Texas 75073\r\nUnited States",
    "companyName": "Alpine Ski House",
    "jobTitle": "Cafeteria Manager"
  },
  {
    "emailAddress1": "ivan@bellowscollege.com",
    "address1Composite": "678 Dayton\r\nColumbus, Ohio 43085\r\nUnited States",
    "companyName": "Northwind Traders",
    "jobTitle": "Purchasing Specialist"
  },
  {
    "emailAddress1": "halle@northwindtraders.com",
    "address1Composite": "678 Dayton\r\nColumbus, Ohio 43085\r\nUnited States",
    "companyName": "Northwind Traders",
    "jobTitle": "Facility Manager"
  },
  {
    "emailAddress1": "harriet@lucernepublishing.com",
    "address1Composite": "123 4th Ave.\r\nBellevue, Washington 98053\r\nUnited States",
    "companyName": "Lucerne Publishing",
    "jobTitle": "Cafeteria Manager"
  },
  {
    "emailAddress1": "rachel@alpineskihouse.com",
    "address1Composite": "3456 B Southampton Rd\r\nDallas, Texas 75073\r\nUnited States",
    "companyName": "Alpine Ski House",
    "jobTitle": "Purchasing Director"
  },
  {
    "emailAddress1": "alex@treyresearch.net",
    "address1Composite": "789 3rd St\r\nSan Francisco, California 94158\r\nUnited States",
    "companyName": "Trey Research",
    "jobTitle": "Cafeteria Manager"
  }
]
Error Handling
The API uses standard HTTP status codes to indicate the success or failure of requests.
200 OK:  The request was successful.
400 Bad Request: The request was invalid. Check your query parameters.
401 Unauthorized: Authentication failed. Ensure your access token is valid.
403 Forbidden: The authenticated user does not have permission to access the requested resource.
500 Internal Server Error: An unexpected error occurred on the server.
