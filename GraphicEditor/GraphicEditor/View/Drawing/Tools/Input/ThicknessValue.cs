using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.View.Drawing.Tools.Input
{
    internal class ThicknessValue
    {
        public int Value { get; }

        public ThicknessValue(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}px";
        }
    }
}
