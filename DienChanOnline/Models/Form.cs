using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace DienChanOnline.Models
{
    [TableName("DienChanOnline..FormType")]
    public class Form
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng điền tên form.")]
        [DisplayName("Tên Form")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng điền thông tin tiêu đề tiếng Pháp.")]
        [DisplayName("Tiêu Đề Tiếng Pháp")]
        public string TitleFr { get; set; }

        [DisplayName("Tiêu Đề Tiếng Việt")]
        public string TitleVn { get; set; }

        [DisplayName("Tiêu Đề Tiếng Anh")]
        public string Title { get; set; }
    }
}
