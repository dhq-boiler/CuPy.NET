using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cupy
{
    public static class PythonInterop
    {
        /// <summary>
        /// Copies data from a NumPy array to the destination .NET array
        /// </summary>
        /// <param name="pSource">Pointer to a NumPy array to copy from</param>
        /// <param name="dest">.NET array to be copied into</param>
        /// <remarks>This routine handles Boolean arrays in a special way because NumPy arrays have each element occupying 1 byte while .NET has them occupying 4 bytes</remarks>
		public static void CopyFromPointer(IntPtr pSource, Array dest)
        {
            Type elementType = dest.GetType().GetElementType();
            int sizeOfElement = Marshal.SizeOf(elementType);
            if (elementType == typeof(Boolean))
                sizeOfElement = 1;

            int byteCount = sizeOfElement;
            for (int i = 0; i < dest.Rank; i++)
            {
                byteCount *= dest.GetLength(i);
            }

            var gch = GCHandle.Alloc(dest);
            var tPtr = Marshal.UnsafeAddrOfPinnedArrayElement(dest, 0);
            MemCopy(pSource, tPtr, byteCount);
            gch.Free();
        }

        /// <summary>
        /// Copies data from a .NET array to a NumPy array
        /// </summary>
        /// <param name="source">.NET array to be copied from</param>
        /// <param name="pDest">Pointer to a NumPy array to copy into</param>
		public static void CopyToPointer(Array source, IntPtr pDest)
        {
            Type elementType = source.GetType().GetElementType();
            int sizeOfElement = Marshal.SizeOf(elementType);
            if (elementType == typeof(Boolean))
                sizeOfElement = 1;

            int byteCount = sizeOfElement;
            for (int i = 0; i < source.Rank; i++)
                byteCount *= source.GetLength(i);

            var gch = GCHandle.Alloc(source);
            var tPtr = Marshal.UnsafeAddrOfPinnedArrayElement(source, 0);
            MemCopy(tPtr, pDest, byteCount);
            gch.Free();
        }

        private static readonly int SIZEOFINT = Marshal.SizeOf(typeof(int));
        private static unsafe void MemCopy(IntPtr pSource, IntPtr pDest, int byteCount)
        {
            int count = byteCount / SIZEOFINT;
            int rest = byteCount % count;
            unchecked
            {
                int* ps = (int*)pSource.ToPointer(), pd = (int*)pDest.ToPointer();
                // Loop over the cnt in blocks of 4 bytes, 
                // copying an integer (4 bytes) at a time:
                for (int n = 0; n < count; n++)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
                // Complete the copy by moving any bytes that weren't moved in blocks of 4:
                if (rest > 0)
                {
                    byte* ps1 = (byte*)ps;
                    byte* pd1 = (byte*)pd;
                    for (int n = 0; n < rest; n++)
                    {
                        *pd1 = *ps1;
                        pd1++;
                        ps1++;
                    }
                }
            }
        }
    }
}
