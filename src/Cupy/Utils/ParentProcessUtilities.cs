using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cupy.Utils
{
    public static class ParentProcessUtilities
    {
        public static Process GetParentProcess(int id)
        {
            Process parentProcess = null;

            try
            {
                Process process = Process.GetProcessById(id);
                if (process != null)
                {
                    IntPtr handle = process.Handle;
                    int parentId = GetParentProcessId(handle);
                    if (parentId > 0)
                    {
                        parentProcess = Process.GetProcessById(parentId);
                    }
                }
            }
            catch (Exception)
            {
                // 親プロセスの情報が取得できなかった場合は、nullを返す
            }

            return parentProcess;
        }

        private static int GetParentProcessId(IntPtr processHandle)
        {
            var processInfo = new PROCESS_BASIC_INFORMATION();

            if (NtQueryInformationProcess(processHandle, 0, ref processInfo,
                    (uint)Marshal.SizeOf(processInfo), out _) == 0)
            {
                return (int)processInfo.InheritedFromUniqueProcessId;
            }

            return 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_BASIC_INFORMATION
        {
            public IntPtr Reserved1;
            public IntPtr PebBaseAddress;
            public IntPtr Reserved2_0;
            public IntPtr Reserved2_1;
            public IntPtr UniqueProcessId;
            public IntPtr InheritedFromUniqueProcessId;
        }

        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass,
            ref PROCESS_BASIC_INFORMATION processInformation, uint processInformationLength, out int returnLength);
    }
}
