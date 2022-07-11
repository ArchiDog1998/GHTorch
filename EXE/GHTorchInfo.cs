using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GHTorch
{
    public class GHTorchInfo : GH_AssemblyInfo
    {
        public override string Name => "GHTorchTest";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "Pytorch in Grasshopper.";

        public override Guid Id => new Guid("e5d72a7b-2e8f-4e47-97c3-1fa66a88cec5");

        //Return a string identifying you or your company.
        public override string AuthorName => "秋水";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "0.9.0";
    }
}