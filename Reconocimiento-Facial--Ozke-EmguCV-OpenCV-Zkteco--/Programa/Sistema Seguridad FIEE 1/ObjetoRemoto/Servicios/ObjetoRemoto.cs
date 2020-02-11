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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System;

namespace ObjetoRemoto
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ObjetoRemoto : MarshalByRefObject, IObjetoRemoto
    {
        public List<Usuarios> enviarUsuario = new List<Usuarios>();
        public List<Usuarios> usuaurioCRUD = new List<Usuarios>();
        public List<Logs> eventosRegistrados = new List<Logs>();
        public string departamentoUsuario;
        public int identificadorUsuario;
        public MiDB miBase = new MiDB();
        public int identificadorEvento;
        public string apellidoUsuario;
        public string passwordUsuario;
        public string nombreUsuario;
        public string correoUsuario;
        public string huellaUsuario;
        public Binary rostroUsuario;
        public string aliasUsuario;
        public string tipoUsuario;
        public string fechaEvento;
        public int cedulaUsuario;
        public int pinUsuario;
        public string evento;

        public List<Usuarios> ObtenerAdministradores(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Tipo == tipoUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               TiPO = usuarios.Tipo
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.TiPO);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> ConsultaDatosUsuario(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Alias == aliasUsuario && usuarios.Password == passwordUsuario && usuarios.Tipo == "Administrador"
                           orderby usuarios.Id ascending
                           select new
                           {
                               USUARIO = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.USUARIO, item.APELLIDO);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> ConsultaPinUsuario(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Pin == pinUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               USUARIO = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.USUARIO, item.APELLIDO);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> ModificarUsuario(List<Usuarios> lista_usuario)
        {
            miBase.ExecuteCommand("Delete from Usuarios where Id = " + Convert.ToString(identificadorUsuario) + ";");
            miBase.SubmitChanges();
            Usuarios nuevoUsuario = new Usuarios(identificadorUsuario, cedulaUsuario, aliasUsuario, nombreUsuario, apellidoUsuario, passwordUsuario, tipoUsuario, departamentoUsuario, correoUsuario, pinUsuario, huellaUsuario, rostroUsuario);
            miBase.Usuarios.InsertOnSubmit(nuevoUsuario);
            miBase.SubmitChanges();
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Id == identificadorUsuario
                           select new
                           {
                               ID = usuarios.Id,
                               CEDULA = usuarios.Cedula,
                               ALIAS = usuarios.Alias,
                               NOMBRE = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido,
                               PASSWORD = usuarios.Password,
                               TIPO = usuarios.Tipo,
                               DEPARTAMENTO = usuarios.Departamento,
                               CORREO = usuarios.Correo,
                               PIN = usuarios.Pin,
                               HUELLA = usuarios.Huella,
                               ROSTRO = usuarios.Rostro
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.ID, item.CEDULA, item.ALIAS, item.NOMBRE, item.APELLIDO, item.PASSWORD, item.TIPO, item.DEPARTAMENTO, item.CORREO, item.PIN, item.HUELLA, item.ROSTRO);
                lista_usuario.Add(cargar);
                usuaurioCRUD = lista_usuario;
            }
            miBase.Refresh(RefreshMode.KeepChanges, nuevoUsuario);
            return usuaurioCRUD;
        }

        public List<Usuarios> MostrarUsuarios(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Id >= 0
                           orderby usuarios.Id ascending
                           select new
                           {
                               ID = usuarios.Id,
                               CEDULA = usuarios.Cedula,
                               ALIAS = usuarios.Alias,
                               NOMBRE = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido,
                               PASSWORD = usuarios.Password,
                               TIPO = usuarios.Tipo,
                               DEPARTAMENTO = usuarios.Departamento,
                               CORREO = usuarios.Correo,
                               PIN = usuarios.Pin,
                               HUELLA = usuarios.Huella,
                               ROSTRO = usuarios.Rostro
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.ID, item.CEDULA, item.ALIAS, item.NOMBRE, item.APELLIDO, item.PASSWORD, item.TIPO, item.DEPARTAMENTO, item.CORREO, item.PIN, item.HUELLA, item.ROSTRO);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> CompararUsuario(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Alias == aliasUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               ID = usuarios.Id,
                               ALIAS = usuarios.Alias,
                               PASSWORD = usuarios.Password
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.ID, item.ALIAS, item.PASSWORD);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> EliminarUsuario(List<Usuarios> lista_usuario)
        {
            miBase.ExecuteCommand("Delete from Usuarios where Id = " + Convert.ToString(identificadorUsuario) + ";");
            miBase.SubmitChanges();
            MostrarUsuarios(lista_usuario);
            return usuaurioCRUD;
        }

        public List<Usuarios> AgregarUsuario(List<Usuarios> lista_usuario)
        {
            Usuarios nuevoUsuario = new Usuarios(identificadorUsuario, cedulaUsuario, aliasUsuario, nombreUsuario, apellidoUsuario, passwordUsuario, tipoUsuario, departamentoUsuario, correoUsuario, pinUsuario, huellaUsuario, rostroUsuario);
            miBase.Usuarios.InsertOnSubmit(nuevoUsuario);
            miBase.SubmitChanges();
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Id == identificadorUsuario
                           select new
                           {
                               ID = usuarios.Id,
                               CEDULA = usuarios.Cedula,
                               ALIAS = usuarios.Alias,
                               NOMBRE = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido,
                               PASSWORD = usuarios.Password,
                               TIPO = usuarios.Tipo,
                               DEPARTAMENTO = usuarios.Departamento,
                               CORREO = usuarios.Correo,
                               PIN = usuarios.Pin,
                               HUELLA = usuarios.Huella,
                               ROSTRO = usuarios.Rostro
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.ID, item.CEDULA, item.ALIAS, item.NOMBRE, item.APELLIDO, item.PASSWORD, item.TIPO, item.DEPARTAMENTO, item.CORREO, item.PIN, item.HUELLA, item.ROSTRO);
                lista_usuario.Add(cargar);
                usuaurioCRUD = lista_usuario;
            }
            return usuaurioCRUD;
        }

        public List<Usuarios> CompararCedula(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Cedula == cedulaUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               CEDULA = usuarios.Cedula
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.CEDULA);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> CompararCorreo(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Correo == correoUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               CORREO = usuarios.Correo
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.CORREO);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> ObtenerHuellas(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Id >= 0
                           orderby usuarios.Id ascending
                           select new
                           {
                               NOMBRE = usuarios.Nombre,
                               APELLIDO = usuarios.Apellido,
                               HUELLA = usuarios.Huella
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.NOMBRE, item.APELLIDO, item.HUELLA);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Usuarios> CompararPin(List<Usuarios> lista_usuario)
        {
            var consulta = from usuarios in miBase.Usuarios
                           where usuarios.Pin == pinUsuario
                           orderby usuarios.Id ascending
                           select new
                           {
                               PIN = usuarios.Pin
                           };
            foreach (var item in consulta)
            {
                Usuarios cargar = new Usuarios(item.PIN);
                lista_usuario.Add(cargar);
                enviarUsuario = lista_usuario;
            }
            return enviarUsuario;
        }

        public List<Logs> MostrarEventos(List<Logs> lista_eventos)
        {
            var consulta = from logs in miBase.Logs
                           where logs.Id_Log >= 0
                           orderby logs.Id_Log ascending
                           select new
                           {
                               ID_LOG = logs.Id_Log,
                               FECHA = logs.Fecha,
                               EVENTO = logs.Evento
                           };
            foreach (var item in consulta)
            {
                Logs cargar = new Logs(item.ID_LOG, item.FECHA, item.EVENTO);
                lista_eventos.Add(cargar);
                eventosRegistrados = lista_eventos;
            }
            return eventosRegistrados;
        }

        public List<Logs> AgregarEvento(List<Logs> lista_eventos)
        {
            Logs nuevoEvento = new Logs(identificadorEvento, fechaEvento, evento);
            miBase.Logs.InsertOnSubmit(nuevoEvento);
            miBase.SubmitChanges();
            return eventosRegistrados;
        }

        public int ObtenerID_Usuario(int id)
        {
            var consulta = (from usuarios in miBase.Usuarios
                            where usuarios.Id > id
                            orderby usuarios.Id descending
                            select usuarios.Id).Take(1);
            foreach (var identificador in consulta)
            {
                id = identificador;
                identificadorUsuario = id;
            }
            return (identificadorUsuario + 1);
        }

        public int ObtenerID_Eventos(int id)
        {
            var consulta = (from logs in miBase.Logs
                            where logs.Id_Log > id
                            orderby logs.Id_Log descending
                            select logs.Id_Log).Take(1);
            foreach (var identificador in consulta)
            {
                id = identificador;
                identificadorEvento = id;
            }
            return (identificadorEvento + 1);
        }
    }
}