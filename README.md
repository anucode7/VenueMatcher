# VenueMatcher 

## Design details

* The design is following SOLID principles
* Single Responsibility principle is applied on all concrete implementations
* The strategy patterny gives us the abiltity to apply Open/Closed principle.
* If a new code is introduced we would just need to extend the enum,implement it and register it without modifying the core funcitons. 
* For distance calculation the geolocation package is used. Haversine formula could also be implemented if required.

## Solution details

* The solution consists of a class library. This could be used as a nuget or referece to be used with various clients. For demo purposes have added a console app.
* The class library provides "AddVenueLibrary" service collection which any client can use to use the class library services.
* DI has been added to the class library (IServiceCollection). This makes the library loosely coupled , and testable with mocking abilities.
* Xunit is used for unit testing the library.

