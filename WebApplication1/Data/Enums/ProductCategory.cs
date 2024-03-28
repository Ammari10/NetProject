using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EStore.Data.Enums
{
    
    public enum ProductCategory
    {
        GPU,
        CPU,
        Memory,
        [Display(Name = "Hard Drive")]
        HardDrive,
        
        [Display(Name = "Video Wall")]
        VideoWall,
        
        [Display(Name = "Encoders & Decoders")]
        EncodersAndDecoders,



    }
}
