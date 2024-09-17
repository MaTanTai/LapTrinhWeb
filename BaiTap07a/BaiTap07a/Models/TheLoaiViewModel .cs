namespace BaiTap07a.Models
{
    public class TheLoaiViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
