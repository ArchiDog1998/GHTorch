using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_MofidyTensorTrigonometric : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.secondary;

        /// <summary>
        /// Initializes a new instance of the Component_MofidyTensorTrigonometric class.
        /// </summary>
        public Component_MofidyTensorTrigonometric()
          : base("Tensor Trigonometric", "Tensor Trigonometric",
              "Tensor Trigonometric", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Parameter_Tensor("Tensor", "T", "Tensor to create", GH_ParamAccess.item));
            AddEnumParameter(pManager, "Type", "T", "Arithmetic Type", GH_ParamAccess.item, Tensor.TrigonometricType.Sin);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Parameter_Tensor("Tensor", "T", "Tensor to create", GH_ParamAccess.item));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Tensor tensor = null;
            int type = 0;

            DA.GetData(0, ref tensor);
            DA.GetData(1, ref type);

            DA.SetData(0, new GH_Tensor(Tensor.TensorTrigonometric(tensor.Value, (Tensor.TrigonometricType)type)));

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
            get { return new Guid("46DEC0B8-1A2F-4FA2-9B0F-3767379ABF0F"); }
        }
    }
}