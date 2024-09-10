namespace BaiTap06.Models
{
    public class TheLoaiViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
            public int Id { get; set; }
            public string Name { get; set; }
         
    }
}