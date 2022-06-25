using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CreateSpaceTensor : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

        /// <summary>
        /// Initializes a new instance of the Component_CreateSpaceTensor class.
        /// </summary>
        public Component_CreateSpaceTensor()
          : base("Create Space Tensor", "CSpaceTensor",
              "Create Space Tensor.", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Start", "S", "Start Value", GH_ParamAccess.item, "1");
            pManager.AddTextParameter("End", "E", "End Value", GH_ParamAccess.item, "6");
            pManager.AddTextParameter("Step", "T", "Step or Count", GH_ParamAccess.item, "3");
            pManager.AddBooleanParameter("IsLog", "L", "True for LogSpace, False for LinSpace", GH_ParamAccess.item, false);
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
            string start, end, step;
            start = end = step = string.Empty;
            bool isLog = false;
            GH_TensorOption option = new GH_TensorOption(TensorOption.DefaultOption);

            DA.GetData(0, ref start);
            DA.GetData(1, ref end);
            DA.GetData(2, ref step);
            DA.GetData(3, ref isLog);
            DA.GetData(4, ref option);

            DA.SetData(0, new GH_Tensor(Tensor.CreateTensorSpaces(option.Value, start, end, long.Parse(step), isLog)));

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
            get { return new Guid("CADB3ADC-CD6D-40AB-A6FB-B3A83F94C879"); }
        }
    }
}