# Hello World Sample Application

This solution is broken down into four projects - The API, the API unit tests, the console client and the web client. There is also a small database located within the App_Data folder of the API project.

To get the project up and running, go into the /content folder of the web client project and run "npm install" to install all the script dependencies. Compile the entire project then run the debugger.

This should start both the API and web client projects in separate IIS Express instances - the API without a browser window and the web client with a browser window. The web client should automatically run and fetch the message from the API.

For the console client go to the bin/debug folder and run the executable. This should fetch the message from the API. 

While the messages are identical for the clients they are in fact different rows represented in the database.

## Project Notes

### API

Ninject is used as an IoC container and Dapper is used as the ORM. Requests should pass in a key via HttpGet and either receive the message corresponding to the key or a "not found" status/message.

### API Tests

Three unit tests are here which test
* proper key lengths
* invalid keys receive a "not found" status
* valid keys receive an "ok" status

### Console Client

This is a straight-forward console app which reads endpoint/apikey from configuration, requests the message, and outputs the result to screen.

### Web Client

Likewise the web client reads endpoint/apikey from configuration, requests the message and displays the result on the page. Vue is used for presentation.