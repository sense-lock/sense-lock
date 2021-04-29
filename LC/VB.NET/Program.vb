Imports System.Runtime.InteropServices

Namespace SenseShield
    Module myConverter
        'Str2Bytes
        Public Function Str2Bytes(s As String)
            Return System.Text.Encoding.ASCII.GetBytes(s)
        End Function
        'Bytes2Str
        Public Function Bytes2Str(b As Byte())
            Return System.Text.Encoding.ASCII.GetString(b)
        End Function
        'PrintHex
        Public Function PrintHex(b As Byte())
            Dim s As String = BitConverter.ToString(b)
            Return s
        End Function
    End Module

    Class Program
        'print the output

        'WriteLineGreen
        Public Shared Sub WriteLineGreen(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub

        'WriteLineRed
        Public Shared Sub WriteLineRed(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub

        'WriteLineYellow
        Public Shared Sub WriteLineYellow(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub


        Public Shared Sub Main()
            Dim handle As UInteger
            Dim ret As UInteger = 0
            Dim msg As String = String.Empty

            'LC_open
            ret = LCDefine.LC_open(0, 0, handle)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_open Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_open Success,return code = {0}", ret)
				WriteLineGreen(msg)
            End If

            'LC_passwd
            ret = LCDefine.LC_passwd(handle, 0, Str2Bytes("12345678"))
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_passwd Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_passwd Success,return code = {0}", ret)
                WriteLineGreen(msg)
            End If

            'LC_set_passwd
            'set the user pin to "12345678"
            Dim retries As UInteger = 100
            ret = LCDefine.LC_set_passwd(handle, 1, Str2Bytes("12345678"), retries)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_set_passwd Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_set_passwd Success")
                WriteLineGreen(msg)
            End If

            'LC_read
            Dim outbuff As Byte() = New Byte(1023) {}
            ret = LCDefine.LC_read(handle, 0, outbuff)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_read Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_read Success")
                WriteLineGreen(msg)
                msg = String.Format("The output string is {0}", Bytes2Str(outbuff))
                WriteLineYellow(msg)
            End If

            'LC_write
            Dim inbuff As Byte() = Str2Bytes("This is a testing string for test the lc lock")
            ret = LCDefine.LC_write(handle, 1, inbuff)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_write Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_write Success")
                WriteLineGreen(msg)
            End If

            'LC_read
            ret = LCDefine.LC_read(handle, 1, outbuff)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_read Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_read Success")
                WriteLineGreen(msg)
                msg = String.Format("The output string is {0}", Bytes2Str(outbuff))
                WriteLineYellow(msg)
            End If

            'encrypt and decrypt
            Dim plaintext As Byte() = New Byte(15) {}
            Dim ciphertext As Byte() = New Byte(15) {}
            Dim finaltext As Byte() = New Byte(15) {}
            Array.Copy(Str2Bytes("Senselock LClock"), plaintext, 16)
            msg = PrintHex(plaintext)
            WriteLineYellow(msg)

            'encrypt and decrypt need the user privilege
            'LC_passwd
            ret = LCDefine.LC_passwd(handle, 1, Str2Bytes("12345678"))
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_passwd Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_passwd Success,return code = {0}", ret)
                WriteLineGreen(msg)
            End If

            'LC_encrypt
            ret = LCDefine.LC_encrypt(handle, plaintext, ciphertext)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_encrypt Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_encrypt Success")
                WriteLineGreen(msg)
                msg = PrintHex(ciphertext)
                WriteLineYellow(msg)
            End If

            'LC_decrypt
            ret = LCDefine.LC_decrypt(handle, ciphertext, finaltext)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_decrypt Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_decrypt Success")
                WriteLineGreen(msg)
                msg = PrintHex(finaltext)
                WriteLineYellow(msg)
                WriteLineYellow(Bytes2Str(finaltext))
            End If

            'set passwrod 

            'Dim passwd As Byte() = New Byte(7) {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
            'Dim retries As UInteger = 100
            'LC_set_passwd
            'ret = LCDefine.LC_set_passwd(handle,1,passwd,retries)
            'If (ret <> LCErrorCode.LC_SUCCESS) Then
            '    msg = string.format("LC_set_passwd Error,return code = {0}", ret)
            '    WriteLineRed(msg)
            'Else
            '    msg = string.format("LC_set_passwd Success")
            '    WriteLineGreen(msg)
            'End If
            'ret = LCDefine.LC_passwd(handle, 1, passwd)
            'If (ret <> LCErrorCode.LC_SUCCESS) Then
            '    msg = String.Format("LC_passwd Error,return code = {0}", ret)
            '    WriteLineRed(msg)
            'Else
            '    msg = String.Format("LC_passwd Success,return code = {0}", ret)
            '    WriteLineGreen(msg)
            'End If
            'todo :test the function LC_change_passwd

            'LC_get_hardware_info
            Dim hardwareInfo As LCDefine.LC_hardware_info
            ret = LCDefine.LC_get_hardware_info(handle, hardwareInfo)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_get_hardware_hardwareInfo Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_get_hardware_hardwareInfo Success")
                WriteLineGreen(msg)
                msg = hardwareInfo.ToString()
                WriteLineYellow(msg)
            End If

            'LC_get_software_info
            Dim softwareInfo As LCDefine.LC_software_info
            ret = LCDefine.LC_get_software_info(softwareInfo)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_get_software_info Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_get_software_info Success")
                WriteLineGreen(msg)
                msg = softwareInfo.ToString()
                WriteLineYellow(msg)
            End If

            'The functions ,LC_hmac and LC_hmac_software ,require the Authentication privilege
            'LC_passwd
            ret = LCDefine.LC_passwd(handle, 2, Str2Bytes("12345678"))
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_passwd Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_passwd Success,return code = {0}", ret)
                WriteLineGreen(msg)
            End If

            'LC_hmac
            Dim digest As Byte() = New Byte(1023) {}
            Dim hmacText As Byte() = Str2Bytes("Senselock")
            ret = LCDefine.LC_hmac(handle, hmacText, hmacText.Length, digest)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_hmac Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_hmac Success")
                WriteLineGreen(msg)
                msg = PrintHex(digest)
                WriteLineYellow(msg)
            End If

            'LC_hmac_software
            Dim key As Byte() = New Byte(19) {}
            Array.Copy(Str2Bytes("just for a key which should get 20 bytes"), key, 20)
            ret = LCDefine.LC_hmac_software(hmacText, hmacText.Length, key, digest)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_hmac_software Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_hmac_software Success")
                WriteLineGreen(msg)
                msg = PrintHex(digest)
                WriteLineYellow(msg)
            End If


            ret = LCDefine.LC_close(handle)
            If (ret <> LCErrorCode.LC_SUCCESS) Then
                msg = String.Format("LC_close Error,return code = {0}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("LC_close Success")
                WriteLineGreen(msg)
            End If


            Console.ReadLine()
        End Sub
    End Class
End Namespace