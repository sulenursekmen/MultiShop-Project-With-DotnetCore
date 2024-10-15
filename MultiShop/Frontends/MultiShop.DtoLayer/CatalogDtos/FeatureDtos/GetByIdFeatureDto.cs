using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.FeatureDtos
{
    public class GetByIdFeatureDto
    {
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
