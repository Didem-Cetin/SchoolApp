using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsApp.Models
{
    public class SelectItem
    {
        public static implicit operator SelectList(SelectItem v)
        {
            throw new NotImplementedException();
        }
    }
    public class response<T>
    {
        public bool error { get; set; }
        public T Data { get; set; }
        public List<KeyValuePair<string, string>> errorMessage { get; set; }
    }
}