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


using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System;

namespace ObjetoRemoto
{
    [ServiceContract]
    public interface IObjetoRemoto
    {
        [OperationContract]
        List<Usuarios> ObtenerAdministradores(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> ConsultaDatosUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> ConsultaPinUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> ModificarUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> MostrarUsuarios(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> CompararUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> EliminarUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> CompararCedula(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> CompararCorreo(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> AgregarUsuario(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> ObtenerHuellas(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Usuarios> CompararPin(List<Usuarios> lista_usuario);
        [OperationContract]
        List<Logs> MostrarEventos(List<Logs> lista_eventos);
        [OperationContract]
        List<Logs> AgregarEvento(List<Logs> lista_eventos);
        [OperationContract]
        int ObtenerID_Usuario(int id);
        [OperationContract]
        int ObtenerID_Eventos(int id);
    }
}