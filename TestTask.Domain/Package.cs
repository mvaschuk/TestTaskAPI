using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageIdentifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public Recipient Recipient { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
