using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Aplicant : EntityData
    {
        //Forma de aplicar métodos get y set a propiedades publicas 
        public string ShiftId {get; set;}
        public string ExamenId {get; set;}
        public string CarreraId {get; set;}
        public string JornadaId {get; set;}

        public override string ShowId()
        {
            return $"El número de expediente es: {ShiftId}";
        }
    }
}