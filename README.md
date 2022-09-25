# Summary

Two projects, Angular and API.

## API

Run `dotnet restore` to restore the packages if needed.

Config connection string in appsettings.json. In DefaultConnection section, use your own PostgreSql user id and password to replace the placeholders.

Run `dotnet ef database update` to create the database and seed data.

Run `dotnet run` to run the API, the url is `http://localhost:5217`.

Use pgAdmin 4 or PostgreSQL plugin in VS code to inspect the database.

Use Postman to test two endpoints

### Endpoints

GET api/courses/lesson returns the lesson list incuding id and name. The requests in postman collection can not be used directly because all the ids are generated and not hardcoded. Therefore the ids will be different when database is updated. Use this endpoint to get the latest ids of lessons, then use the new ids to test the rest endpoints.

GET api/courses/lesson/{id} returns the complete detail of lesson including the course section based on passed lesson Id.

POST api/courses/watchLog/{lessonId}?pw={percentageWatched} - create an new record on watchLog table, after this API is successful, the isCompleted field on the get lesson detail API will be updated.

The API supports authentication, which means a token is needed to carry user id to the endpoints. You can use third party tool(`http://jwtbuilder.jamiekurtz.com/`) to generate a token with the secret key `this is the token secret`. This is the key stored in appsettings.json to validate the token. Or you can use Token endpoint in API.

#### Token endpoint

POST api/auth/login/{userName} to login and get a token. Password is not required. If the userName is in database, API will issue a token with existing user id. If the userName is new and not in database, then the new user will be created in database and a token contains newly created user id will be issued.

## Client

Run `npm install` to install all the dependencies.

Run `ng serve` to run the app, the url is `http://localhost:4200`.

The app provides a simple UI to interact with the endpoints. Because all lesson ids are generated and not hardcoded, the only way to get the ids is to inspect the database. It is recommended to test API by using Client, because all the lesson will be displayed on the home page. And API supports issuing new token. Logging in the client will call the API to issue a token back to the client. Then the interceptor in client will carry the token to API, there is no need to take care of the token manually.

### Note

The app supports both anonymous user and logged in user. The isCompleted will be different according to authentication. For an anonymous user, the isCompleted will be true as long as anyone has completed the lesson. For a logged in user, the isCompleted will only be true if the user has completed the lesson.
