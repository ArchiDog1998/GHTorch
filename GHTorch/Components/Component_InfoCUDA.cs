using System;
using System.Collections.Generic;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_InfoCUDA : Component_GHTorch
    { 
        /// <summary>
        /// Initializes a new instance of the Component_InfoCUDA class.
        /// </summary>
        public Component_InfoCUDA()
          : base("CUDA Info", "CUDA",
              "CUDA Info", GHTorch.SubCategory.Info)
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
            pManager.AddBooleanParameter("IsCUDA", "C", "Is CUDA availble.", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Iscudnn", "C", "Is cudnn availble.", GH_ParamAccess.item);
            pManager.AddTextParameter("CUDACount", "N", "The count of CUDA device.", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool cuda, cudnn;
            cuda = cudnn = false;
            ulong count =0;

            PytorchInfoEditor.GetCUDAInfo(ref cuda, ref cudnn, ref count);

            DA.SetData(0, cuda);
            DA.SetData(1, cudnn);
            DA.SetData(2, count);
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
            get { return new Guid("BE127B90-1D88-4044-B011-6ECE645F19AC"); }
        }
    }
}