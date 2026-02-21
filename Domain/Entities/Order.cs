using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement.Domain.Entities
{
    // Plantilla -> Clase
    public class Order
    {
        //Características -> Propiedades
        private readonly string _OrderId = Guid.NewGuid().ToString(); //Acá se genera automaticamente el valor y solo permite leer el dato gracias al readOnly
        private EntityType _EntityType;
        private OperationType _OperationType;
        private OrderStatus _Status;
        /*Error por no tener instancia
        private Aspirantes _Data;
        */
        /*
        Sin error por que acá ya se genera la instancia en la clase
        private Aspirantes _Data = new Aspirantes();
        */
        private EntityData _EntityData;
        //

        //Acceso a una propiedad privada
        public string OrderId
        {
            get
            {
                return _OrderId;
            }
            /* Al tener readOnly no se pueden asignar valores más que solo leer el dato
            set
            {
                _OrderId = value;
            }
            */
        }

        public EntityType EntityType
        {
            get
            {
                return _EntityType;
            }
            set
            {
                _EntityType = value;
            }
        }

        public OperationType OperationType
        {
            get
            {
                return _OperationType;
            }
            set
            {
                _OperationType = value;
            }
        }

        public OrderStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        //Acá se referencia la clase a donde pertence el dato
        public EntityData EntityData
        {
            get
            {
                return _EntityData;
            }
            set
            {
                _EntityData = value;
            }
        }
        //
        //Acciones -> Funciones
        public void MarkAsProcessed()
        {
            _Status = OrderStatus.PROCESS ;
        }
    
        public void MarkAsFalied()
        {
            _Status = OrderStatus.FALIED;    
        }
        //
    }
}