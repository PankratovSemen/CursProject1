using System;

namespace CursProjects_GIt.Model.DataBase
{
    public class Share
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShareHolder { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
