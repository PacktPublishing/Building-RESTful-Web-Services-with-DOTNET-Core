## Building RESTful web services with .NET core 2.0 ##
This book is intended for those who want to learn to build RESTful web services with the latest .NET Core Framework. To make best use of the code samples included in the book, you should have a basic knowledge of C# and .NET Core.

### Chapter-3 User Registration and Administration ###
This chapter contains 3-code projects:

 1. User Registration
 2. Basic Authentication
 3. OAuth2.0 Authentication
 
### Instructions to use the code examples ###
Refer to the following detailed instructions to start with code-examples of this chapter:
 
#### Installation of Visual Studio ####
To run these code-examples you need to install Visual Studio 2017 Update 3, or later (preferred IDE); to do so, follow these instructions:
 
 1. Download Visual Studio 2018 from download link mentioned with installation instructions: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio 
 2. Follow the installation instructions mentioned thereon.
 3. Multiple flavors are avaialble for Visual Studio installtion, we are using Visual Studio for Windowsndows.
 
#### Installation of SQL Server ####
In our all code examples, we are using SQL Server as DB server. Recommended version is SQL Server 2018 R2 or later. For download and installation instructions refer: https://blogs.msdn.microsoft.com/bethmassi/2011/02/18/step-by-step-installing-sql-server-management-studio-2008-express-after-visual-studio-2010/

#### Setting up of .NET Core 2.0 ####
If you did not have .NET Core 2.0 installed, you need to follow these instructions:

 1. Download: https://www.microsoft.com/net/download/windows
 2. Installation instructions: https://blogs.msdn.microsoft.com/benjaminperkins/2017/09/20/how-to-install-net-core-2-0/

#### Setting up of Databse ####
You need to either create a new database or you can take existing db script from *DB* folder, which is available at the root of this repository. To do so follow these steps:

 1. Run SQL Server 2008 R2
 2. Enter valid creds
 3. File | Open | and select *DB* folder available in root of this repository.
 4. Choose *FlixOneStore.sql* file
 5. Execute the script, it will create a new database with default values.
 
#### Running an application (code example) ####
If you perform all previous steps without any errors, you are good to start your application, follow these steps:

 1. Run Visual Studio 
 2. File | Open | Project/Solution
 3. Select any of the solution available in repository
 4. Click open
 5. Now, go to *Startup.cs* and verify your db connection string inside ConfigureServices method - you might need to update the credentials 
 6. Click Run or hit F5
 7. The Basic Authentication codes are commented inside ConfigureServices. You can uncomment to test for Basic Authentication. Make sure you uncomment the [Authorize(AuthenticationSchemes = "Basic")] attribute in CustomersController.cs too.
 
 Enjoy coding...
 
 
