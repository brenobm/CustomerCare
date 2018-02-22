using System.Collections.Generic;

namespace CustomerCare.Models.ClientsDomain
{
    public class ClientArea
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
        public string Chart { get; set; }
        public string Indicators { get; set; }
        public bool CRCMonitoring { get; set; }
    }
}