using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RashutSdotHateufa.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation Property (One Department can have Many Employees)
        [JsonIgnore] // 🔹 Prevent circular reference issues
        public ICollection<Employee>? Employees { get; set; }
    }
}
