using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using AppClinicaDental.Models;
namespace AppClinicaDental.Data
{
    public class Email
    {
        public void enviar( Cita cita)
        {
            try
            {
                //Se crea una instancia del objeto email
                MailMessage email = new MailMessage();

                //agregar destinatarios
                //email del administardor para que reciba una copia 
                email.To.Add(new MailAddress("clinicadentaldrsalas@gmail.com"));

                //Se agrega el email del usuario guardado 
                email.To.Add(new MailAddress(cita.Email));

                //se agrega el emisor 
                email.From = new MailAddress("clinicadentaldrsalas@gmail.com");

                //asunto del email
                email.Subject = "Datos de registro en plataforma web Clinica Dental dr.Salas";

                //se construye la vista html del body del email
                string html = "Bienvenidos a Clinica dental dr.salas gracias por elegir nuestros servicios!";
                html += "<br> A continuacion detallamos los datos registrados en nuestra plataforma web";
                html += "<br><b>Nuestros paquetes son:";
                html += "<br><b>1# Calza";
                html += "<br><b>2# Extracion";
                html += "<br><b>3# Ortodoncia";
                html += "<br><b>4# Limpieza";
                html += "<br><b>5# Blanquiamiento";
                html += "<br><b>Paquete seleccionado#:<b>" + cita.Procedimiento;
                html += "<br><b>Nombre:<b>" + cita.Nombre;
                html += "<br><b>Cedula:<b>" + cita.Cedula;
                html += "<br><b>Email:<b>" + cita.Email;
                html += "<br><b>Precio a pagar en total ₡:<b>" + cita.MontoTotal;
                html += "<br><b>Precio a pagar con IVA ₡:<b>" + cita.MontoIva;
                html += "<br><b>Precio a pagar por adelantado ₡:<b>" + cita.MontoPorAdelantado;
                html += "<br><b>No responda este correo porque fue generado de forma automatica";
                html += "por la plataforma Clinica Dental Dr.Salas </b>";

                //se indica en contenido es html
                email.IsBodyHtml = true;

                //se indica la prioridad del email
                email.Priority = MailPriority.Normal;

                ////Aqui se crea el adjunto de la fotografia utilizada como firma
                //Attachment attachment = new Attachment(urlFirma);

                ////Se crea la etiqueta img para agregar la imagen como firma al body del email
                //html += "<br><br><img src:'cid:imagen' />";

                //se crea la instancia para la vista html del body del email 
                AlternateView view = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                //Se crea la instancia del object inscrustado como imjagen de archivo adjunto 
                //LinkedResource img = new LinkedResource(urlFirma, MediaTypeNames.Image.Jpeg);

                //Se indica el id para la imagen 
                //img.ContentId = "imagen";

                ////se adjunta la imagen
                //view.LinkedResources.Add(img);

                //se agrega la vista al email
                email.AlternateViews.Add(view);

                //Se instancia a un object smtpClient
                SmtpClient smtp = new SmtpClient();

                //Se indica el servidor de correo a implementar
                smtp.Host = "smtp.gmail.com";

                // el puerto de comunicacion 
                smtp.Port = 587;

                //Se indica si utiliza seguridad ssl
                smtp.EnableSsl = true;

                //Se indica si tenemos credenciales por default 
                //en esete caso no
                smtp.UseDefaultCredentials = false;

                //aqui indicamos las credenciales del buzon de correo
                smtp.Credentials = new NetworkCredential("proyecto.ucrnba@gmail.com", "ApiUcr2021");
                //smtp.Credentials = new NetworkCredential("clinicadentaldrsalas@gmail.com", "Pacifico2020$");
                // se envia el email
                smtp.Send(email);

                //Se liberan los recursos
                email.Dispose();
                smtp.Dispose();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

