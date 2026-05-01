using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal abstract class Heir
    {
        public string Name{ get; set; }
        public string Relationship{ get; protected set; }
        public double FinalAmount{  get; protected set; }

        public void SetFinalAmount(double amount)
        {
            if(amount >= 0)
            FinalAmount = amount;
        }

        public abstract double GetShareRatio(bool hasBranch, bool isDeceasedMale);

        public void CalculateFinalShare(double TotalWealth, bool hasBranch,  bool isDeceasedMale)
        {
            double Ratio = GetShareRatio(hasBranch, isDeceasedMale);

            FinalAmount = TotalWealth * Ratio;
        }
    }
}
