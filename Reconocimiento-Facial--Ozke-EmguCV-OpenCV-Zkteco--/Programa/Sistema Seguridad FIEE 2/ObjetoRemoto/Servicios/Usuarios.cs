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
using System.Data.Linq.Mapping;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System;

namespace ObjetoRemoto
{
    [Serializable]
    [Table(Name = "Usuarios")]
    public class Usuarios
    {
        [Column]
        public int Id;
        [Column(IsPrimaryKey = true)]
        public int Cedula;
        [Column]
        public string Alias;
        [Column]
        public string Nombre;
        [Column]
        public string Apellido;
        [Column]
        public string Password;
        [Column]
        public string Tipo;
        [Column]
        public string Departamento;
        [Column]
        public string Correo;
        [Column]
        public int Pin;
        [Column]
        public string Huella;
        [Column]
        public Binary Rostro;
        
        public Usuarios(int ini_id, int ini_cedula, string ini_alias, string ini_nombre, string ini_apellido, string ini_password, string ini_tipo, string ini_departamento, string ini_correo, int ini_pin, string ini_huella, Binary ini_rostro)
        {
            Id = ini_id;
            Cedula = ini_cedula;
            Alias = ini_alias;
            Nombre = ini_nombre;
            Apellido = ini_apellido;
            Password = ini_password;
            Tipo = ini_tipo;
            Departamento = ini_departamento;
            Correo = ini_correo;
            Pin = ini_pin;
            Huella = ini_huella;
            Rostro = ini_rostro;
        }

        public Usuarios(int ini_cedula, string ini_nombre, string ini_apellido, string ini_tipo, string ini_departamento)
        {
            Cedula = ini_cedula;
            Nombre = ini_nombre;
            Apellido = ini_apellido;
            Tipo = ini_tipo;
            Departamento = ini_departamento;
        }

        public Usuarios(string ini_nombre, string ini_apellido, string ini_huella)
        {
            Nombre = ini_nombre;
            Apellido = ini_apellido;
            Huella = ini_huella;
        }

        public Usuarios(int ini_id, string ini_alias, string ini_password)
        {
            Id = ini_id;
            Alias = ini_alias;
            Password = ini_password;
        }

        public Usuarios(string ini_nombre, string ini_apellido)
        {
            Nombre = ini_nombre;
            Apellido = ini_apellido;
        }

        public Usuarios(string ini_correo)
        {
            Correo = ini_correo;
        }

        public override string ToString()
        {
            return Id + Cedula + Alias + Nombre + Apellido + Password + Tipo + Departamento + Correo + Pin + Huella + Rostro;
        }

        public Usuarios(int ini_cedula)
        {
            Cedula = ini_cedula;
        }

        public Usuarios()
        {
        }
    }
}