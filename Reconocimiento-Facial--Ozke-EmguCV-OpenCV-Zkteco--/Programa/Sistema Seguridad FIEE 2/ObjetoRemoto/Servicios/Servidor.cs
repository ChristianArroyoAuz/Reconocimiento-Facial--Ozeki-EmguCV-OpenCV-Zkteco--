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
using System.Linq;
using System.Text;
using System;

namespace ObjetoRemoto
{
    public class Servidor
    {
        private static System.Threading.AutoResetEvent eventoTerminacion = new System.Threading.AutoResetEvent(false);

        public static void Main()
        {
            try
            {
                ServiceHost anfitrion = new ServiceHost(typeof(ObjetoRemoto));
                anfitrion.AddServiceEndpoint(typeof(IObjetoRemoto), new NetTcpBinding(), "net.tcp://localhost:8080");
                anfitrion.Open();
                eventoTerminacion.WaitOne();
                Console.WriteLine();
                anfitrion.Close();
                Console.WriteLine();
            }
            catch
            {
                //NADA
            }
        }

        public static void StopServer()
        {
            eventoTerminacion.Set();
        }
    }
}