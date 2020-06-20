<p><strong>Sample Microservices Architecture using .net Core, RabbitMQ and Docker</strong></p>
<p>
I created this simple application to practice and demonstrate an architecture in microservices with the approach of Domain-Driven Design(DDD).
</p>
<p>
It has two bounded contexts, Sales and Warehouse which communicate with each other through RabbitMQ message broker. 
</p>
<p>
The microservices were dockerized and implemented fully decoupled and not directly call each other but with publishing and subscribing to events. 
</p>
<p>
There are two kinds of events, Domain and Integration events with the consideration of eventual consistency which provided by NHibernate event listeners.
</p>
<p>
Domain events are just raised in-process (in-memory) and within the same transaction or operation while Integration events first persist in a transactional database and then are published to the message broker by a worker service. 
</p>
<p>
Command Pattern provided by MediatR is used to handle new requests which are sent to the microservices.
</p>
<p>
I also created a Single Page Application(SPA) with Angular Js which currently just sends creation of order to the Sales microservice. I have not created any API Gateway yet but I will.
</p>
