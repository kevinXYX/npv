# Net Present Value Calculator App

## Prerequisites

Visual Studio 2017

Visual Studio Code (optional)

If your local computer doesn't have Node.js installed, you will need it because this app is built using Angular 5, go to https://angular.io/guide/quickstart to get started

## Built With

* ASP.NET Core 2.1
* Angular 5
* Bootstrap 3
* SQLLite

## Getting Started

After cloning the app, Open VisualRiskNPV.sln and just Rebuild the solution.

## Running the App

To run the app you can either select a Multiple startup projects and select NPV.Api and NPV.Web or running the NPV.Api standalone and using Visual Studio Code for the UI. 

If you chose to use Visual Studio Code here are the steps:

1. Browse the project folder and select\NPV.Web\ClientApp folder
2. Open the Terminal (ctrl + ~) 
3. Type npm start to build and run the project
4. Browse http://localhost:4200

## App Configuration

To make sure that the UI will connect to NPV.Api, go to NPV.Web\ClientApp\src\environments\environment.ts and check if the url is the same in NPV.Api -> Properties -> Debug -> App URL

## Tests

All tests should go to NPV.Tests, When adding new test that requires service injectables use the ServiceTestsLocator class, (see CalculationTests and PreviousResultsTests for implementation)

## Author

Kevin Jun M. Rodriguez
