# backend

## Getting started
To #RUN and deploy this application in a docker,


1- Make sure that you are inside the backend floder


2- Open terminal 


3- Tap this command : docker-compose up 


4- Go to navigator and follow this link: #https://localhost:63497/graphql/

## Project architecture
There are 4 API developed with .Net core (.NET 6)


1- GraphQLAPI : is the gateway to our backend


2- TravelAgencyAPIs : REST API handling the customers service


3- ProductAPI : REST API handling the products service

4- CustomerFileAPI : REST API handling the customer's document for traveling

SharedLib represents the data layer of the application : Entities and Business logic

Database : Sqlite DB will be deployed automatically when runing the APIs.

## Testing
We have insert 2 customers in our database :

1- Montassar KLILA KERKENI

2- Francesco TOTTI

You can use thoose names to test GraphQL query :
- customerFileByName(first_name,last_name)


