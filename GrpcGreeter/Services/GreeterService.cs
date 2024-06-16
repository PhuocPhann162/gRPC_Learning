using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<PersonList> ListPersons(Empty request, ServerCallContext context)
        {
            var persons = new List<Person> {
               new Person()
               {
                   Name = "John Doe",
                   Id = 1,
                   Email = "john.doe@example.com",
                   Phones = { new Person.Types.PhoneNumber { Number = "1234567890", Type= Person.Types.PhoneType.Mobile} },

               },
               new Person()
               {
                   Name = "Jane Smith",
                   Id = 1,
                   Email = "jane.smith@example.com",
                   Phones = { new Person.Types.PhoneNumber { Number = "0934723846", Type= Person.Types.PhoneType.Work} },

               },
               new Person()
               {
                   Name = "Phuoc Phan",
                   Id = 1,
                   Email = "fuco.phan@example.com",
                   Phones = { new Person.Types.PhoneNumber { Number = "0942356759", Type= Person.Types.PhoneType.Home} },
               }
           };

            var response = new PersonList();
            response.Persons.AddRange(persons);
            return Task.FromResult(response);
        }
    }
}
