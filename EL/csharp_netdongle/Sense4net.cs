using System;
using System.Runtime.InteropServices;

namespace Elite4SDemo.SenseShield
{
    public class Sense4Net
    {
        public static bool Is64()
        {
            if (IntPtr.Size == 8)
            {
                return true;
            }

            return false;
        }

        private const string dllName32 = "/dlls/x86/sense4user.dll";
        private const string dllName64 = "/dlls/x64/sense4user.dll";

        [DllImport(dllName32, EntryPoint = "S4Enum", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Enum32([Out, MarshalAs(UnmanagedType.LPArray)] SENSE4_CONTEXT[] s4Constext, ref int size);
        [DllImport(dllName64, EntryPoint = "S4Enum", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Enum64([Out, MarshalAs(UnmanagedType.LPArray)] SENSE4_CONTEXT[] s4Constext, ref int size);

        internal static int S4Enum([Out, MarshalAs(UnmanagedType.LPArray)] SENSE4_CONTEXT[] s4Constext, ref int size)
        {
            if (Is64())
            {
                return Sense4Net.S4Enum64(s4Constext, ref size);
            }

            return Sense4Net.S4Enum32(s4Constext, ref size);
        }

        [DllImport(dllName32, EntryPoint = "S4Open", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Open32(ref SENSE4_CONTEXT s4Constext);
        [DllImport(dllName64, EntryPoint = "S4Open", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Open64(ref SENSE4_CONTEXT s4Constext);

        internal static int S4Open(ref SENSE4_CONTEXT s4Constext)
        {
            if (Is64())
            {
                return S4Open64(ref s4Constext);
            }

            return S4Open32(ref s4Constext);
        }

        [DllImport(dllName32, EntryPoint = "S4OpenEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4OpenEx32(ref SENSE4_CONTEXT s4Constext, ref S4OPENINFO s4Openinfo);
        [DllImport(dllName64, EntryPoint = "S4OpenEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4OpenEx64(ref SENSE4_CONTEXT s4Constext, ref S4OPENINFO s4Openinfo);

        internal static int S4OpenEx(ref SENSE4_CONTEXT s4Constext, ref S4OPENINFO s4Openinfo)
        {
            if (Is64())
            {
                return S4OpenEx64(ref s4Constext, ref s4Openinfo);
            }

            return S4OpenEx32(ref s4Constext, ref s4Openinfo);
        }

        [DllImport(dllName32, EntryPoint = "S4Close", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Close32(ref SENSE4_CONTEXT s4Constext);
        [DllImport(dllName64, EntryPoint = "S4Close", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Close64(ref SENSE4_CONTEXT s4Constext);

        internal static int S4Close(ref SENSE4_CONTEXT s4Constext)
        {
            if (Is64())
            {
                return S4Close64(ref s4Constext);
            }

            return S4Close32(ref s4Constext);
        }

        [DllImport(dllName32, EntryPoint = "S4Control", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Control32(ref SENSE4_CONTEXT s4Ctx, int ctlCode, byte[] inBuff, int inBuffLen, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] outBuff, int outBuffLen, ref int BytesReturned);
        [DllImport(dllName64, EntryPoint = "S4Control", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Control64(ref SENSE4_CONTEXT s4Ctx, int ctlCode, [In][MarshalAs(UnmanagedType.LPArray)] byte[] inBuff, int inBuffLen, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] outBuff, int outBuffLen, ref int BytesReturned);

        internal static int S4Control(ref SENSE4_CONTEXT s4Ctx, int ctlCode, byte[] inBuff, int inBuffLen, byte[] outBuff, int outBuffLen, ref int BytesReturned)
        {
            if (Is64())
            {
                return Sense4Net.S4Control64(ref s4Ctx, ctlCode, inBuff, inBuffLen, outBuff, outBuffLen, ref BytesReturned);
            }

            return Sense4Net.S4Control32(ref s4Ctx, ctlCode, inBuff, inBuffLen, outBuff, outBuffLen, ref BytesReturned);
        }

        [DllImport(dllName64, EntryPoint = "S4ChangeDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ChangeDir64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszPath);
        [DllImport(dllName32, EntryPoint = "S4ChangeDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ChangeDir32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszPath);

        internal static int S4ChangeDir(ref SENSE4_CONTEXT s4Ctx, string lpszPath)
        {
            if (Is64())
            {
                return S4ChangeDir64(ref s4Ctx, lpszPath);
            }

            return S4ChangeDir32(ref s4Ctx, lpszPath);
        }

        [DllImport(dllName64, EntryPoint = "S4CreateDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4CreateDir64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID, int dwDirSize, int dwFlags);
        [DllImport(dllName32, EntryPoint = "S4CreateDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4CreateDir32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID, int dwDirSize, int dwFlags);

        internal static int S4CreateDir(ref SENSE4_CONTEXT s4Ctx, string lpszDirID, int dwDirSize, int dwFlags)
        {
            if (Is64())
            {
                return S4CreateDir64(ref s4Ctx, lpszDirID, dwDirSize, dwFlags);
            }

            return S4CreateDir32(ref s4Ctx, lpszDirID, dwDirSize, dwFlags);
        }

        [DllImport(dllName64, EntryPoint = "S4CreateDirEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4CreateDirEx64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID, int dwDirSize, int dwFlags, ref S4CREATEDIRINFO s4Createdir);
        [DllImport(dllName32, EntryPoint = "S4CreateDirEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4CreateDirEx32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID, int dwDirSize, int dwFlags, ref S4CREATEDIRINFO s4Createdir);

        internal static int S4CreateDirEx(ref SENSE4_CONTEXT s4Ctx, string lpszDirID, int dwDirSize, int dwFlags, S4CREATEDIRINFO s4Createdir)
        {
            if (Is64())
            {
                return S4CreateDirEx64(ref s4Ctx, lpszDirID, dwDirSize, dwFlags, ref s4Createdir);
            }

            return S4CreateDirEx32(ref s4Ctx, lpszDirID, dwDirSize, dwFlags, ref s4Createdir);
        }

        [DllImport(dllName64, EntryPoint = "S4EraseDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4EraseDir64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID);
        [DllImport(dllName32, EntryPoint = "S4EraseDir", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4EraseDir32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszDirID);

        internal static int S4EraseDir(ref SENSE4_CONTEXT s4Ctx, string lpszDirID)
        {
            if (Is64())
            {
                return S4EraseDir64(ref s4Ctx, lpszDirID);
            }

            return S4EraseDir32(ref s4Ctx, lpszDirID);
        }

        // To be safer,the Pin is must to be the byte()
        [DllImport(dllName64, EntryPoint = "S4VerifyPin", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4VerifyPin64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pbPin, int dwPinLen, int dwPinType);
        [DllImport(dllName32, EntryPoint = "S4VerifyPin", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4VerifyPin32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pbPin, int dwPinLen, int dwPinType);

        internal static int S4VerifyPin(ref SENSE4_CONTEXT s4Ctx, byte[] pbPin, int dwPinLen, int dwPinType)
        {
            if (Is64())
            {
                return S4VerifyPin64(ref s4Ctx, pbPin, dwPinLen, dwPinType);
            }

            return S4VerifyPin32(ref s4Ctx, pbPin, dwPinLen, dwPinType);
        }

        [DllImport(dllName64, EntryPoint = "S4ChangePin", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ChangePin64(ref SENSE4_CONTEXT s4Ctx, byte[] pbOldPin, int dwOldPinLen, byte[] pbNewPin, int dwNewPinLen, int dwPinType);
        [DllImport(dllName32, EntryPoint = "S4ChangePin", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ChangePin32(ref SENSE4_CONTEXT s4Ctx, byte[] pbOldPin, int dwOldPinLen, byte[] pbNewPin, int dwNewPinLen, int dwPinType);

        internal static int S4ChangePin(ref SENSE4_CONTEXT s4Ctx, byte[] pbOldPin, int dwOldPinLen, byte[] pbNewPin, int dwNewPinLen, int dwPinType)
        {
            if (Is64())
            {
                return S4ChangePin64(ref s4Ctx, pbOldPin, dwOldPinLen, pbNewPin, dwNewPinLen, dwPinType);
            }

            return S4ChangePin32(ref s4Ctx, pbOldPin, dwOldPinLen, pbNewPin, dwNewPinLen, dwPinType);
        }

        [DllImport(dllName64, EntryPoint = "S4WriteFile", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4WriteFile64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, int dwOffset, byte[] pBuffer, int dwBufferSize, int dwFileSize, ref int pdwBytesWritten, int dwFlags, int bFileType);
        [DllImport(dllName32, EntryPoint = "S4WriteFile", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4WriteFile32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, int dwOffset, byte[] pBuffer, int dwBufferSize, int dwFileSize, ref int pdwBytesWritten, int dwFlags, int bFileType);

        internal static int S4WriteFile(ref SENSE4_CONTEXT s4Ctx, string lpszFileID, int dwOffset, byte[] pBuffer, int dwBufferSize, int dwFileSize, ref int pdwBytesWritten, int dwFlags, int bFileType)
        {
            if (Is64())
            {
                return S4WriteFile64(ref s4Ctx, lpszFileID, dwOffset, pBuffer, dwBufferSize, dwFileSize, ref pdwBytesWritten, dwFlags, bFileType);
            }

            return S4WriteFile32(ref s4Ctx, lpszFileID, dwOffset, pBuffer, dwBufferSize, dwFileSize, ref pdwBytesWritten, dwFlags, bFileType);
        }

        [DllImport(dllName64, EntryPoint = "PS4WriteFile", CallingConvention = CallingConvention.StdCall)]
        internal static extern int PS4WriteFile64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, [In][MarshalAs(UnmanagedType.LPStr)] string lpszPCFilePath, ref int pdwFileSize, int dwFlags, int dwFileType, ref int pdwBytesWritten);
        [DllImport(dllName32, EntryPoint = "PS4WriteFile", CallingConvention = CallingConvention.StdCall)]
        internal static extern int PS4WriteFile32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, [In][MarshalAs(UnmanagedType.LPStr)] string lpszPCFilePath, ref int pdwFileSize, int dwFlags, int dwFileType, ref int pdwBytesWritten);

        internal static int PS4WriteFile(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, [In][MarshalAs(UnmanagedType.LPStr)] string lpszPCFilePath, ref int pdwFileSize, int dwFlags, int dwFileType, ref int pdwBytesWritten)
        {
            if (Is64())
            {
                return PS4WriteFile64(ref s4Ctx, lpszFileID, lpszPCFilePath, ref pdwFileSize, dwFlags, dwFileType, ref pdwBytesWritten);
            }

            return PS4WriteFile32(ref s4Ctx, lpszFileID, lpszPCFilePath, ref pdwFileSize, dwFlags, dwFileType, ref pdwBytesWritten);
        }

        [DllImport(dllName64, EntryPoint = "S4Execute", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Execute64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pInBuff, int dwInbufferSize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);
        [DllImport(dllName32, EntryPoint = "S4Execute", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4Execute32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pInBuff, int dwInbufferSize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        internal static int S4Execute(ref SENSE4_CONTEXT s4Ctx, string lpszFileID, byte[] pInBuff, int dwInbufferSize, byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned)
        {
            if (Is64())
            {
                return Sense4Net.S4Execute64(ref s4Ctx, lpszFileID, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
            }

            return Sense4Net.S4Execute32(ref s4Ctx, lpszFileID, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        }

        [DllImport(dllName64, EntryPoint = "S4ExecuteEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ExecuteEx64(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, int dwFlag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pInBuff, int dwInbufferSize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);
        [DllImport(dllName32, EntryPoint = "S4ExecuteEx", CallingConvention = CallingConvention.StdCall)]
        internal static extern int S4ExecuteEx32(ref SENSE4_CONTEXT s4Ctx, [In][MarshalAs(UnmanagedType.LPStr)] string lpszFileID, int dwFlag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] pInBuff, int dwInbufferSize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        internal static int S4ExecuteEx(ref SENSE4_CONTEXT s4Ctx, string lpszFileID, int dwFlag, byte[] pInBuff, int dwInbufferSize, byte[] pOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned)
        {
            if (Is64())
            {
                return Sense4Net.S4ExecuteEx64(ref s4Ctx, lpszFileID, dwFlag, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
            }

            return Sense4Net.S4ExecuteEx32(ref s4Ctx, lpszFileID, dwFlag, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SENSE4_CONTEXT
    {
        public int dwIndex;       // device index
        public int dwVersion;     // version		
        public UIntPtr hLock;         // device handle 64 bit is Uint64,32bit is Uint32
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] reserve;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public byte[] bAtr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bID;
        public int dwAtrLen;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct EFINFO
    {
        public ushort EfID;
        public byte EfType;
        public ushort EfSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct S4_MANUFACTURE_DATE
    {
        public ushort wYear;
        public byte byMonth;
        public byte byDay;

        public override string ToString()
        {
            string thisString = string.Format("The manufacture time is {0}-{1}-{2}", wYear, byMonth, byDay);
            return thisString;
        }
    }

    // <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    public struct TM
    {
        public int tm_sec;
        public int tm_min;
        public int tm_hour;
        public int tm_mday;
        public int tm_mon;
        public int tm_year;
        public int tm_wday;
        public int tm_yday;
        public int tm_isdst;

        public override string ToString()
        {
            string tmString = string.Format("locktime:{0}-{1}-{2}  {3}:{4}:{5} ,which is the {6} day since Sunday, and the {7} day science January 1 ", tm_year + 1900, tm_mon + 1, tm_mday, tm_hour, tm_min, tm_sec, tm_wday, tm_yday);
            return tmString;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct S4OPENINFO
    {
        public int dwS4OpenInfoSize;
        public int dwShareMode;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct S4CREATEDIRINFO
    {
        public static int dwS4CreateDirInfoSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] szAtr;
        public S4NETCONFIG NetConfig;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct S4NETCONFIG
    {
        public int dwLicenseMode;
        public int dwModuleCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ModuleInfo;
    }
}