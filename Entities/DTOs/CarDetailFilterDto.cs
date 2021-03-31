using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Attributes.FilterAttributes;

namespace Entities.DTOs
{
    public class CarDetailFilterDto : IFilterDto
    {
        [EqualFilter("BrandId")]
        public List<int> BrandId { get; set; }
        [EqualFilter("ColorId")]
        public List<int> ColorId { get; set; }
        [EqualFilter("Id")]
        public List<int> Id { get; set; }
        [EqualFilter("DailyPrice")]
        public List<int> DailyPrice { get; set; }
        public string CarName { get; set; }
        [MinFilter("DailyPrice")]
        public int? MinDailyPrice { get; set; }
        [MaxFilter("DailyPrice")]
        public int? MaxDailyPrice { get; set; }

    }
}