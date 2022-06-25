using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CreateTensorOption : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.septenary;

        /// <summary>
        /// Initializes a new instance of the Component_CreateTensorOption class.
        /// </summary>
        public Component_CreateTensorOption()
          : base("Create Tensor Option", "CTensorOption",
              "Description", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            AddEnumParameter(pManager, "DataType", "T", "Tensor Data Type", GH_ParamAccess.item, TensorOption.DataType.Float32);
            pManager.AddBooleanParameter("IsSparse", "S", "Layout, True for kSparse, Flase for kStrided", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("IsCUDA", "C", "CreateOnCUDA", GH_ParamAccess.item, true);
            pManager.AddIntegerParameter("CUDAIndex", "I", "CUDAIndex", GH_ParamAccess.item, 0);
            pManager.AddBooleanParameter("RequiresGrad", "G", "Requires Grad", GH_ParamAccess.item, false);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Parameter_TensorOption("Tensor", "T", "Tensor to create", GH_ParamAccess.item));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int type = 0;
            bool sparse = false;
            bool cuda = false;
            int index = 0;
            bool grad = false;

            DA.GetData(0, ref type);
            DA.GetData(1, ref sparse);
            DA.GetData(2, ref cuda);
            DA.GetData(3, ref index);
            DA.GetData(4, ref grad);

            DA.SetData(0, new GH_TensorOption(new TensorOption((TensorOption.DataType)type, sparse, cuda, index, grad)));
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
            get { return new Guid("431EA194-804C-44AA-9A9E-3BE930C38E30"); }
        }
    }
}