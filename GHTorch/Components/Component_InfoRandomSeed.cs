using System;
using System.Collections.Generic;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_InfoRandomSeed : Component_GHTorch
    {
        /// <summary>
        /// Initializes a new instance of the Component_InfoRandomSeed class.
        /// </summary>
        public Component_InfoRandomSeed()
          : base("Set Random Seed", "Seed",
              "Set Random Seed", GHTorch.SubCategory.Info)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Seed", "S", "Set Seed", GH_ParamAccess.item, "1");
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string seed = String.Empty;

            DA.GetData(0, ref seed);

            PytorchInfoEditor.SetRandomSeed(long.Parse(seed));
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
            get { return new Guid("1418497A-104D-4CB4-A4D5-E3ADB347BB2B"); }
        }
    }
}