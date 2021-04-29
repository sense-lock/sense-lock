using System;
using System.Runtime.InteropServices;


namespace SenseShield
{
    public class LCDefine
    {
        public static bool Is64()
        {
            if (IntPtr.Size == 8)
            {
                return true;
            }

            return false;
        }

        public const string dll32 = "./dll/x86/Sense_LC.dll";
        public const string dll64 = "./dll/x64/Sense_LC.dll";

        // LE API function interface

        // Open matching device according to Developer ID and Index
        // 
        // @parameter vendor[in]  Developer ID (0=All)
        // @parameter index[in]  Device Index (0=1st, and so on)
        // @parameter handle[out] Device handle returned
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_open", CallingConvention = CallingConvention.StdCall)]
        internal static extern uint LC_open32(uint vendor, uint index, ref uint handle);
        [DllImport(dll64, EntryPoint = "LC_open", CallingConvention = CallingConvention.StdCall)]
        internal static extern uint LC_open64(uint vendor, uint index, ref uint handle);

        internal static uint LC_open(uint vendor, uint index, ref uint handle)
        {
            if (Is64())
            {
                return LC_open64(vendor, index, ref handle);
            }

            return LC_open32(vendor, index, ref handle);
        }


        // Close an open device
        // 
        // @parameter handle[in]  Device handle opened
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned


        [DllImport(dll32, EntryPoint = "LC_close", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_close32(uint handle);
        [DllImport(dll64, EntryPoint = "LC_close", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_close64(uint handle);

        public static uint LC_close(uint handle)
        {
            if (Is64())
            {
                return LC_close64(handle);
            }

            return LC_close32(handle);
        }


        // 
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter flag [in]  Password Type(Admin 0, Generic 1, Authentication 2)
        // @parameter passwd[in]  Password(8 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_passwd32(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd);
        [DllImport(dll64, EntryPoint = "LC_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_passwd64(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd);

        public static uint LC_passwd(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd)
        {
            if (Is64())
            {
                return LC_passwd64(handle, flag, passwd);
            }

            return LC_passwd32(handle, flag, passwd);
        }


        // 
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter block[in]  Number of block to be read
        // @parameter buffer[out] Read data buffer (greater than 512 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_read", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_read32(uint handle, uint block, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer);
        [DllImport(dll64, EntryPoint = "LC_read", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_read64(uint handle, uint block, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

        public static uint LC_read(uint handle, uint block, [Out,MarshalAs(UnmanagedType.LPArray)]byte[] buffer)
        {
            if (Is64())
            {
                return LCDefine.LC_read64(handle, block,buffer);
            }

            return LCDefine.LC_read32(handle, block,buffer);
        }

        // Write data to specified block
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter block[in]  Number of block to be written
        // @parameter buffer[in]  Write data buffer (greater than 512 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned

        [DllImport(dll32, EntryPoint = "LC_write", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_write32(uint handle, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer);
        [DllImport(dll64, EntryPoint = "LC_write", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_write64(uint handle, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

        public static uint LC_write(uint handle, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer)
        {
            if (Is64())
            {
                return LC_write64(handle, block, buffer);
            }

            return LC_write32(handle, block, buffer);
        }


        // Encrypt data by AES algorithm
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter plaintext[in]  Plain text to be encrypted (16 bytes)
        // @parameter ciphertext[out] Cipher text after being encrypted (16 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_encrypt", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_encrypt32(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] plaintext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext);
        [DllImport(dll64, EntryPoint = "LC_encrypt", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_encrypt64(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] plaintext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext);

        public static uint LC_encrypt(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] plaintext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext)
        {
            if (Is64())
            {
                return LCDefine.LC_encrypt64(handle, plaintext,ciphertext);
            }

            return LCDefine.LC_encrypt32(handle, plaintext,ciphertext);
        }


        // Decrypt data by AES algorithm
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter ciphertext[in]  Cipher text to be decrypted (16 bytes)
        // @parameter plaintext[out] Plain text after being decrypted (16 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_decrypt", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_decrypt32(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] plaintext);
        [DllImport(dll64, EntryPoint = "LC_decrypt", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_decrypt64(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] plaintext);

        public static uint LC_decrypt(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] ciphertext, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] plaintext)
        {
            if (Is64())
            {
                return LCDefine.LC_decrypt64(handle, ciphertext,plaintext);
            }

            return LCDefine.LC_decrypt32(handle, ciphertext,plaintext);
        }


        // Setting new password requires developer privileges.
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter flag [in]  Password Type(Admin 0, Generic 1, Authentication 2)
        // @parameter newpasswd[in]  Password(8 bytes)
        // @parameter retries  [in]  Error Count (1~15), -1 disables error count
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        // */
        [DllImport(dll32, EntryPoint = "LC_set_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_set_passwd32(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd, uint retries);
        [DllImport(dll64, EntryPoint = "LC_set_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_set_passwd64(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd, uint retries);

        public static uint LC_set_passwd(uint handle, uint flag, [In][MarshalAs(UnmanagedType.LPArray)] byte[] passwd, uint retries)
        {
            if (Is64())
            {
                return LC_set_passwd64(handle, flag, passwd, retries);
            }

            return LC_set_passwd32(handle, flag, passwd, retries);
        }


        // Change password
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter flag [in]  Password type (Authentication 2)
        // @parameter oldpasswd[in]  Old Password (8 bytes)
        // @parameter newpasswd[in]  New Password (8 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_change_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_change_passwd32(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] oldpasswd, [In][MarshalAs(UnmanagedType.LPArray)] byte[] newpasswd);
        [DllImport(dll64, EntryPoint = "LC_change_passwd", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_change_passwd64(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] oldpasswd, [In][MarshalAs(UnmanagedType.LPArray)] byte[] newpasswd);

        public static uint LC_change_passwd(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] oldpasswd, [In][MarshalAs(UnmanagedType.LPArray)] byte[] newpasswd)
        {
            if (Is64())
            {
                return LC_change_passwd64(handle, type, oldpasswd, newpasswd);
            }

            return LC_change_passwd32(handle, type, oldpasswd, newpasswd);
        }


        // Retrieve hardware information
        // 
        // @parameter handle[in]  Device handle opened
        // @parameter info [out] Retrieve hardware information
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_get_hardware_info", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_get_hardware_info32(uint handle, ref LC_hardware_info info);
        [DllImport(dll64, EntryPoint = "LC_get_hardware_info", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_get_hardware_info64(uint handle, ref LC_hardware_info info);

        public static uint LC_get_hardware_info(uint handle, ref LC_hardware_info info)
        {
            if (Is64())
            {
                return LC_get_hardware_info64(handle, ref info);
            }

            return LC_get_hardware_info32(handle, ref info);
        }


        // Retrieve software information
        // 
        // @parameter info [out] Software information
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_get_software_info", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_get_software_info32(ref LC_software_info info);
        [DllImport(dll64, EntryPoint = "LC_get_software_info", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_get_software_info64(ref LC_software_info info);

        public static uint LC_get_software_info(ref LC_software_info info)
        {
            if (Is64())
            {
                return LC_get_software_info64(ref info);
            }

            return LC_get_software_info32(ref info);
        }

        // Calculate hmac value by hardware

        // @parameter handle[in]  Device handle opened
        // @parameter text [in]  Data to be used in calculating hmac value
        // @parameter textlen  [in]  Data length (>=0)
        // @parameter digest[out] Hmac value (20 bytes)

        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_hmac", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_hmac32(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] digest);
        [DllImport(dll64, EntryPoint = "LC_hmac", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_hmac64(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] digest);

        public static uint LC_hmac(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] digest)
        {
            if (Is64())
            {
                return LCDefine.LC_hmac64(handle, text, textlen,digest);
            }

            return LCDefine.LC_hmac32(handle, text, textlen,digest);
        }


        // Calculate hmac value by software
        // 
        // @parameter text[in]  Data to be used in calculating hmac value
        // @parameter textlen[in]  Data length (>=0)
        // @parameter key[in]  key to be used in calculating hmac value(20 bytes)
        // @parameter digest  [out] hmac value(20 bytes)
        // 
        // @return value
        // Successful, 0 returned; failed, predefined error code returned

        [DllImport(dll32, EntryPoint = "LC_hmac_software", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_hmac_software32([In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] key, byte[] digest);
        [DllImport(dll64, EntryPoint = "LC_hmac_software", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_hmac_software64([In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] key, byte[] digest);

        public static uint LC_hmac_software([In][MarshalAs(UnmanagedType.LPArray)] byte[] text, uint textlen, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] key, byte[] digest)
        {
            if (Is64())
            {
                return LCDefine.LC_hmac_software64(text, textlen,key, digest);
            }

            return LCDefine.LC_hmac_software32(text, textlen,key, digest);
        }

        // Reset Remote Update Key and Authentication Key.
        // @parameters handle	[IN] Opened device handle
        // @parameters type	[IN] Password type (0=Remote Update Key, 1=Authentication Key)
        // @parameters key	[IN] Key (20 bytes)
        // @return value
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_set_key", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_set_key32(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key);
        [DllImport(dll64, EntryPoint = "LC_set_key", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_set_key64(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key);

        public static uint LC_set_key(uint handle, uint type, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key)
        {
            if (Is64())
            {
                return LC_set_key64(handle, type, key);
            }

            return LC_set_key32(handle, type, key);
        }

        // Update remotely.
        // @parameters handle	[IN] Opened device handle
        // @parameters buffer	[IN] Buffer area of remote updating package
        // Successful, 0 returned; failed, predefined error code returned
        [DllImport(dll32, EntryPoint = "LC_update", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_update32(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer);
        [DllImport(dll64, EntryPoint = "LC_update", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_update64(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer);

        public static uint LC_update(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer)
        {
            if (Is64())
            {
                return LC_update64(handle, buffer);
            }

            return LC_update32(handle, buffer);
        }

        // It requires Admin privileges.
        // Generate remote updating package.

        // @parameters serial	[IN] Serial number of updating dongle
        // @parameters block	[IN] Block number (1~3)
        // @parameters buffer	[IN] Updating content (Block in byte)
        // @parameters key	[IN] Remote updating key (in byte)
        // @parameters uptPkg	[OUT] Generated updating package (in byte)

        // Successful, 0 returned; failed, predefined error code returned

        [DllImport(dll32, EntryPoint = "LC_gen_update_pkg", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_gen_update_pkg32([In][MarshalAs(UnmanagedType.LPArray)] byte[] serial, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] uptPkg);
        [DllImport(dll64, EntryPoint = "LC_gen_update_pkg", CallingConvention = CallingConvention.StdCall)]
        public static extern uint LC_gen_update_pkg64([In][MarshalAs(UnmanagedType.LPArray)] byte[] serial, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] uptPkg);

        public static uint LC_gen_update_pkg(uint handle, [In][MarshalAs(UnmanagedType.LPArray)] byte[] serial, uint block, [In][MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [In][MarshalAs(UnmanagedType.LPArray)] byte[] key, [Out,MarshalAs(UnmanagedType.LPArray)] byte[] uptPkg)
        {
            if (Is64())
            {
                return LCDefine.LC_gen_update_pkg64(serial, block, buffer, key,uptPkg);
            }

            return LCDefine.LC_gen_update_pkg32(serial, block, buffer, key,uptPkg);
        }


        // Hardware information structure
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LC_hardware_info
        {
            public uint developerNumber;// Developer ID
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] serialNumber;
            // Unique Device Serial Number
            public uint setDate;// Manufacturing date
            public uint reservation;// Reserve

            public override string ToString()
            {
                string info = string.Format("developerNumber is{0}" + "\n" + "serialNumberis{1}" + "\n" + "setDate is {2}" + "\n" + "reservation is {3}", developerNumber,myConverter.Bytes2Str(serialNumber), setDate, reservation);
                return info;
            }
        }

        // Software information structure
        public struct LC_software_info
        {
            public uint version;// Software edition
            public uint reservation;// Reserve

            public override string ToString()
            {
                string info = string.Format("the version is {0}" + "\n" + "the reservation is {1}", version, reservation);
                return info;
            }
        }
    }
}