using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DemoAPI.Models
{
    public class Position
    {
        public Guid PositionId { get; set; }

        public String PositionCode { get; set; }

        public String PositionName { get; set; }

        public DateTime CreatedDate { get; set; }

        public String CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public String ModifiedBy { get; set; }

    }
}
