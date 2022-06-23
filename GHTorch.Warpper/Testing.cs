using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Warpper
{
    public class Testing
    {
        [DllImport("GHTorch.Native.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Test();
    }
}
