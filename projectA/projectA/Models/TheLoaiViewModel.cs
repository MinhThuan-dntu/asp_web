using System.ComponentModel.DataAnnotations;

namespace projectA.Models
{
    public class TheLoaiViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để tên Thể Loại trống")]
        [StringLength(maximumLength: 8, ErrorMessage = "Tên {0} bạn nhập vào chỉ được từ {2} đến {1} kí tự cho phép. ", MinimumLength = 6)]
        [Display(Name = "Thể Loại")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng Chọn ngày tháng năm bạn muốn")]
        [Display(Name = "Ngày Tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}