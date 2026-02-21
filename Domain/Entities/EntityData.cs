using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public abstract class EntityData
    {
        
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public string Address {get; set;}
        public string Phone {get; set;}
        public string Email {get; set;}

        public EntityData(string lastName, string firstName, string address, string phone, string email)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }

        public EntityData()
        {
            
        }

        //Metodo Abstracto 
        //Metodo de expediente (estudiante = para generar num carnet, aplicante = para generar num expediente de alta)

        public abstract string ShowId ();
    }
}