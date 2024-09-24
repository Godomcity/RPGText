using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Dongeon
    {
        public int EasyReDef { get; set; }
        public int NormalReDef { get; set;}
        public int DifficultReDef { get; set; }
        public string Easy {  get; set; }
        public string Normal { get; set; }
        public string Difficult { get; set; }
        public bool IsEasyClear { get; set; }
        public bool IsNormalClear { get; set; }
        public bool IsDifficultClear { get; set; }

        public Dongeon(int easyReDef, int normalReDef, int difficultReDef, string easy, string normal, string difficult)
        {
            EasyReDef = easyReDef;
            NormalReDef = normalReDef;
            DifficultReDef = difficultReDef;
            Easy = easy;
            Normal = normal;
            Difficult = difficult;
            IsEasyClear = false;
            IsNormalClear = false; 
            IsDifficultClear = false;
        }
    }
}
