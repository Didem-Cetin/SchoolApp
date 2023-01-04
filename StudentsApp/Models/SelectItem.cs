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
}