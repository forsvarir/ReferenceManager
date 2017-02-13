using ReferenceManager.Helpers;
using System.ComponentModel;

namespace ReferenceManager.DAL
{
    public class Location
    {
        public Location()
        {
        }

        [SuppressDisplay]
        public int LocationId { get; set; }
        [DisplayName("Name")]
        public string QuickName { get; set; }
        public string Room { get; set; }
        public string Shelf { get; set; }
    }
}
