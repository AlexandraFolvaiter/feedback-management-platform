# Feedback Management Platform

## Project description
Feedback Management Platform is a solution that helps companies to manage, organize and deliver feedback to their employees. 

The project has as scope to demonstrate how an organization can make use of features from the Microsoft Identity Platform in order to improve the existing processes in order to become more productive and transparent with the employees.

Based on the Microsoft Identity Platform, the application uses the MSLA to authenticate based on the user’s credentials, the Microsoft Graph to get data regarding employees,  and gives to the employee the opportunity to create and send feedback to his colleagues. In the case of a manager, he can see and analyze the feedback for his team.

## Implementation details
The application was built using .Net 6.0 Blazor Server App.

Microsoft Identity features used:

Microsoft Authentication Library - to authenticate the user using the credentials provided by the organization
Microsoft Graph - to get all users from the organization with multiple information and use that information depending on the scenario

Functionalities implemented
* Authentication with a valid account 
* View the Home page with useful information
* Create feedback forms for colleagues
* View all the feedback forms sent over time to colleagues
* View all feedback forms sent for the team

## How to run it
Prerequisites: 
* .Net 6.0 installed,
* Azure Active Directory created

Steps
1. Replace in appsettings.json the credentials for AD connection
2. Optional: Replace the InMemory database with a real one
3. Run the application

## Links
[Here](https://feedbackmanagementplatform.azurewebsites.net) is a link to the application.

[Here](https://youtu.be/LopuA8Reb9c) is a link to the demo.
