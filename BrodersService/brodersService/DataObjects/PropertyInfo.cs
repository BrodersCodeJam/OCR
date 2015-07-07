using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brodersService.DataObjects
{
    public class PropertyInfo : EntityData
    {
      
        public decimal Amount { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Url { get; set; }
        public System.Data.Entity.Spatial.DbGeography GpsCoords { get; set; }
    }
}
