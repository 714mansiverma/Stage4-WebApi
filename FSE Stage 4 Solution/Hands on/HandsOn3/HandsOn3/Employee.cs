using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HandsOn3
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; }
        public List<Skill> Skills { get; set; }
        public string DOB { get; set; }
    }
}
