using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Obituaries
    {
        public int ObituaryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfDeath { get; set; }
        public string ProfilePhoto { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int StateID { get; set; }
        public string State { get; set; }
        public int DistrictID { get; set; }
        public string District { get; set; }
        public int CityID { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public string LoginID { get; set; }  
        public string result { get; set; }
        public string Age { get; set; }
        public string Album { get; set; }
        public string Created { get; set; }
        public List<AlbumImage> AlbumImage { get; set; }
    }
    public class AlbumImage
    {
        public string album { get; set; }
    }
    
}
