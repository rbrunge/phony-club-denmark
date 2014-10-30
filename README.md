phony-club-denmark
==================

Site used for creating EPiServer Boilertemplate. Code-files from solution will be extracted to a nuget-package which can
be deployed to other new solutions.

The code can be explained as a very light version of Ally Demosite. Code includes:
- Media-types: jpg, pdf, ...
- First page set up , but you still need to create EPiServer structure.

After installing a new site via Visual Studio, the package can be applied using nuget:

Local:
  install-package -source C:\EPiServer\phony-club-denmark\_nuget Ebita.EPiServer.BoilerTemplate75
  
But first - you need the nuget-package. Go to folder "_nuget" and run command: 
  nuget-pack.bat
  
This will result in a nuget-package named 
  Ebita.EPiServer.BoilerTemplate75.[version].nupkg
  
  
And the bad news: you have to change a lot of places :-)

web.config:
- ImageResizer packages, make sure elements and plugings exists
- Setup search-indexer (EPiServer Search -- not FIND)
- 

and more
