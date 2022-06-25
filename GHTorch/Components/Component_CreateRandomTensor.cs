using System;
using System.Collections.Generic;
using System.Linq;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CreateRandomTensor : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the Component_CreateRandomTensor class.
        /// </summary>
        public Component_CreateRandomTensor()
          : base("Create Random Tensor", "CRandomTensor",
              "Create Random Tensor", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Size", "S", "Size", GH_ParamAccess.list, "1");
            pManager.AddBooleanParameter("Normal", "N", "True for unit normal distribution, False for uniform distribution on [0, 1).", GH_ParamAccess.item, false);
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
            List<string> list = new List<string>();
            bool normal = false;
            GH_TensorOption option = new GH_TensorOption(TensorOption.DefaultOption);

            DA.GetDataList(0, list);
            DA.GetData(1, ref normal);
            DA.GetData(2, ref option);

            DA.SetData(0, new GH_Tensor(Tensor.CreateTensorRandom(option.Value, normal, list.Select(i => long.Parse(i)).ToArray())));
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
            get { return new Guid("A29C7C9F-E95D-4AE1-B269-6F1A7854BB96"); }
        }
    }
}