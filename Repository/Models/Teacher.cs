using System;

namespace Repository.Models
{
    public class Teacher
    {
        public Guid TeacherId {get; set;}
        public Guid SchoolId {get; protected set;}
        public string FirstName {get; protected set;}
        public string LastName {get; protected set;}
        public string Languages {get; protected set;}
        public string City {get; protected set;}
        public string Address {get; protected set;}
        public string ZipCode {get; protected set;}

        public Teacher(Guid teacherId, Guid schoolId, string firstName, string lastName, string languages, string city, string address, string zipCode)
        {
            TeacherId = teacherId;
            SchoolId = schoolId;
            FirstName = firstName;
            LastName = lastName;
            Languages = languages;
            City = city;
            Address = address; 
            ZipCode = zipCode;
        }
    }
}