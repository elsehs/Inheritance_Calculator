using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class Father : Heir
    {
        public Father(string Name)
        {
            this.Name = Name;
            Relationship = "أب";
        }
        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            if (hasBranch)
            {
                return 1.0 / 6.0;
            }
            else
            {
                return -1;
            }
        }
        public void AddResidue(double residueAmount)
        {
            FinalAmount += residueAmount;
        }
    }
}
