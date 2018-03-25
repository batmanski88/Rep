using System;

namespace Repository.Models
{
    public class School
    {
        public Guid SchoolId {get; protected set;}
        public string SchoolName {get; protected set;}
        public string Address {get; protected set;}
        public string City {get; protected set;}
        public string ZipCode {get; protected set;}
        public SchoolKind SchoolKind {get; protected set;}
    }

    public enum SchoolKind
    {
        SzkolaPodstawowa,
        Liceum,
        Studia
    }
}