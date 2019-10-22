# EventHubSpammer

This is the code sample related to [this](https://medium.com/@pugillum/the-azure-function-connection-limit-with-dependency-injection-c52982199cf1) blog post.  

EventHubSpammer-Before: Contains the code that will create a new EventHubClient for each call the Azure Event Hub, hitting the 600 connection limit
EventHubSpammer-After: Implements the reuse of the EventHubClient through the use of abstraction and Singleton service lifetime.

If you'd like to test it out, you'll need to do the following:
1. Create an Azure Event Hub service and copy the connection string
2. Deploy the Azure Function Host define in my code (I publish directly from VS 2019)
3. Update the app settings in the configuration of the Function App and set "EventHubConnectionString" to your connection string
4. Trigger via an HTTP Request (I used Postman).  You can find the URL of your function by selecting the function itself "EventHubSpammer" and then select the link "Get function URL" which includes the code to validate the calls.
