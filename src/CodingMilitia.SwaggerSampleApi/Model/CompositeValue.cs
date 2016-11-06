using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingMilitia.SwaggerSampleApi.Model
{
    public class CompositeValue
    {
        [Required]
        public int Id { get; set; }
        [DefaultValue("DefaultValue")]
        public string Value { get; set; }
    }
}
