using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class Wife: Heir
    {
        public Wife(string Name) 
        { 
            this.Name = Name;
            Relationship = "زوجة";
        }
        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            if (hasBranch)
            {
                return 1.0 / 8.0; // الزوجة ترث الثمن في حالة وجود فرع وارث
            }
            else
            {
                return 1.0 / 4.0;// و ترث الربع في حالة عدم وجود فرع وارث
            }
        }
    }
}
