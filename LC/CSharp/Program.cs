using System;


namespace SenseShield
{
    static class myConverter
    {
        // Str2Bytes
        public static byte[] Str2Bytes(string s)
        {
            return System.Text.Encoding.ASCII.GetBytes(s);
        }
        // Bytes2Str
        public static string Bytes2Str(byte[] b)
        {
            return System.Text.Encoding.ASCII.GetString(b);
        }
        // PrintHex
        public static string PrintHex(byte[] b)
        {
            string s = BitConverter.ToString(b);
            return s;
        }
    }

    class Program
    {
        // print the output

        // WriteLineGreen
        public static void WriteLineGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        // WriteLineRed
        public static void WriteLineRed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        // WriteLineYellow
        public static void WriteLineYellow(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void Main()
        {
            var handle = default(uint);
            uint ret = 0U;
            string msg = string.Empty;

            // LC_open
            ret = LCDefine.LC_open(0U, 0U, ref handle);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_open Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_open Success,return code = {0}", ret);
                WriteLineGreen(msg);
            }

            // LC_passwd
            ret = LCDefine.LC_passwd(handle, 0U, (byte[])myConverter.Str2Bytes("12345678"));
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_passwd Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_passwd Success,return code = {0}", ret);
                WriteLineGreen(msg);
            }

            // LC_set_passwd
            // set the user pin to "12345678"
            uint retries = 100U;
            ret = LCDefine.LC_set_passwd(handle, 1U, (byte[])myConverter.Str2Bytes("12345678"), retries);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_set_passwd Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_set_passwd Success");
                WriteLineGreen(msg);
            }

            // LC_read
            byte[] outbuff = new byte[1024];
            ret = LCDefine.LC_read(handle, 0U,outbuff);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_read Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_read Success");
                WriteLineGreen(msg);
                msg = string.Format("The output string is {0}", myConverter.Bytes2Str(outbuff));
                WriteLineYellow(msg);
            }

            // LC_write
            byte[] inbuff = (byte[])myConverter.Str2Bytes("This is a testing string for test the lc lock");
            ret = LCDefine.LC_write(handle, 1U, inbuff);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_write Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_write Success");
                WriteLineGreen(msg);
            }

            // LC_read
            ret = LCDefine.LC_read(handle, 1U,outbuff);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_read Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_read Success");
                WriteLineGreen(msg);
                msg = string.Format("The output string is {0}", myConverter.Bytes2Str(outbuff));
                WriteLineYellow(msg);
            }

            // encrypt and decrypt
            var plaintext = new byte[16];
            var ciphertext = new byte[16];
            var finaltext = new byte[16];
            Array.Copy(myConverter.Str2Bytes("Senselock LClock"), plaintext, 16);
            msg = myConverter.PrintHex(plaintext);
            WriteLineYellow(msg);

            // encrypt and decrypt need the user privilege
            // LC_passwd
            ret = LCDefine.LC_passwd(handle, 1U, (byte[])myConverter.Str2Bytes("12345678"));
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_passwd Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_passwd Success,return code = {0}", ret);
                WriteLineGreen(msg);
            }

            // LC_encrypt
            ret = LCDefine.LC_encrypt(handle, plaintext,ciphertext);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_encrypt Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_encrypt Success");
                WriteLineGreen(msg);
                msg = myConverter.PrintHex(ciphertext);
                WriteLineYellow(msg);
            }

            // LC_decrypt
            ret = LCDefine.LC_decrypt(handle, ciphertext, finaltext);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_decrypt Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_decrypt Success");
                WriteLineGreen(msg);
                msg = myConverter.PrintHex(finaltext);
                WriteLineYellow(msg);
                WriteLineYellow(myConverter.Bytes2Str(finaltext));
            }

            // set passwrod 

            // Dim passwd As Byte() = New Byte(7) {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
            // Dim retries As UInteger = 100
            // LC_set_passwd
            // ret = LCDefine.LC_set_passwd(handle,1,passwd,retries)
            // If (ret <> LCErrorCode.LC_SUCCESS) Then
            // msg = string.format("LC_set_passwd Error,return code = {0}", ret)
            // WriteLineRed(msg)
            // Else
            // msg = string.format("LC_set_passwd Success")
            // WriteLineGreen(msg)
            // End If
            // ret = LCDefine.LC_passwd(handle, 1, passwd)
            // If (ret <> LCErrorCode.LC_SUCCESS) Then
            // msg = String.Format("LC_passwd Error,return code = {0}", ret)
            // WriteLineRed(msg)
            // Else
            // msg = String.Format("LC_passwd Success,return code = {0}", ret)
            // WriteLineGreen(msg)
            // End If
            // todo :test the function LC_change_passwd

            // LC_get_hardware_info
            var hardwareInfo = default(LCDefine.LC_hardware_info);
            ret = LCDefine.LC_get_hardware_info(handle, ref hardwareInfo);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_get_hardware_hardwareInfo Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_get_hardware_hardwareInfo Success");
                WriteLineGreen(msg);
                msg = hardwareInfo.ToString();
                WriteLineYellow(msg);
            }

            // LC_get_software_info
            var softwareInfo = default(LCDefine.LC_software_info);
            ret = LCDefine.LC_get_software_info(ref softwareInfo);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_get_software_info Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_get_software_info Success");
                WriteLineGreen(msg);
                msg = softwareInfo.ToString();
                WriteLineYellow(msg);
            }

            // The functions ,LC_hmac and LC_hmac_software ,require the Authentication privilege
            // LC_passwd
            ret = LCDefine.LC_passwd(handle, 2U, (byte[])myConverter.Str2Bytes("12345678"));
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_passwd Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_passwd Success,return code = {0}", ret);
                WriteLineGreen(msg);
            }

            // LC_hmac
            var digest = new byte[1024];
            byte[] hmacText = (byte[])myConverter.Str2Bytes("Senselock");
            ret = LCDefine.LC_hmac(handle, hmacText, (uint)hmacText.Length,digest);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_hmac Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_hmac Success");
                WriteLineGreen(msg);
                msg = myConverter.PrintHex(digest);
                WriteLineYellow(msg);
            }

            // LC_hmac_software
            var key = new byte[20];
            Array.Copy(myConverter.Str2Bytes("just for a key which should get 20 bytes"), key, 20);
            ret = LCDefine.LC_hmac_software(hmacText, (uint)hmacText.Length,key, digest);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_hmac_software Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_hmac_software Success");
                WriteLineGreen(msg);
                msg = myConverter.PrintHex(digest);
                WriteLineYellow(msg);
            }

            ret = LCDefine.LC_close(handle);
            if (ret != (long)LCErrorCode.LC_SUCCESS)
            {
                msg = string.Format("LC_close Error,return code = {0}", ret);
                WriteLineRed(msg);
            }
            else
            {
                msg = string.Format("LC_close Success");
                WriteLineGreen(msg);
            }

            Console.ReadLine();
        }
    }
}