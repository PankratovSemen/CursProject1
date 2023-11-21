using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursProjects_GIt.Model.DataBase
{
    public class ShareHolders
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public int SumShare { get; set; }
        public int CountShares { get; set; }
    }
}
