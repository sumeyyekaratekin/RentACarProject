using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public string CustomerFullName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }

    }
}
