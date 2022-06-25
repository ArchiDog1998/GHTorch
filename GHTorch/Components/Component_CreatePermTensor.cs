using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CreatePermTensor : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

        /// <summary>
        /// Initializes a new instance of the Component_CreatePermTensor class.
        /// </summary>
        public Component_CreatePermTensor()
          : base("Create Perm Tensor", "CPermTensor",
              "Create Perm Tensor", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("N", "N", "N", GH_ParamAccess.item, "6");
            pManager[pManager.AddParameter(new Parameter_TensorOption("Option", "O", "Option", GH_ParamAccess.item))].Optional = true;

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
            string n = String.Empty;
            GH_TensorOption option = new GH_TensorOption(TensorOption.DefaultOption);


            DA.GetData(0, ref n);
            DA.GetData(1, ref option);

            DA.SetData(0, new GH_Tensor(Tensor.CreateTensorPerm(option.Value, long.Parse(n))));
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
            get { return new Guid("6540F967-6B9D-441C-B48F-63CE59FC8F0A"); }
        }
    }
}