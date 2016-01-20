namespace LetPaintPictures.Models
{
    public partial class ApplicationDbContext
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
