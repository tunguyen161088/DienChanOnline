using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace DienChanOnline.Models
{
    [TableName("DienChanOnline..FormType")]
    public class FormType
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

        [DisplayName("Link")]
        public string Link { get; set; }

        [DisplayName("Danh Sách Khách Hàng")]
        public string CustomersLink { get; set; }

        public string GuidInfo { get; set; }
    }
}
