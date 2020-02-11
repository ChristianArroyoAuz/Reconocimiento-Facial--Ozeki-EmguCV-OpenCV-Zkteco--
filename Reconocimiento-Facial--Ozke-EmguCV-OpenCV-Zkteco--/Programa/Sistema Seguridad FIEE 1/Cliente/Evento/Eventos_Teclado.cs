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


using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using System;

namespace Cliente
{
    public class Eventos_Teclado
    {
        [DllImport("User32.dll")]
        extern static bool RegisterRawInputDevices(DISPOSITIVOENTRADA[] dispositivoDeEntrada, uint numeroDeDispositivo, uint tamano);
        [DllImport("User32.dll")]
        extern static uint GetRawInputDeviceList(IntPtr listaDispositivosEntrada, ref uint numeroDeDispositivo, uint tamano);
        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr entrada, uint comando, IntPtr dato, ref uint tamano, uint encabezado);
        [DllImport("User32.dll")]
        extern static uint GetRawInputDeviceInfo(IntPtr dispositivo, uint comando, IntPtr dato, ref uint tamano);

        public delegate void ControladorEventosTeclado(object sender, ControlEventosTeclas e);
        public InformacionDispositivo informacionEnviar = new InformacionDispositivo();
        public LISTADISPOSITIVOSENTRADA identificador = new LISTADISPOSITIVOSENTRADA();
        public DISPOSITIVOENTRADA[] identificadorProceso = new DISPOSITIVOENTRADA[1];
        public int tamanoLista = Marshal.SizeOf(typeof(LISTADISPOSITIVOSENTRADA));
        public InformacionDispositivo informacion = new InformacionDispositivo();
        public event ControladorEventosTeclado TeclaPresionada;
        public Hashtable listaDispositivos = new Hashtable();
        public IntPtr dispositivosEntrada = new IntPtr();
        public const int nombreDispositivo = 0x20000007;
        public const int entradas = 0x10000003;
        public ENTRADA entrada = new ENTRADA();
        public string dispositivoDesconectado;
        public uint contadorDispositivos = 0;
        public IntPtr buffer = new IntPtr();
        public IntPtr datos = new IntPtr();
        public string nombreDelDispositivo;
        public Keys miTecla = new Keys();
        public RegistryKey registroTecla;
        public string dispositivoActual;
        public bool teclado = true;
        public string[] separador;
        public string directorio;
        public string protocolo;
        public string subclase;
        public uint tamano = 0;
        public string clase;

        [StructLayout(LayoutKind.Sequential)]
        public struct LISTADISPOSITIVOSENTRADA
        {
            public IntPtr dispositivo;
            public int tipo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct DISPOSITIVOENTRADA
        {
            public ushort manejoPagina;
            public ushort manejo;
            public int bandera;
            public IntPtr objetivo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct CABECERASENTRADA
        {
            public int tipo;
            public int tamano;
            public IntPtr dispositivo;
            public int parametro;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TECLADOS
        {
            public ushort codigo;
            public ushort bandera;
            public ushort reservado;
            public ushort tecla;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct ENTRADA
        {
            [FieldOffset(0)]
            public CABECERASENTRADA encabezado;
            [FieldOffset(16)]
            public TECLADOS teclado;
        }

        public string LeerRegistro(string cadenaRegistro, ref bool teclado)
        {
            cadenaRegistro = cadenaRegistro.Substring(4);
            separador = cadenaRegistro.Split('#');
            clase = separador[0];
            subclase = separador[1];
            protocolo = separador[2];
            registroTecla = Registry.LocalMachine;
            directorio = string.Format(@"System\CurrentControlSet\Enum\{0}\{1}\{2}", clase, subclase, protocolo);
            registroTecla = registroTecla.OpenSubKey(directorio, false);
            dispositivoActual = (string)registroTecla.GetValue("DeviceDesc");
            teclado = true;
            return dispositivoActual;
        }

        public void ProcesarMensajes(Message mensaje)
        {
            try
            {
                GetRawInputData(mensaje.LParam, entradas, IntPtr.Zero, ref tamano, (uint)Marshal.SizeOf(typeof(CABECERASENTRADA)));
                buffer = Marshal.AllocHGlobal((int)tamano);
                if (buffer != IntPtr.Zero && GetRawInputData(mensaje.LParam, entradas, buffer, ref tamano, (uint)Marshal.SizeOf(typeof(CABECERASENTRADA))) == tamano)
                {
                    entrada = (ENTRADA)Marshal.PtrToStructure(buffer, typeof(ENTRADA));
                    informacionEnviar = (InformacionDispositivo)listaDispositivos[entrada.encabezado.dispositivo];
                    miTecla = (Keys)Enum.Parse(typeof(Keys), Enum.GetName(typeof(Keys), entrada.teclado.tecla));
                    TeclaPresionada(this, new ControlEventosTeclas(informacionEnviar));
                    informacionEnviar.numero = miTecla.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        public Eventos_Teclado(IntPtr identificador)
        {
            identificadorProceso[0].manejoPagina = 0x01;
            identificadorProceso[0].manejo = 0x06;
            identificadorProceso[0].objetivo = identificador;
            if (!RegisterRawInputDevices(identificadorProceso, (uint)identificadorProceso.Length, (uint)Marshal.SizeOf(identificadorProceso[0])))
            {
                throw new ApplicationException("Error al registrar el dispositivo de entrada.");
            }
        }

        public class InformacionDispositivo
        {
            public string descripcionDispositivo;
            public string registroDispositivo;
            public string numero;
        }

        public class ControlEventosTeclas
        {
            public InformacionDispositivo Teclado { get; set; }
            public ControlEventosTeclas(InformacionDispositivo descripcion)
            {
                Teclado = descripcion;
            }
        }

        public int NumeroDispositivos()
        {
            if (GetRawInputDeviceList(IntPtr.Zero, ref contadorDispositivos, (uint)tamanoLista) == 0)
            {
                dispositivosEntrada = Marshal.AllocHGlobal((int)(tamanoLista * contadorDispositivos));
                GetRawInputDeviceList(dispositivosEntrada, ref contadorDispositivos, (uint)tamanoLista);
                for (int i = 0; i < contadorDispositivos; i++)
                {
                    identificador = (LISTADISPOSITIVOSENTRADA)Marshal.PtrToStructure(new IntPtr((dispositivosEntrada.ToInt32() + (tamanoLista * i))), typeof(LISTADISPOSITIVOSENTRADA));
                    GetRawInputDeviceInfo(identificador.dispositivo, Eventos_Teclado.nombreDispositivo, IntPtr.Zero, ref tamano);
                    datos = Marshal.AllocHGlobal((int)tamano);
                    GetRawInputDeviceInfo(identificador.dispositivo, Eventos_Teclado.nombreDispositivo, datos, ref tamano);
                    nombreDelDispositivo = (string)Marshal.PtrToStringAnsi(datos);
                    informacion = new InformacionDispositivo();
                    informacion.registroDispositivo = (string)Marshal.PtrToStringAnsi(datos);
                    dispositivoDesconectado = LeerRegistro(nombreDelDispositivo, ref teclado);
                    informacion.descripcionDispositivo = dispositivoDesconectado;
                    if (!listaDispositivos.Contains(identificador.dispositivo))
                    {
                        listaDispositivos.Add(identificador.dispositivo, informacion);
                    }
                }
                return Convert.ToInt32(contadorDispositivos);
            }
            else
            {
                throw new ApplicationException("Se produjo un error al recuperar la lista de dispositivos.");
            }
        }

        internal Eventos Eventos
        {
            get => default(Eventos);
            set
            {
            }
        }
    }
}