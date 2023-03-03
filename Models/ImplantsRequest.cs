using System.ComponentModel.DataAnnotations;

namespace DesignImplants.Models
{
    public class ImplantsRequest
    {
        public Usage[] Usage { get; set; }
    }

    public class Usage
    {
        [Required]
        public string FeatureName { get; set; }

        [Required]
        public int QuantityUsed { get; set; }
    }
}
