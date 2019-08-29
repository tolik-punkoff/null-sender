using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;


namespace Chaos_Software
{
    public static class CommonFunction
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)] //API-функция открытия файла
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flags,
            IntPtr template);

        public static void ErrMessage(string stMessage)
        {
            MessageBox.Show(stMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool OpenToView(string fileName) //открытие файла в ассоциированной программе
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = fileName;
            pInfo.UseShellExecute = true;
            try
            {
                Process p = Process.Start(pInfo);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static FileStream OpenNul()
        {
            SafeFileHandle ptr = CreateFile("nul", FileAccess.Write, FileShare.Write, IntPtr.Zero, FileMode.Create, 0, IntPtr.Zero);
            //Не получилось?
            if (ptr.IsInvalid)
            {
                //Генерируем эксепшн
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                return null;
            }
            else
            {
                return new FileStream(ptr, FileAccess.Write);
            }
        }


    }
}
