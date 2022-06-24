﻿using System;
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
    public class Component_CreateTensor : Component_GHTorch
    {
        /// <summary>
        /// Initializes a new instance of the CreateTensor class.
        /// </summary>
        public Component_CreateTensor()
          : base("CreateTensor", "CTensor",
              "Description", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Size", "S", "Size", GH_ParamAccess.list, 1);
            pManager.AddBooleanParameter("RequiresGrad", "R", "Requires Grad", GH_ParamAccess.item, false);
            AddEnumParameter<CreateTensorFunction>(pManager, "TensorFunction", "F", "Create Tensor Function", GH_ParamAccess.item);
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
            List<int> list = new List<int>();
            bool require = false;
            int type = 0;

            DA.GetDataList(0, list);
            DA.GetData(1, ref require);
            DA.GetData(2, ref type);


            DA.SetData(0, new GH_Tensor(Tensor.CreateTensor((CreateTensorFunction) type, require, list.Select(i => (long)i).ToArray())));
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