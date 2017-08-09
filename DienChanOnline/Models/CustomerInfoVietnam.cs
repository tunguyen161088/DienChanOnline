using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace DienChanOnline.Models
{
    [TableName("DienChanOnline..CustomerInfo")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class CustomerInfoVietnam
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin tên.")]
        [DisplayName(@"Tên")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin họ.")]
        [DisplayName(@"Họ")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin điện thoại.")]
        [DisplayName(@"Điện Thoại")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền địa chỉ email.")]
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [DisplayName(@"Ngày Sinh")]
        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin ngày sinh.")]
        public DateTime BirthDay { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin nghề nghiệp.")]
        [DisplayName(@"Nghề Nghiệp")]
        public string Job { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin địa chỉ 1.")]
        [DisplayName(@"Địa Chỉ 1")]
        public string Address1 { get; set; }

        [DisplayName(@"Địa Chỉ 2")]
        public string Address2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin thành phố.")]
        [DisplayName(@"Thành Phố")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin quận hoặc bang.")]
        [DisplayName(@"Quận/Bang")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin mã bưu chính.")]
        [DisplayName(@"Mã Bưu Chính")]
        public string Zip { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin quốc gia.")]
        [DisplayName(@"Quốc Gia")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Vui lòng điền thông tin nguyện vọng.")]
        [DisplayName(@"Nguyện Vọng")]
        public string Purpose { get; set; }

        public string Title { get; set; }

        public string FormGuidInfo { get; set; }
    }
}