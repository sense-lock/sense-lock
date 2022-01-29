using System;
using System.Runtime.InteropServices;
using System.Threading;

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
                ret = Sense4Net.S4Enum(null, ref size);
                if (ret != S4NetDefine.S4_INSUFFICIENT_BUFFER)
                {
                    msg = string.Format("Enum error ret value 0x{0:X8}", ret);
                    WriteLineRed(msg);
                }
                // msg = String.Format("now is 64?{0},the sizeof sense4_context is {1}", Sense4.Is64(), Marshal.SizeOf(New SENSE4_CONTEXT()))
                // WriteLineYellow(msg)
                var s4Context = new SENSE4_CONTEXT[(int)Math.Round(size / (double)Marshal.SizeOf(typeof(SENSE4_CONTEXT)) - 1d + 1)];
                ret = Sense4Net.S4Enum(s4Context, ref size);
                if (ret != S4NetDefine.S4_SUCCESS)
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
                    do
                    {

                        ret = Sense4Net.S4Enum(s4Context, ref size);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("Enum error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("Enum success! Has {0} lock(s)", size / (double)Marshal.SizeOf(typeof(SENSE4_CONTEXT)));
                            WriteLineGreen(msg);
                        }

                        ret = Sense4Net.S4Open(ref s4Context[0]);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4Open error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4Open success! ");
                            WriteLineGreen(msg);
                        }
                        var inBuff = new byte[256];
                        int inBufflen;
                        var outBuff = new byte[256];
                        int outBufflen = outBuff.Length;
                        var CrtlReturned = default(int);
                        // get license
                        inBuff[0] = 0x00; //low byte modid
                        inBuff[1] = 0x00; //hig byte modid
                                          // modid length = 2
                        inBufflen = 2;
                        outBufflen = 0;

                        ret = Sense4Net.S4Control(ref s4Context[0], S4NetDefine.S4_GET_LICENSE, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4Control S4_GET_LICENSE error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4Control S4_GET_LICENSE success!");
                            WriteLineGreen(msg);
                        }

                        inBufflen = 10;
                        string fileID = "0001";

                        ret = Sense4Net.S4Execute(ref s4Context[0], fileID, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4Execute error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4Execute success! {0}", BitConverter.ToString(outBuff, 0, CrtlReturned));
                            WriteLineGreen(msg);
                        }


                        ret = Sense4Net.S4ExecuteEx(ref s4Context[0], fileID, S4NetDefine.S4_VM_EXE, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4ExecuteEx error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4ExecuteEx success! {0}", BitConverter.ToString(outBuff, 0, CrtlReturned));
                            WriteLineGreen(msg);
                        }
                        Thread.Sleep(500);

                        ret = Sense4Net.S4Control(ref s4Context[0], S4NetDefine.S4_FREE_LICENSE, inBuff, inBufflen, outBuff, outBufflen, ref CrtlReturned);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4Control S4_FREE_LICENSE error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4Control S4_FREE_LICENSE success!");
                            WriteLineGreen(msg);
                        }
                        ret = Sense4Net.S4Close(ref s4Context[0]);
                        if (ret != S4NetDefine.S4_SUCCESS)
                        {
                            msg = string.Format("S4Close error ret value 0x{0:X8}", ret);
                            WriteLineRed(msg);
                        }
                        else
                        {
                            msg = string.Format("S4Close success! ");
                            WriteLineGreen(msg);
                        }
                        
                    } while (true);
                }//end for next lock

                Console.Read();
            }
        }
    }
}