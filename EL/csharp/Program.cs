using System;
using System.Runtime.InteropServices;

namespace Elite4SDemo
{
    public static class MyConverter
    {
        /// <summary>
    /// 由结构体转换为byte数组
    /// </summary>
        public static byte[] StructureToByte<T>(T structure)
        {
            int size = Marshal.SizeOf(typeof(T));
            var buffer = new byte[size];
            var bufferIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, bufferIntPtr, true);
                Marshal.Copy(bufferIntPtr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(bufferIntPtr);
            }

            return buffer;
        }

        /// <summary>
    /// 由byte数组转换为结构体
    /// </summary>
        public static T ByteToStructure<T>(byte[] dataBuffer)
        {
            object structure = null;
            int size = Marshal.SizeOf(typeof(T));
            var allocIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(dataBuffer, 0, allocIntPtr, size);
                structure = Marshal.PtrToStructure(allocIntPtr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(allocIntPtr);
            }

            return (T)structure;
        }
    }

    namespace SenseShield
    {
        class Program
        {

            // 打印方式定义
            public static void WriteLineGreen(string s)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(s);
                Console.ResetColor();
            }

            public static void WriteLineRed(string s)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(s);
                Console.ResetColor();
            }

            public static void WriteLineYellow(string s)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(s);
                Console.ResetColor();
            }

            public static void Main()
            {
                int ret = 0;
                var size = default(int);
                string msg = string.Empty;
                ret = Sense4.S4Enum(null, ref size);
                if (ret != S4Define.S4_INSUFFICIENT_BUFFER)
                {
                    msg = string.Format("Enum error ret value 0x{0:X8}", ret);
                    WriteLineRed(msg);
                }
                // msg = String.Format("now is 64?{0},the sizeof sense4_context is {1}", Sense4.Is64(), Marshal.SizeOf(New SENSE4_CONTEXT()))
                // WriteLineYellow(msg)
                var s4Context = new SENSE4_CONTEXT[(int)Math.Round(size / (double)Marshal.SizeOf(typeof(SENSE4_CONTEXT)) - 1d + 1)];
                ret = Sense4.S4Enum(s4Context, ref size);
                if (ret != S4Define.S4_SUCCESS)
                {
                    msg = string.Format("Enum error ret value 0x{0:X8}", ret);
                    WriteLineRed(msg);
                }
                else
                {
                    msg = string.Format("Enum success! Has {0} lock(s)", size / (double)Marshal.SizeOf(typeof(SENSE4_CONTEXT)));
                    WriteLineGreen(msg);
                }

                for(int curlocknum = 0; curlocknum < s4Context.Length; curlocknum++)
                {
                    var s4Ctx = s4Context[curlocknum];
                    // you can use the function S4OpenEx or S4Open 
                    ret = Sense4.S4Open(ref s4Ctx);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Open error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Open success! ");
                        WriteLineGreen(msg);
                    }

                    var s4Openinfo = default(S4OPENINFO);
                    s4Openinfo.dwS4OpenInfoSize = Marshal.SizeOf(s4Openinfo);
                    s4Openinfo.dwShareMode = S4Define.S4_SHARE_MODE;
                    ret = Sense4.S4OpenEx(ref s4Ctx, ref s4Openinfo);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4OpenEx error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4OpenEx success! ");
                        WriteLineGreen(msg);
                    }

                    // remake a new root dir ,erase the dir,the creat the root
                    var devPin = new[] { (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38 };
                    var oldUserPin = new[] { (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38 };
                    var newUserPin = new[] { (byte)0x20, (byte)0x21, (byte)0x04, (byte)0x10, (byte)0x12, (byte)0x23, (byte)0x59, (byte)0xFF };
                    ret = Sense4.S4VerifyPin(ref s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4VerifyPin error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4VerifyPin success! ");
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4ChangeDir(ref s4Ctx, @"\");
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4ChangeDir error ret value {0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4ChangeDir success! ");
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4EraseDir(ref s4Ctx, null);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4EraseDir error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4EraseDir success! ");
                        WriteLineGreen(msg);
                    }

                    //ret = Sense4.S4CreateDir(ref s4Ctx, @"\", 0, S4Define.S4_CREATE_ROOT_DIR);
                    //if (ret != S4Define.S4_SUCCESS)
                    //{
                    //    msg = string.Format("S4CreateDir error ret value 0x{0:X8}", ret);
                    //    WriteLineRed(msg);
                    //}
                    //else
                    //{
                    //    msg = string.Format("S4CreateDir success! ");
                    //    WriteLineGreen(msg);
                    //}

                    msg = string.Format("now is 64?{0},the sizeof S4CREATEDIRINFO is {1}", Sense4.Is64(), Marshal.SizeOf(new S4CREATEDIRINFO()));
                    WriteLineYellow(msg);
                    var s4Createdir = default(S4CREATEDIRINFO);
                    S4CREATEDIRINFO.dwS4CreateDirInfoSize = Marshal.SizeOf(s4Createdir);
                    s4Createdir.szAtr = new[] { (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38 };
                    s4Createdir.NetConfig = new S4NETCONFIG();
                    ret = Sense4.S4CreateDirEx(ref s4Ctx, @"\", 0, S4Define.S4_CREATE_ROOT_DIR, s4Createdir);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4CreateDirEx error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4CreateDirEx success! ");
                        WriteLineGreen(msg);
                    }

                    var inBuff = new byte[256];
                    int inBufflen;
                    var outBuff = new byte[256];
                    int outBufflen = outBuff.Length;
                    var CrtlReturned = default(int);

                    // S4_LED_WINK  struct is 
                    inBuff[0] = 0x3;
                    inBuff[1] = 0;
                    inBuff[2] = 0;
                    inBuff[3] = 0;
                    inBufflen = inBuff.Length;
                    outBufflen = outBuff.Length;
                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_LED_WINK, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control led wink error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Control led wink success!  The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned));
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_LED_DOWN, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control led S4_LED_DOWN error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Control led S4_LED_DOWN success!  The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned));
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_LED_UP, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control led S4_LED_UP error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Control led S4_LED_UP success! The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned));
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_GET_DEVICE_TYPE, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control S4_GET_DEVICE_TYPE error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Control S4_GET_DEVICE_TYPE success! The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned));
                        WriteLineGreen(msg);
                    }

                    var CustomerID = new byte[4];
                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_GET_DEVICE_USABLE_SPACE, null, 0, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control S4_GET_DEVICE_USABLE_SPACE error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Control S4_GET_DEVICE_USABLE_SPACE success!  The output value is {0} ", outBuff[0] + outBuff[1] * 256);
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_GET_MANUFACTURE_DATE, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control S4_GET_MANUFACTURE_DATE error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        var manufactureDate = MyConverter.ByteToStructure<S4_MANUFACTURE_DATE>(outBuff);
                        msg = string.Format("S4Control S4_GET_MANUFACTURE_DATE success!  The output value is {0} ", manufactureDate.ToString());
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Control(ref s4Ctx, S4Define.S4_GET_CURRENT_TIME, null, 0, outBuff, outBufflen, ref CrtlReturned);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Control S4_GET_CURRENT_TIME error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        var lockTime = MyConverter.ByteToStructure<TM>(outBuff);
                        msg = string.Format("S4Control S4_GET_CURRENT_TIME success!  The output value is {0} ", lockTime.ToString());
                        WriteLineGreen(msg);
                    }

                    string lpszPath = new string(@"\".ToCharArray());
                    ret = Sense4.S4ChangeDir(ref s4Ctx, lpszPath);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4ChangeDir error ret value {0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4ChangeDir success! ");
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4VerifyPin(ref s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4VerifyPin error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4VerifyPin success! ");
                        WriteLineGreen(msg);
                    }

                    // 1970 is the size of Directory,which is a variable ,not a const
                    int dirSize = 1970;
                    string lpszDirID = "d001";
                    ret = Sense4.S4CreateDir(ref s4Ctx, lpszDirID, dirSize, S4Define.S4_CREATE_SUB_DIR);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4CreateDir error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4CreateDir success! ");
                        WriteLineGreen(msg);
                    }

                    lpszPath = "d001";
                    ret = Sense4.S4ChangeDir(ref s4Ctx, lpszPath);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4ChangeDir error ret value {0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4ChangeDir success! ");
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4VerifyPin(ref s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4VerifyPin error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4VerifyPin success! ");
                        WriteLineGreen(msg);
                    }
                    // you must change into the target dir before erase it
                    ret = Sense4.S4EraseDir(ref s4Ctx, null);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4EraseDir error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4EraseDir success! ");
                        WriteLineGreen(msg);
                    }

                    lpszPath = @"\";
                    ret = Sense4.S4ChangeDir(ref s4Ctx, lpszPath);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4ChangeDir error ret value {0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4ChangeDir success! ");
                        WriteLineGreen(msg);
                    }

                    string fileID = "0001";
                    string lpszPCFilePath = "CheckTime.hex";
                    int pdwFileSize = 0;
                    int dwFlags = S4Define.S4_CREATE_NEW;
                    int dwFileType = S4Define.S4_HEX_FILE;
                    int pdwBytesWritten = default;
                    ret = Sense4.PS4WriteFile(ref s4Ctx, fileID, lpszPCFilePath, ref pdwFileSize, S4Define.S4_CREATE_NEW, dwFileType, ref pdwBytesWritten);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("PS4WriteFile error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("PS4WriteFile success! ");
                        WriteLineGreen(msg);
                    }

                    fileID = "0002";
                    var returnLen = default(int);
                    var pBuffer = new[] { (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38 };
                    int realSize = default;
                    ret = Sense4.S4WriteFile(ref s4Ctx, fileID, 0, pBuffer, pBuffer.Length, pBuffer.Length, ref realSize, S4Define.S4_CREATE_NEW, S4Define.S4_EXE_FILE);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4WriteFile error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4WriteFile success! ");
                        WriteLineGreen(msg);
                    }

                //ret = Sense4.S4ChangePin(ref s4Ctx, oldUserPin, oldUserPin.Length, newUserPin, newUserPin.Length, S4Define.S4_USER_PIN);
                //if (ret != S4Define.S4_SUCCESS)
                //{
                //    msg = string.Format("S4ChangePin error ret value 0x{0:X8}", ret);
                //    WriteLineRed(msg);
                //}
                //else
                //{
                //    msg = string.Format("S4ChangePin success! ");
                //    WriteLineGreen(msg);
                //}
                //// verify the old pin, there must to return the wrong code when you've change the pin
                ret = Sense4.S4VerifyPin(ref s4Ctx, oldUserPin, oldUserPin.Length, S4Define.S4_USER_PIN);
                if (ret != S4Define.S4_SUCCESS)
                {
                    msg = string.Format("S4VerifyPin error ret value 0x{0:X8}", ret);
                    WriteLineRed(msg);
                }
                else
                {
                    msg = string.Format("S4VerifyPin success! ");
                    WriteLineGreen(msg);
                }
                //Verify the new pin
                //ret = Sense4.S4VerifyPin(ref s4Ctx, newUserPin, newUserPin.Length, S4Define.S4_USER_PIN);
                //if (ret != S4Define.S4_SUCCESS)
                //{
                //    msg = string.Format("S4VerifyPin error ret value 0x{0:X8}", ret);
                //    WriteLineRed(msg);
                //}
                //else
                //{
                //    msg = string.Format("S4VerifyPin success! ");
                //    WriteLineGreen(msg);
                //}

                inBufflen = 10;
                fileID = "0001";

                ret = Sense4.S4Execute(ref s4Ctx, fileID, inBuff, inBufflen, outBuff, outBufflen, ref returnLen);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Execute error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Execute success! {0}", BitConverter.ToString(outBuff, 0, returnLen));
                        WriteLineGreen(msg);
                    }


                    ret = Sense4.S4ExecuteEx(ref s4Ctx, fileID, S4Define.S4_VM_EXE, inBuff, inBufflen, outBuff, outBufflen, ref returnLen);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4ExecuteEx error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4ExecuteEx success! {0}", BitConverter.ToString(outBuff, 0, returnLen));
                        WriteLineGreen(msg);
                    }

                    ret = Sense4.S4Close(ref s4Ctx);
                    if (ret != S4Define.S4_SUCCESS)
                    {
                        msg = string.Format("S4Close error ret value 0x{0:X8}", ret);
                        WriteLineRed(msg);
                    }
                    else
                    {
                        msg = string.Format("S4Close success! ");
                        WriteLineGreen(msg);
                    }
                }

                Console.Read();
            }
        }
    }
}