using System;

namespace Api.ViewModels
{
    public class TeacherViewModel
    {
        public Guid TeacherId {get; set;}
        public Guid SchoolId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Languages {get; set;}
        public string City {get; set;}
        public string Address {get; set;}
        public string ZipCode {get; set;}
        public DateTime CreatedAt {get;set;}
        public DateTime ChangedAt {get; set;}
    }
}