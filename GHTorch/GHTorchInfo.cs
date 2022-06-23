using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GHTorch
{
    public class GHTorchInfo : GH_AssemblyInfo
    {
        public override string Name => "GHTorch";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("0A232BBB-06B1-489A-A87A-2BB09608CEF7");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}