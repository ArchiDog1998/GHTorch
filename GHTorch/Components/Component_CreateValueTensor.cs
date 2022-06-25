using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Grasshopper.Kernel;
using Rhino.Geometry;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;

namespace GHTorch.Components
{
    public class Component_CreateValueTensor : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the CreateTensor class.
        /// </summary>
        public Component_CreateValueTensor()
          : base("Create Value Tensor", "CValueTensor",
              "Description", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Size", "S", "Size", GH_ParamAccess.list, "1");
            pManager[pManager.AddTextParameter("Value", "V", "Default value", GH_ParamAccess.item)].Optional = true;
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
            string value = string.Empty;
            GH_TensorOption option = new GH_TensorOption(TensorOption.DefaultOption);

            DA.GetDataList(0, list);

            DA.GetData(2, ref option);

            if(DA.GetData(1, ref value))
            {
                DA.SetData(0, new GH_Tensor(Tensor.CreateTensorValue(option.Value, value, list.Select(i => long.Parse(i)).ToArray())));
                return;
            }
            else
            {
                DA.SetData(0, new GH_Tensor(Tensor.CreateTensorEmpty(option.Value, list.Select(i => long.Parse(i)).ToArray())));
            }
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