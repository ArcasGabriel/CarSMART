using System.Collections.Generic;
namespace DotNetAngularApp.Controllers.Resources
{
    public class FeatureResource
    {
        public int Id { get; set; } 

        public string Name { get; set; } 

        
        public IList<int> Features { get; set; }

        public FeatureResource()
        { 
            Features = new List<int>();
        }  
    }
}