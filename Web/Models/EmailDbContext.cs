namespace TuRM.Portrait.Models
{
    using MySql.Data.Entity;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EmailDbContext : DbContext
    {
        // Der Kontext wurde für die Verwendung einer EmailDbContext-Verbindungszeichenfolge aus der 
        // Konfigurationsdatei ('App.config' oder 'Web.config') der Anwendung konfiguriert. Diese Verbindungszeichenfolge hat standardmäßig die 
        // Datenbank 'TuRM.Portrait.Models.EmailDbContext' auf der LocalDb-Instanz als Ziel. 
        // 
        // Wenn Sie eine andere Datenbank und/oder einen anderen Anbieter als Ziel verwenden möchten, ändern Sie die EmailDbContext-Zeichenfolge 
        // in der Anwendungskonfigurationsdatei.
        public EmailDbContext()
            : base("name=EmailDbContext")
        {

        }

        public EmailDbContext(string connection)
            :base(new MySqlConnection(connection), true)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EmailDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OutBoxMail>()
                .HasMany(e => e.Attachments)
                .WithRequired(e => e.OutBoxMail).HasForeignKey(e=>e.MailId);
        }

        // Fügen Sie ein 'DbSet' für jeden Entitätstyp hinzu, den Sie in das Modell einschließen möchten. Weitere Informationen 
        // zum Konfigurieren und Verwenden eines Code First-Modells finden Sie unter 'http://go.microsoft.com/fwlink/?LinkId=390109'.

        public virtual DbSet<OutBoxMail> OutBox { get; set; }
        public virtual DbSet<OutBoxAttachment> OutBoxAttachments { get; set; }
    }

    public class Mail
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public bool IsSent { get; set; }
    }

    public class OutBoxMail : Mail
    {
        public virtual ICollection<OutBoxAttachment> Attachments { get; set; }
    }

    public class Attachment {
        public int Id { get; set; }

        public int MailId { get; set; }

        public byte[] Data { get; set; }

        public string FileName { get; set; }

        public string MediaType { get; set; }
    }

    public class OutBoxAttachment : Attachment
    {
        public virtual OutBoxMail OutBoxMail { get; set; }
    }
}