using System;

namespace Repository.Models
{
    public class Teacher
    {
        public Guid TeacherId {get; protected set;}
        public Guid SchoolId {get; protected set;}
        public string FirstName {get; protected set;}
        public string LastName {get; protected set;}
        public string Languages {get; protected set;}
        public string City {get; protected set;}
        public string Address {get; protected set;}
        public string ZipCode {get; protected set;}
        public DateTime CreatedAt {get; protected set;}
        public DateTime ChangedAt {get; protected set;}
        public virtual School School {get; protected set;}

        public Teacher(Guid teacherId, Guid schoolId, string firstName, string lastName, string languages, string city, string address, string zipCode)
        {
            TeacherId = teacherId;
            SetSchoolId(schoolId);
            SetFirsName(firstName);
            SetLastName(lastName);
            SetLanguages(languages);
            SetCity(city); 
            SetAddress(address);
            SetZipCode(zipCode);
            CreatedAt = DateTime.UtcNow;
        }

        protected Teacher()
        {
            
        }

        public void SetSchoolId(Guid schoolId)
        {
            SchoolId = schoolId;
        }
        public void SetFirsName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetLanguages(string languages)
        {
            Languages = languages;
        }

        public void SetCity(string city)
        {
            City = city;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}