using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class Son : Heir
    {
        public int count {  get; set; }
        public Son(string Name , int count) 
        {
            this.Name = Name;
            Relationship = "ابن";
            this.count = count;
        }
        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            return 0;// الابن ليس له نسبة ثابتة يأخذ بالتعصيب بعد أصحاب الفروض
        }
    }
}
