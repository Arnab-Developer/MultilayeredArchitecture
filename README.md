MultilayeredArchitecture
========================

A sample to show how multilayered architecture can be implemented in software development.

Multilayered application is a particular type of software designing procedure in software engineering. 
In multilayered application we generally use three layers.
 

1. Data Access Layer (DAL) 
2. Business Logic Layer (BLL) 
3. User Interface Layer (UI) 


This can be sub divided in more layers depending on your application requirements. We write code for data access 
in DAL. Business logic for our application in BLL and user interface in UI. The advantage is that if there is a 
change in application business logic or data access or UI logic then we have to recompile the particular component 
only. So we implement this architecture to make our code maintainable. One other point is that I am also defining 
an interface for every component through which the calling component can interact. That means I decouple the 
service contract and the actual implementation of that contract. The calling component that will use that component 
will actually use the service contract (the interface) not the actual implementation. That is the benefit of 
interface which is in the definition: Interface is a service contract between service provider and service consumer. 
The service consumer does not need to know about the implementation details. They will only dealing with the service 
contract which is defined in the interface.
 
