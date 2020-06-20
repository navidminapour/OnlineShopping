<p><strong>Sample Microservices Architecture with using .net Core, RabbitMQ and Docker</strong></p>
<p>
I created this simple application to demonstrate an architecture in microservices with the approach of Domain Driven Design(DDD).
It has two bounded contexts, Sales and Warehouse which communicate with each other through RabbitMQ message broker.
The microservices were implemented fully decoupled and not directly call each other but with publishing and subscribing to events. 
There are two kinds of Domain and Integration events with the consideration of eventual consistency which provided by NHibernate event listeners.
Integration events persist in a database before publishing on the message broker and a worker service is responsible to do this. 
Besides, Requests to the microservices were handled by MediateR which provides command pattern.
I also created a Single Page Application(SPA) with Angular 
I would like to share the technologies 
</p>