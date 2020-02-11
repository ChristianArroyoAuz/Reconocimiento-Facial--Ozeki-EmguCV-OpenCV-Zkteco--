/*************************************************************************************************************************
**                                                                                                                      **
**                                         ESCUELA POLITÉCNICA NACIONAL                                                 **
**                                                                                                                      **
**                                  FACULTAD DE INGENIERÍA ÉLECTRICA Y ELECTRÓNICA                                      **
**                                                                                                                      **
**        DESARROLLO DE UN SISTEMA PROTOTIPO DE ACCESO A LOS LABORATORIOS DE REDES DE LA FACULTAD DE INGENIERÍA         **
**        ELÉCTRICA Y ELECTRÓNICA(FIEE) DE LA ESCUELA POLITÉCNICA NACIONAL(EPN) BASADO EN RECONOCIMIENTO FACIAL         **
**                                                                                                                      **
**     TRABAJO DE TITULACIÓN PREVIO A LA OBTENCIÓN DEL TÍTULO DE INGENIERO EN “ELECTRÓNICA Y REDES DE INFORMACIÓN”      **
**                                                                                                                      **
**                                         ARROYO AUZ CHRISTIAN XAVIER                                                  **
**                                         christian.arroyo@epn.edu.ec                                                  **
**                                                                                                                      **
**                              DIRECTOR:  MSC.CALDERÓN HINOJOSA XAVIER ALEXANDER                                       **
**                                         xavier.calderon@epn.edu.ec                                                   **
**                                                                                                                      **
**                                              Quito, mayo 2019                                                        **
**                                                                                                                      **
*************************************************************************************************************************/


using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using ObjetoRemoto;
using System.Linq;
using System.Text;
using System;

namespace Cliente
{
    class Eventos
    {
        //Variable creada para llamar a la clase Mensajes e intercambiar información
        public static event EventHandler<Mensajes> Mensaje_Recibido;

        //Variable local para cargar el evento
        private static string evento;
        
        //Metodo para recibir desde la clase principal la información
        public static void Escribir(string mensajeEvento)
        {
            //Se agrega al evento la información de la fecha
            evento = DateTime.Now + " | " + mensajeEvento;
            //Se envia el evento generado al Metodo Mensaje_Evento_Recibido
            Mensaje_Evento_Recibido(evento);
        }

        //Metodo Local para enviar el mensaje a la clase Mensaje
        static void Mensaje_Evento_Recibido(string mensaje_recibido)
        {
            //Variable del metodo donde se anida el mensaje del evento recibido
            var imprimir = Mensaje_Recibido;
            //Se envia a la clase Mensaje el evento generado
            imprimir(null, new Mensajes(mensaje_recibido));
        }
    }
}