using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TuRM.Portrait.Models;

namespace sendMail
{
    class Program
    {
        private static bool toCancel, verbose;
        static void Main(string[] args)
        {
            verbose = args.Where(s => string.Compare(s, "-verbose", true) == 0).Count() > 0;
            Console.CancelKeyPress += Console_CancelKeyPress;

            while (!toCancel)
            {
                Task task = new Task(CheckMails);
                task.Start();
                task.Wait();

                Thread.Sleep(60000);
            }
        }

        private static async void CheckMails()
        {
            using (EmailDbContext db = new EmailDbContext("server=localhost;UserId=root;password=Krim2Go!;database=Email;logging=true;port=3306;"))
            {
                IEnumerable<OutBoxMail> mails = new List<OutBoxMail>(db.OutBox.Where(w => !w.IsSent));

                if (verbose)
                {
                    if (mails.Count() == 0)
                    {
                        Console.WriteLine(DateTime.Now.ToShortTimeString() + $":\tInfo   \tNo new mails to send");
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToShortTimeString() + $":\tInfo   \t{mails.Count()} new mails loaded. Begin sending...");
                    }
                }
                foreach (var mail in mails)
                {
                    try
                    {
                        await db.Entry(mail).Collection(c => c.Attachments).LoadAsync();
                        await sendNotificationEmail(mail);

                        Console.WriteLine(DateTime.Now.ToShortTimeString() + $":\tSuccess\tMail {mail.Id} sent with {mail.Attachments.Count} attachments");

                        mail.IsSent = true;

                        db.Entry(mail).State = System.Data.Entity.EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(DateTime.Now.ToShortTimeString() + ":\tError  \t" + ex.Message);
                    }
                }
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            toCancel = e.Cancel;
        }

        private static async Task sendNotificationEmail(OutBoxMail mail)//string firstName, string secondName
        {
            Object token = new object();
            using (SmtpClient client = new SmtpClient("smtp.strato.de", 587))
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("webmaster@tm-portraits.de");
                message.To.Add("kontakt@tm-portraits.de");
                message.Subject = "Neue Bestellung eingetroffen";
                message.Body = mail.Body;
                message.IsBodyHtml = true;

                foreach (var item in mail.Attachments)
                {
                    message.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(item.Data), $"{item.FileName}", $"{item.MediaType}"));
                }

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("webmaster@tm-portraits.de", "architekTur25");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;

                await client.SendMailAsync(message);
            }
        }
    }

}
