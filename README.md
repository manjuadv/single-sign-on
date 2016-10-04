This is a single-sign-on solution. This solution was built to demonstrate software architectural skills for an assessment. The key of this solution is the scalability and extendibility implemented using design patters. Other areas like front-end were not a focus in this specific solution.

Pelase see Design.doc to get an idea about the design, architecture and usage of design patterns. There is a screen capture in folder "Wink" showing how the solution works. This screen capture can be run by opening wink.htm (flash plug-in needed in the web browser).

Key features
===================================================================================================================
1. The solution has been built as an HTTP Module so the solution can be integrated to any ASP.net website by just adding some entries in web.config without writing any code. 
2. I have integrated the solution with .net built in authentication framework so the authentication mechanism works well with other .net features.
3. Solution can be configured to run with several possible identity data providers.
4. Solution can be extented easily to run with new type of identity data providers.

1. Configuring the system
===================================================================================================================
The application is design to run on various type of user identity data sources. System currently has functionality work with following three data sources.
	- With an LDAP server.
	- With an XML data file which keeps user login information.
	- Using an in memory data base (mainly designed to test the system easily).

Authentication identity data provider can be changed by changing following web.config entry in WCF web service (SSOService project).

 <appSettings>
    <add key="authenticationProvider" value="xmlDb"/>
  </appSettings>

Following values can be used to switch the identity data provider.
	xmlDb 		- Xml database.
	ldap  		- LDAP server.
	InMemory	- In memory test database.		

If the system is going to be used with an LDAP server, there should be an LDAP server giving user information. I installed ApacheDS locally and used it.
Please note that LDAP server solution has following limitations because of the time factor.
	- System searches only the domain example.com (dc=example,dc=com)
	- Supports only these four groups Admin,Accountent,Everyone,Sales

If the system is going to be used with the XML database, a simple XML file is generated with some testing data when the very first request comes to the system.
The XML file can be edited manually to added new users. 

Test accounts used in XML Db and In Memory database are bellow.

	Login Name			Password		User Groups				Display Name
	---------------			--------------		--------------------			---------------------
	pathmakumaraad@gmail.com	abc123			Admin,Accountent,Everyone		Manjula Ranasinghe
	hmatin@gmail.com		123abc			Accountent,Everyone			Holder Martin
	msukenton@gmail.com		123abc			Sales,Everyone				Michal Sukenton
	lkusker@gmail.com		123abc			Accountent,Sales,Everyone		Linton Kusker

Following configuration should be added to web.config file of any website that uses this SSO solution.

	- Reference should be added to SingleSignOnModule (which is a project under my solution file). As HTTP Module as bellow. 
		  <system.webServer>
    			<modules>
      				<add name="SSOHttpModule" type="SingleSignOnModule.SSOHttpModule"/>
    			</modules>
  		</system.webServer>
	
	- URL of login website ("TestApp Login System" project under my solution)
		<appSettings>
    			<add key="SingleSignOnURL" value="http://localhost:8545" />
  		</appSettings>


2. Building the solution
===================================================================================================================
I have used following third party librarie(s) described bellow. The .dll file(s) are in "Lib" folder. All other references are project within the solution.
	
	Library			Projects used by						Purpose
	-----------------	-----------------------------					--------------------------------
	FizzWare.NBuilder.dll	TestApp_01 Accounting System, TestApp_02 Admin System	 	Test data generation











			

