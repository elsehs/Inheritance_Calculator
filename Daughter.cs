using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Project_Concept2
{
    internal class Daughter : Heir
    {
        public int count {  get; set; }
        public bool hasBrother { get; set; }
        public Daughter(string Name , int count , bool hasBrother)
        {
            this.Name = Name;
            Relationship = "بنت";
            this.count = count;
            this.hasBrother = hasBrother;
        }

        public override double GetShareRatio(bool hasBranch, bool isDeceasedMale)
        {
            if (hasBrother)
            {
                return 0; //  في حالة وجود أخ تاخذ البنت بالتعصيب
            }
            if (count == 1 )
            {
                return 0.5; // اما بنت وحيدة بدون ذكور تأخذ النصف
            }
            else if (count >= 2 ) 
            {
                return 2.0 / 3.0; // أكثر من بنت يأخن الثلثين
            }

            return 0; // حالة اضافية اذا وجد خطأ ف الادخال او تم نسيانه 

        }
    }
}
