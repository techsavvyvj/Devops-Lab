# Hello World Sample Application

This solution is built in VS 2017, targeting the .Net 4.7.1 framework and is broken down into four projects - the API, the API unit tests, the console client and the web client. There is also a small database located within the App_Data folder of the API project.

To get the project up and running, go into the /content folder of the web client project and run "npm install" to install all the script dependencies. Compile the entire project then run the debugger.

This should start both the API and web client projects in separate IIS Express instances - the API without a browser window and the web client with a browser window. The web client should automatically run and fetch the message from the API.

For the console client go to the bin/debug folder and run the executable. This should fetch the message from the API. 

## Project Notes

### API

There is a single controller to handle CRUD requests against a "Message" model. The Read request has been built out while the others have been stubbed for future work.

To support sending different messages to different clients there is a database table of messages with each message having its own ApiKey, Message, Mode (indicating if the message is intended for web, console, etc) and Detail (if more information needs to be attached to the message).

The message provider contains corresponding CRUD methods to support the API requests. It is built on a generic provider interface that supports future providers performing read and write operations on different model types to different data sources.

Before returning the result to the requestor the raw message model is mapped to a return body format in the controller. 

Ninject is used as an IoC container and Dapper is used as the ORM. Requests should pass in a key via HttpGet and either receive the message corresponding to the key or a "not found" status/message.

### API Tests

Three unit tests are here which test
* proper key lengths
* invalid keys receive a "not found" status
* valid keys receive an "ok" status

The tests are in a single class whose constructor creates a "system under test" that is made available to the test methods.

### Console Client

This is a straight-forward console app which reads endpoint/apikey from configuration, requests the message, and outputs the result to screen. 

### Web Client

Likewise the web client reads endpoint/apikey from configuration and outputs it into client script while displaying a waiting indicator. The main page script sends a request to the API via jQuery using the configuration information and either displays the returned message or an error if the request failed. Vue is used to manipulate the presentation.

As currently designed the web client receives a different message row from the API (compared to the console client) although the message itself is the same.