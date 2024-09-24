using System.Runtime.Serialization;

namespace RestApi.Infrestructure.Soap;

[DataContract]

public class UserResponseDto
{

        [DataMember]
        public Guid Id {get; set; }
        [DataMember]
        public String Email {get; set; } = null!;
        [DataMember]
        public String FirstName {get; set; } = null!;
        [DataMember]
        public String LastName {get; set; } = null!;
        [DataMember]
        public DateTime BirthDate {get; set; }
    
}

