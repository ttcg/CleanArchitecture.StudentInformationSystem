using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using StudentInformationSystem.Domain.Common;
using StudentInformationSystem.Domain.Events;

namespace StudentInformationSystem.Domain.UnitTests
{
    public class TypeCasting
    {
        [Test]
        public void test()
        {
            var studentEnrolledEvent = new StudentEnrolledEvent(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            var myInterface = (IExternalEvent)studentEnrolledEvent;


            var myJson = JsonConvert.SerializeObject(myInterface, Formatting.Indented);

            var myJson2 = System.Text.Json.JsonSerializer.Serialize(myInterface, new System.Text.Json.JsonSerializerOptions { IncludeFields = true }); 

            //var domainEvent = (DomainEvent)studentEnrolledEvent;

            //var abc = domainEvent.GetType().UnderlyingSystemType;

            //var x = (domainEvent.GetType().UnderlyingSystemType) domainEvent;

            //var convertedType = Activator.CreateInstance(
            //    domainEvent.GetType().UnderlyingSystemType, domainEvent);
        }
    }
}
