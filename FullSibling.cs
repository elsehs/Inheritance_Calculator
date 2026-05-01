using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class FullSibling : Heir
    {
        int Male_Count { get; set; }
        int Female_Count { get; set; }
        public FullSibling(int males, int females)
        {
            Male_Count = males;
            Female_Count = females;
        }
        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            return 0;
        }
    }
}
