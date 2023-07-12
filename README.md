# UniClassAPI
A RESTful API in ASP.NET MVC to fulfil the test task for .NET internship. Contains 3 entities, Student, Major and Funding. Student and Major have one-to-many relation and Student and Funding have one-to-one relation and Funding is represented as an enum that denotes the financial situation of the Student (i.e. scholarship, self-financed, etc.)   

Visit this [link](https://uniclassplan.azurewebsites.net/swagger/index.html) for the deployed API: 
 https://uniclassplan.azurewebsites.net/swagger/index.html    
 
 P.S.: The API uses an interactive documentation <mark>in</mark> **Swagger**
## Students
### Getting the student details
Returns the details of all users in the database
```
GET https://uniclassplan.azurewebsites.net/api/Student
```
The response is a list of Student objects. An empty array is returned if no student is found in the database
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
[
  {
    "id": "5b8d9c60-e4d9-4cc5-81c6-085846d2d8a5",
    "fullName": "Mavluda Asalxodjaeva",
    "funding": 1,
    "dateOfBirth": "1979-12-13T00:00:00",
    "majorId": "4912c961-39d9-4ba1-b035-523e700280c0",
    "major": null
  },
  {
    "id": "5c5e59cb-aa76-4a24-a1d6-0ff904d0cfb9",
    "fullName": "Munisa Rizaeva",
    "funding": 1,
    "dateOfBirth": "1980-11-24T00:00:00",
    "majorId": "4912c961-39d9-4ba1-b035-523e700280c0",
    "major": null
  },
  {
    "id": "fd0907e7-8362-4397-b198-b302a53274f4",
    "fullName": "Malika Temurova",
    "funding": 0,
    "dateOfBirth": "2023-07-11T00:00:00",
    "majorId": "9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c",
    "major": null
  },
  {
    "id": "ca2089a7-327b-44c7-9d2a-edcbe3049991",
    "fullName": "Sitora Tulyaganova",
    "funding": 2,
    "dateOfBirth": "1981-03-12T00:00:00",
    "majorId": "33977982-bbe3-44ed-89e4-00cad7e6f6ed",
    "major": null
  }
]
```
Where a student object is:
|   Field   |  Type  |                  Description                  |
|-----------|--------|-----------------------------------------------|
|     id    | String |      A unique identifier for the student      |
|  fullName | String |      The student's name in the database       |
|  funding  | Integer| The funding of the student (i.e. scholarship) |
|dateOfBirth| String |         The student's date of birth           |
|  majorId  | String |  A unique identifier for the student's major  |
|   major   | Object |       A reference to the student's major      |

Possible errors:
|   Error Code   |                    Description                     |
|----------------|----------------------------------------------------|
|401 Unauthorized|   The access token is invalid or has been revoked  |

## Majors
### Getting the details of all majors
Returns the details of all majors in the database
```
GET https://uniclassplan.azurewebsites.net/api/Major
```
The response is a list of Major objects. An empty array is returned if no majors are found in the database
Example response
```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
[
  {
    "id": "33977982-bbe3-44ed-89e4-00cad7e6f6ed",
    "name": "Commercial Law",
    "students": null
  },
  {
    "id": "9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c",
    "name": "Business Information Systems",
    "students": null
  },
  {
    "id": "4912c961-39d9-4ba1-b035-523e700280c0",
    "name": "Business Management",
    "students": null
  }
]
```
Where a major object is:
|  Field   |  Type  |                     Description                        |
|----------|--------|--------------------------------------------------------|
|    id    | String |           A unique identifier for the major            |
|   name   | String |                The nameof the major                    |
| students | Object |A reference to the list of students who chose this major|

Possible errors:

|   Error Code   |                    Description                     |
|----------------|----------------------------------------------------|
|401 Unauthorized|   The access token is invalid or has been revoked  |

