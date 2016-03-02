using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace TuRM.Portrait.ViewModels.Request
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string InlineImageContent
        {
            get
            {
                string result = null;

                if (Data != null)
                {
                    WebImage image = Data.Resize(100, 100).Crop(1, 1);

                    result = $"data:image/{image.ImageFormat};base64,{Convert.ToBase64String(image.GetBytes())}";
                }

                return result;
            }
        }

        public WebImage Data { get; set; }
    }
}