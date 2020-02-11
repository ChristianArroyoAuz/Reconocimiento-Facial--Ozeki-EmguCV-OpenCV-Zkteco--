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
using System.Drawing.Imaging;
using System.Globalization;
using System.Drawing;
using Ozeki.Camera;
using Ozeki.Media;
using System.Linq;
using System.Text;
using System;

namespace Cliente
{
    class Eventos_Camara
    {
        public DrawingImageProvider EventoProveedorImagen = new DrawingImageProvider();
        public event EventHandler<CameraStateEventArgs> EventoCambioEstadoCamara;
        public event EventHandler<CameraErrorEventArgs> EventoErrorEnCamara;
        public ImageManipulation EventoColor = new ImageManipulation();
        public SnapshotHandler EventoSnapshot = new SnapshotHandler();
        public MediaConnector EventoConectar = new MediaConnector();
        public MPEG4Recorder EventoGravadoraVideo;
        public OzSaturationCorrection saturacion;
        public OzContrastCorrection contraste;
        public OzBrightnessCorrection brillo;
        public Zoom EventoZoom = new Zoom();
        public OzekiCamera EventoCamara;
        public string rutaGuardarImagen;
        public OzGammaCorrection gamma;
        public string rutaGuardarVideo;
        public string salaActual;

        public void ManipulacionColor(int valor_s, int valor_c, int valor_g, int valor_b)
        {
            EventoConectar.Disconnect(EventoZoom, EventoProveedorImagen);
            EventoConectar.Connect(EventoColor, EventoProveedorImagen);
            saturacion = new OzSaturationCorrection(valor_s);
            contraste = new OzContrastCorrection(valor_c);
            brillo = new OzBrightnessCorrection(valor_b);
            gamma = new OzGammaCorrection(valor_g);
            EventoColor.Clear();
            EventoColor.Add(saturacion);
            EventoColor.Add(contraste);
            EventoColor.Add(gamma);
            EventoColor.Add(brillo);
        }

        public void Camara_Error_Detectado(object sender, CameraErrorEventArgs e)
        {
            var error = EventoErrorEnCamara;
            error(this, e);
        }

        public void Camara_Cambia_Estado(object sender, CameraStateEventArgs e)
        {
            var estado = EventoCambioEstadoCamara;
            estado(this, e);
        }

        public void GrabadoraDeVideo(object sender, VoIPEventArgs<bool> e)
        {
            var grabadora = sender as MPEG4Recorder;
            EventoConectar.Disconnect(EventoCamara.AudioChannel, grabadora.AudioRecorder);
            EventoConectar.Disconnect(EventoCamara.VideoChannel, grabadora.VideoRecorder);
            grabadora.Dispose();
            Eventos.Escribir("El Video de la " + salaActual + " ha sido grabado.");
        }

        public void IniciarCapturaVideo(string directorio, string sala)
        {
            var fecha = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            rutaGuardarVideo = directorio + "\\" + fecha + ".mp4";
            salaActual = sala;
            EventoGravadoraVideo = new MPEG4Recorder(rutaGuardarVideo);
            EventoGravadoraVideo.MultiplexFinished += GrabadoraDeVideo;
            EventoConectar.Connect(EventoCamara.AudioChannel, EventoGravadoraVideo.AudioRecorder);
            EventoConectar.Connect(EventoCamara.VideoChannel, EventoGravadoraVideo.VideoRecorder);
            Eventos.Escribir("El Video de la " + sala + " ha empezado a grabarse.");
            Eventos.Escribir("El Video de la " + sala + " se grabara en la ruta: " + rutaGuardarVideo);
        }

        public void TomarSnapShot(string directorio, string sala)
        {
            var date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            var snapShotImage = (Image)EventoSnapshot.TakeSnapshot().ToImage();
            rutaGuardarImagen = directorio + "\\" + date + ".jpg";
            snapShotImage.Save(rutaGuardarImagen, ImageFormat.Jpeg);
            Eventos.Escribir("La imagen de la " + sala + " ha sido guardada en la ruta: " + rutaGuardarImagen);
        }

        public void ConexionCamara(string camaraUrl)
        {
            EventoCamara = new OzekiCamera(camaraUrl);
            EventoConectar.Connect(EventoCamara.VideoChannel, EventoSnapshot);
            EventoConectar.Connect(EventoCamara.VideoChannel, EventoColor);
            EventoConectar.Connect(EventoCamara.VideoChannel, EventoZoom);
            EventoCamara.CameraErrorOccurred += Camara_Error_Detectado;
            EventoConectar.Connect(EventoZoom, EventoProveedorImagen);
            EventoCamara.CameraStateChanged += Camara_Cambia_Estado;
            EventoCamara.Start();
            EventoColor.Start();
            EventoZoom.Start();
        }

        public void DetenerCapturaVideo(string sala)
        {
            if (EventoCamara == null || EventoGravadoraVideo == null)
            {
                return;
            }
            else
            {

                EventoGravadoraVideo.Multiplex();
                EventoConectar.Disconnect(EventoCamara.AudioChannel, EventoGravadoraVideo.AudioRecorder);
                EventoConectar.Disconnect(EventoCamara.VideoChannel, EventoGravadoraVideo.VideoRecorder);
                Eventos.Escribir("El Video de la " + sala + " ha sido detenido.");
            }
        }

        public void Zoom(string zoom, string sala)
        {
            EventoConectar.Disconnect(EventoColor, EventoProveedorImagen);
            EventoConectar.Connect(EventoZoom, EventoProveedorImagen);
            if (zoom == "Aumentar")
            {
                EventoZoom.In();
                Eventos.Escribir("El zoom de la camara de la " + sala + " ha sido aumentado a : " + EventoZoom.Factor.ToString(CultureInfo.InvariantCulture));
            }
            if(zoom == "Disminuir")
            {
                EventoZoom.Out();
                Eventos.Escribir("El zoom de la camara de la " + sala + " ha sido disminuido a :"  + EventoZoom.Factor.ToString(CultureInfo.InvariantCulture));
            }
            if (zoom == "Default")
            {
                EventoZoom.Default();
                Eventos.Escribir("El zoom de la camara de la " + sala + " ha retornado a :" + EventoZoom.Factor.ToString(CultureInfo.InvariantCulture));
            }
        }

        public string InformacionDispositivo()
        {
            var datosDispositivo = new StringBuilder();
            datosDispositivo.AppendLine(@"Versión Del Hardware: " + EventoCamara.CameraInfo.DeviceInfo.HardwareId + "\n");
            datosDispositivo.AppendLine(@"Número De Serie: " + EventoCamara.CameraInfo.DeviceInfo.SerialNumber + "\n");
            datosDispositivo.AppendLine(@"Fabricante: " + EventoCamara.CameraInfo.DeviceInfo.Manufacturer + "\n");
            datosDispositivo.AppendLine(@"Firmware: " + EventoCamara.CameraInfo.DeviceInfo.Firmware + "\n");
            datosDispositivo.AppendLine(@"Modelo: " + EventoCamara.CameraInfo.DeviceInfo.Model + "\n");
            return datosDispositivo.ToString();
        }

        public string InformacionVideo()
        {
            var datosVideo = new StringBuilder();
            datosVideo.AppendLine(" - Codificación De Video: \n");
            datosVideo.AppendLine("\t Codificación: " + EventoCamara.CurrentStream.VideoEncoding.Encoding + "\n");
            datosVideo.AppendLine("\t Resolución: " + EventoCamara.CurrentStream.VideoEncoding.Resolution + "\n");
            datosVideo.AppendLine("\t Framerate: " + EventoCamara.CurrentStream.VideoEncoding.FrameRate + "\n");
            datosVideo.AppendLine("\t Bitrate: " + EventoCamara.CurrentStream.VideoEncoding.BitRate + "\n");
            datosVideo.AppendLine("\t Calidad: " + EventoCamara.CurrentStream.VideoEncoding.Quality + "\n");
            datosVideo.AppendLine(" - Fuente De Video: \n");
            datosVideo.AppendLine("\t Limites: " + EventoCamara.CurrentStream.VideoSource.Bounds + "\n");
            return datosVideo.ToString();
        }

        public string InformacionAudio()
        {
            if (EventoCamara.CurrentStream.AudioEncoding == null)
            {
                return "No se pudo obtener información del Dispositivo.";
            }
            else
            {
                var datosAudio = new StringBuilder();
                datosAudio.AppendLine(" - Codificación De Audio: \n");
                datosAudio.AppendLine("\t Codificación: " + EventoCamara.CurrentStream.AudioEncoding.Encoding + "\n");
                datosAudio.AppendLine(" - Fuente De Audio: \n");
                datosAudio.AppendLine("\t Canales: " + EventoCamara.CurrentStream.AudioSource.Channels + "\n");
                return datosAudio.ToString();
            }
        }

        public void Desconectar()
        {
            EventoConectar.Disconnect(EventoCamara.VideoChannel, EventoProveedorImagen);
            EventoConectar.Disconnect(EventoCamara.VideoChannel, EventoSnapshot);
            EventoCamara.Disconnect();
            EventoCamara.CameraErrorOccurred -= Camara_Error_Detectado;
            EventoCamara.CameraStateChanged -= Camara_Cambia_Estado;
            EventoCamara = null;
        }

        public void Detener()
        {
            if (EventoCamara != null)
            {
                EventoProveedorImagen.Dispose();
                EventoConectar.Dispose();
                EventoSnapshot.Dispose();
                DetenerCapturaVideo("Se Detuvo los Videos de las Salas 1 y 2.");
                Desconectar();
            }
        }
    }
}