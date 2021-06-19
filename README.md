# Test Automation Assessment

**Overview:**
This assessment will require candidates to do a short test automation coding exercise on a web based
application. The applicant can use JAVA, JavaScript, or C# programming languages.

**WebApp:** https://dev-screener.reitscreener.com/

Candidates are expected to do the following:
- Test cases creation (frontend and integration)
- Test framework coding/structure
- Usage of BDD
- Use Nada for the test email: https://getnada.com/

## Pre-requisites
* Windows OS
* Visual Studio

## Installation
**Clone the git repo**
```link
gh repo clone faithbrigole/QATest_Hov
```

**Install Visual Studio, .NET Core & the packages**
* Install Visual Studio
* .NET Core
* Start Visual Studio
* On the menu bar, create a project - Class library (.NET framework)
* Install the packages on NuGet Solution
  - NUnit
  - NUnit3 Test Adapter
  - Selenium Support
  - Selenium Webdriver
  - Selenium Chromedriver
  
  ***optional - For API Testing***
    - AutoMapper
    - NewtonsoftJson

## About the automation
### **Code explanation:**
I created five (5) class for this project. 
  - TestBase.cs
  - BasicActions.cs
  - RegisterTestSuite.cs
  - SigninTestSuite.cs
  - NadaAPI.cs
  
 #### TestBase.cs
 This is where I put the drivers. For this project I only put the chromedriver because there is no cross browser testing on the instruction. I also created *LevelOfParallelism* so that there's more than one program that can be executed simultaneously, depending on the number of parallelism you put. For this project I only put 4. This also calls the BasicAction.cs that calls the URL of this project.
 
 #### BasicActions.cs
 To make the test more clean I created this class. I call this the backend of my testing. The register and the Signin test suites are the frontend. In order for the tests to run it must call the commands in the basic actions class.
 
 #### RegisterTestSuite.cs
 All the possible test cases in the register page is in here. This test suite consist of 5 tests.
 
 #### SignintestSuite.cs
 Same with RegisterTestsuite.
 
 #### NadaAPI.cs
 Honestly, this one is a failed test. I actually want to create an API testing to verify the email using Nada temp mail. I'm having a hard time getting the email content. And to be honest I have a limited knowledge on JSON API. I didn't delete this class because I'm considering on creating automation testing for email confirmation/verification and also I'm hoping that I'll find a solution to this problem and **hopefully** I can update this one.
 
 
 ## Issues
 Only the API Testing but overall the test works fine.
 
 

