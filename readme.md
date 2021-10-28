
# Travel Review API

### By Charles Weber, Becket Harvey, Anna Clarke

A travel review api that hosts a database containing user submitted reviews of different destinations.

## Technologies Used
* C#
* VS Code
* ASP.NET Core MVC
* MySQL
* Entity Framework Core v 5.0
* Swagger
* Postman(Or Thunder Client Extension in VSCode)
* NewtonsoftJson
* Copious amounts of caffeine

## Description
This api database contains reviews and destinations. Users can access different endpoints in apicalls to this api to view, edit, create and delete reviews and destinations. Users can also access a random review or search reviews by rating through api endpoints.

### Prerequisites


**Install .NET Core**
  * Mac:Install [here](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-2.2.106-macos-x64-installer)
  * Windows: Install [here](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-2.2.203-windows-x64-installer)

**Install dotnet script**

Use the command ```dotnet tool install -g dotnet -script in a terminal```



## Setup and Use


**Cloning/Obtaining API File**
1. Navigate to the [TravelReviewAPI](https://github.com/Sunshinepunch/TravelReviewAPI)
2. Clone or download the repo - follow [these~instructions](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository) if this is your first time.
3. Open up your system Terminal or CMD prompt application in the directory you wish to host the project
4. Clone the repository using ```$ git clone https://github.com/Sunshinepunch/TravelReviewAPI.git``` within the project directory

**AppSettings**

1. Create new file appsettings.json in TravelReviewGuide/Travel
2. Add the following code to the new appsettings.json, replacing the YOUR_PASSWORD_HERE with your mySQL password

        {  
          "Logging": {  
            "LogLevel": {  
              "Default": "Information",  
              "Microsoft": "Warning",  
              "Microsoft.Hosting.Lifetime": "Information"  
            }  
          },  
          "AllowedHosts": "*",  
          "ConnectionStrings": { 
            "DefaultConnection": "Server=localhost;Port=3306;database=travel_review;uid=root;pwd=YOUR_PASSWORD_HERE;", 
            "ConnStr": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SarathlalDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"  
          },  
          "JWT": {  
            "ValidAudience": "http://localhost:5000",  
            "ValidIssuer": "http://localhost:5000",  
            "Secret": "TornadoOfZombiesWereWolves"  
          }  
        } 

**Database Setup**
1. In terminal, navigate into TravelReviewGuide/Travel and run command ```dotnet ef database update``` to build database

2. OPTIONAL : You can run the project with no data and update with your own content OR seed the project with pre-built data by following the following steps. (The project comes with pre-seeded data, but this can be replaced)
  - Navigate to the Models/TravelContext.cs file
  - Override the ```OnModelCreating(ModelBuilder builder)``` with the following code:
    >     protected override void OnModelCreating(ModelBuilder builder)
            {
            builder.Entity<Destination>()
            .HasData(
            new Destination { DestinationId = 1, Name = "YOUR INPUT HERE"},
            new Destination { DestinationId = 2, Name = "YOUR INPUT HERE"},
            );
            builder.Entity<Review>()
            .HasData(
            new Review { ReviewId = 1, Rating = [INTEGER HERE], Comment = "YOUR INPUT HERE", DestinationId = 1},
            new Review { ReviewId = 2, Rating = [INTEGER HERE] , Comment = "YOUR INPUT HERE", DestinationId = 2},
            );


**Launch API in Server**
1. In TravelReviewGuide/Travel, run command ```dotnet run``` to open the api in your browser

## 🛰️ API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using Swagger Documentation 
To explore the API with Swagger, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

..........................................................................................

### Endpoints
Base URL: `http://localhost:5000`

#### HTTP Request Structure
```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```

#### Example Query
```
https//localhost:5000/api/reviews/1
```

### Reviews
Access information about the posted reviews

#### HTTP Request
```
GET /api/Reviews
POST /api/Reviews
GET /api/Reviews/{id}
PUT /api/Review/{id}
DELETE /api/Review/{id}
GET /api/Reviews/Search/?{parameter}
GET /api/Reviews/Search/reviews/{parameter}
GET /api/Reviews/Random
```

#### Path Parameters

| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| rating | int | none | true | Return matches by rating.
|DestinationId | int | none| true| returns matching reviews fo a single destination | 


#### Example Query
```
http://localhost:5001/api/Reviews/search?rating=3
```

#### Sample JSON Response
```
[
  {
    "destination": {
      "reviews": [],
      "destinationId": 9,
      "name": "Planet Earth"
    },
    "reviewId": 16,
    "rating": 3,
    "comment": "too many humans",
    "destinationId": 9
  }
]
```
### Description
Access information about the Destinations to review

#### HTTP Request
```
GET /api/Destinations
POST /api/Destinations
GET /api/Destination/{id}
PUT /api/Destination/{id}
DELETE /api/Destination/{id}
GET /api/Destination/Search?{parameter}
```

#### Path Parameters

| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | true | Return matches by Name.|



#### Example Query
```
http://localhost:5000/api/Destinations/search?name=MY%20HOUSE
```

#### Sample JSON Response
```
[
  {
    "reviews": [
      {
        "reviewId": 15,
        "rating": 5,
        "comment": "Test",
        "destinationId": 6
      },
      {
        "reviewId": 17,
        "rating": 5,
        "comment": "In the middle of the street",
        "destinationId": 6
      }
    ],
    "destinationId": 6,
    "name": "MY HOUSE"
  }
]
```

------------------------------

### 🤝 Contributors

| Author | GitHub | Email |
|--------|:------:|:-----:|
| [Charles T Weber](https://www.linkedin.com/in/charles-t-weber/) | [CharWeber](https://github.com/CharWeber) |  [charlestweber@gmail.com](mailto:charlesweber@gmail.com) |
| [Anna Clarke](https://www.linkedin.com/in/anna-k-clarke/) | [Messquerade](https://github.com/Messquerade) |   |
| [Becket Harvey](https://www.linkedin.com/in/becket-harvey-sunshine/) | [SunshinePunch](https://github.com/SunshinePunch) |  [charlestweber@gmail.com](mailto:charlestweber@gmail.com) |

------------------------------