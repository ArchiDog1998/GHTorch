using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GHTorch.Warpper;
using Grasshopper.Kernel;
using Rhino.Geometry;


namespace GHTorch.Components
{
    public class Component_CreateTensor : Component_GHTorch
    {
        /// <summary>
        /// Initializes a new instance of the CreateTensor class.
        /// </summary>
        public Component_CreateTensor()
          : base("CreateTensor", "Nickname",
              "Description", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("G", "G", "G", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var strInt = Testing.Test();
            
            DA.SetData(0, Marshal.PtrToStringAnsi(strInt));
            //DA.SetData(1, GHTorch.Sharp.Test.CreateTensor());
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("18E9896C-0FD3-474F-B1AA-2A2D94BAEBC2"); }
        }
    }
}