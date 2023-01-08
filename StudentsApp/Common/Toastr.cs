namespace StudentsApp.Common
{
    public class Toastr
    {
        public bool ShowToastr { get; set; }
        public string ToastrType { get; set; }
        public string ToastrTitle { get; set; }
        public string ToastrMessage { get; set; }
        public string? ToastrButton { get; set; }
        public ToastrOptions? Options { get; set; }
    }

    public class ToastrOptions
    {
        
        public bool closeButton  { get; set; }
        public bool debug  { get; set; }
        public bool newestOnTop  { get; set; }
        public bool progressBar  { get; set; }
        public string positionClass  { get; set; }
        public bool preventDuplicates  { get; set; }
        public string onclick { get; set; } = null;
        public string showDuration  { get; set; }
        public string hideDuration  { get; set; }
        public int timeOut  { get; set; }
        public int extendedTimeOut  { get; set; }
        public string showEasing  { get; set; }
        public string hideEasing  { get; set; }
        public string showMethod  { get; set; }
        public string hideMethod  { get; set; }
        public bool tapToDismiss { get; set; }

        
    }
    public static class ToastrPosition
    {
        public static readonly string top_right = "toast-top-right";
        public static readonly string bottom_right = "toast-bottom-right";
        public static readonly string bottom_left = "toast-bottom-left";
        public static readonly string top_left = "toast-top-left";
        public static readonly string top_full_width = "toast-top-full-width";
        public static readonly string bottom_full_width = "toast-bottom-full-width";
        public static readonly string top_center = "toast-top-center";
        public static readonly string bottom_center = "toast-bottom-center";
    }
}
