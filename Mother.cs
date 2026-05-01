using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class Mother:Heir
    {
        public Mother(string Name)
        {
            this.Name = Name;
            Relationship = "أم";
        }
        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            /*   : الأم لها حالتان    
              السدس لو فيه فرع وارث 

              الثلث لو مفيش فرع وارث  */ 
            if (hasBranch)
            {
                return 1.0 / 6.0;
            }
            else
            {
                return 1.0 / 3.0;
            }

        }
    }
}
