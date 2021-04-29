Imports System.Runtime.InteropServices
Imports System.Text

Public  Module MyConverter
    ''' <summary>
    ''' 由结构体转换为byte数组
    ''' </summary>
    Public Function StructureToByte(Of T)(ByVal [structure] As T) As Byte()
        Dim size = Marshal.SizeOf(GetType(T))
        Dim buffer = New Byte(size - 1) {}
        Dim bufferIntPtr = Marshal.AllocHGlobal(size)

        Try
            Marshal.StructureToPtr([structure], bufferIntPtr, True)
            Marshal.Copy(bufferIntPtr, buffer, 0, size)
        Finally
            Marshal.FreeHGlobal(bufferIntPtr)
        End Try

        Return buffer
    End Function

    ''' <summary>
    ''' 由byte数组转换为结构体
    ''' </summary>
    Public Function  ByteToStructure(Of T)(ByVal dataBuffer As Byte()) As T
        Dim [structure] As Object = Nothing
        Dim size = Marshal.SizeOf(GetType(T))
        Dim allocIntPtr = Marshal.AllocHGlobal(size)

        Try
            Marshal.Copy(dataBuffer, 0, allocIntPtr, size)
            [structure] = Marshal.PtrToStructure(allocIntPtr, GetType(T))
        Finally
            Marshal.FreeHGlobal(allocIntPtr)
        End Try

        Return [structure]
    End Function
End Module
Namespace SenseShield

    Class Program

        '打印方式定义
        Public Shared Sub WriteLineGreen(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub

        Public Shared Sub WriteLineRed(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub

        Public Shared Sub WriteLineYellow(ByVal s As String)
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine(s)
            Console.ResetColor()
        End Sub




        Public Shared Sub Main()
            Dim ret As Integer = 0
            Dim size As Integer
            Dim msg As String = String.Empty
            ret = Sense4.S4Enum(Nothing, size)
            If ret <> S4Define.S4_INSUFFICIENT_BUFFER Then
                msg = String.Format("Enum error ret value 0x{0:X8}", ret)
                WriteLineRed(msg)
            End If
            'msg = String.Format("now is 64?{0},the sizeof sense4_context is {1}", Sense4.Is64(), Marshal.SizeOf(New SENSE4_CONTEXT()))
            'WriteLineYellow(msg)
            Dim s4Context As SENSE4_CONTEXT() = New SENSE4_CONTEXT(size / Marshal.SizeOf(GetType(SENSE4_CONTEXT)) - 1) {}
            ret = Sense4.S4Enum(s4Context, size)
            If ret <> S4Define.S4_SUCCESS Then
                msg = String.Format("Enum error ret value 0x{0:X8}", ret)
                WriteLineRed(msg)
            Else
                msg = String.Format("Enum success! Has {0} lock(s)", size / Marshal.SizeOf(GetType(SENSE4_CONTEXT)))
                WriteLineGreen(msg)
            End If
            For Each s4Ctx In s4Context
                'you can use the function S4OpenEx or S4Open 
                'ret = Sense4.S4Open(s4Ctx)
                'If ret <> S4Define.S4_SUCCESS Then
                '    msg = String.Format("S4Open error ret value 0x{0:X8}", ret)
                '    WriteLineRed(msg)
                'Else
                '    msg = String.Format("S4Open success! ")
                '    WriteLineGreen(msg)
                'End If
                Dim s4Openinfo As S4OPENINFO
                s4Openinfo.dwS4OpenInfoSize = Marshal.SizeOf(s4Openinfo)
                s4Openinfo.dwShareMode = S4Define.S4_SHARE_MODE
                ret = Sense4.S4OpenEx(s4Ctx, s4Openinfo)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4OpenEx error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4OpenEx success! ")
                    WriteLineGreen(msg)
                End If

                'remake a new root dir ,erase the dir,the creat the root
                Dim devPin As Byte() = {&H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38, &H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38, &H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38}
                Dim oldUserPin As Byte() = {&H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38}
                Dim newUserPin As Byte() = {&H20, &H21, &H04, &H10, &H12, &H23, &H59, &HFF}


                ret = Sense4.S4VerifyPin(s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN)

                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4VerifyPin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4VerifyPin success! ")
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4ChangeDir(s4Ctx, "\")
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4ChangeDir error ret value {0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4ChangeDir success! ")
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4EraseDir(s4Ctx, Nothing)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4EraseDir error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4EraseDir success! ")
                    WriteLineGreen(msg)
                End If
                'ret = Sense4.S4CreateDir(s4Ctx, "\", 0, S4Define.S4_CREATE_ROOT_DIR)
                'If ret <> S4Define.S4_SUCCESS Then
                '    msg = String.Format("S4CreateDir error ret value 0x{0:X8}", ret)
                '    WriteLineRed(msg)
                'Else
                '    msg = String.Format("S4CreateDir success! ")
                '    WriteLineGreen(msg)
                'End If
                'msg = String.Format("now is 64?{0},the sizeof S4CREATEDIRINFO is {1}", Sense4.Is64(), Marshal.SizeOf(New S4CREATEDIRINFO()))
                'WriteLineYellow(msg)
                Dim s4Createdir As S4CREATEDIRINFO

                s4Createdir.dwS4CreateDirInfoSize = Marshal.SizeOf(s4Createdir)
                s4Createdir.szAtr = {&H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38}
                s4Createdir.NetConfig = New S4NETCONFIG()

                ret = Sense4.S4CreateDirEx(s4Ctx, "\", 0, S4Define.S4_CREATE_ROOT_DIR, s4Createdir)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4CreateDirEx error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4CreateDirEx success! ")
                    WriteLineGreen(msg)
                End If
                Dim inBuff(255) As Byte
                Dim inBufflen As Integer
                Dim outBuff(255) As Byte
                Dim outBufflen As Integer
                Dim CrtlReturned As Integer

                ' S4_LED_WINK  struct is 
                inBuff(0) = &H3
                inBuff(1) = 0
                inBuff(2) = 0
                inBuff(3) = 0

                inBufflen = inBuff.Length
                outBufflen = outBuff.Length


                ret = Sense4.S4Control(s4Ctx, S4Define.S4_LED_WINK, inBuff, inBufflen, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control led wink error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Control led wink success!  The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned))
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4Control(s4Ctx, S4Define.S4_LED_DOWN, inBuff, inBufflen, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control led S4_LED_DOWN error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Control led S4_LED_DOWN success!  The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned))
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4Control(s4Ctx, S4Define.S4_LED_UP, inBuff, inBufflen, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control led S4_LED_UP error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Control led S4_LED_UP success! The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned))
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4Control(s4Ctx, S4Define.S4_GET_DEVICE_TYPE, inBuff, inBufflen, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control S4_GET_DEVICE_TYPE error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Control S4_GET_DEVICE_TYPE success! The output value is {0} ", BitConverter.ToString(outBuff, 0, CrtlReturned))
                    WriteLineGreen(msg)
                End If

                Dim CustomerID(3) As Byte

                ret = Sense4.S4Control(s4Ctx, S4Define.S4_GET_DEVICE_USABLE_SPACE, Nothing, 0, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control S4_GET_DEVICE_USABLE_SPACE error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Control S4_GET_DEVICE_USABLE_SPACE success!  The output value is {0} ", outBuff(0) + outBuff(1) * 256)
                    WriteLineGreen(msg)
                End If

                ret = Sense4.S4Control(s4Ctx, S4Define.S4_GET_MANUFACTURE_DATE, inBuff, inBufflen, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control S4_GET_MANUFACTURE_DATE error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    Dim manufactureDate = MyConverter.ByteToStructure(Of S4_MANUFACTURE_DATE)(outBuff)
                    msg = String.Format("S4Control S4_GET_MANUFACTURE_DATE success!  The output value is {0} ", manufactureDate.ToString())
                    WriteLineGreen(msg)
                End If

                ret = Sense4.S4Control(s4Ctx, S4Define.S4_GET_CURRENT_TIME, Nothing, 0, outBuff, outBufflen, CrtlReturned)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Control S4_GET_DEVICE_TYPE error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    Dim lockTime = MyConverter.ByteToStructure(Of TM)(outBuff)
                    msg = String.Format("S4Control S4_GET_DEVICE_TYPE success!  The output value is {0} ",lockTime.ToString())
                    WriteLineGreen(msg)
                End If


                Dim lpszPath As String = New String("\")

                ret = Sense4.S4ChangeDir(s4Ctx, lpszPath)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4ChangeDir error ret value {0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4ChangeDir success! ")
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4VerifyPin(s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN)

                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4VerifyPin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4VerifyPin success! ")
                    WriteLineGreen(msg)
                End If

                '1970 is the size of Directory,which is a variable ,not a const
                Dim dirSize As UInteger = 1970
                Dim lpszDirID As String = "d001"
                ret = Sense4.S4CreateDir(s4Ctx, lpszDirID, dirSize, S4Define.S4_CREATE_SUB_DIR)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4CreateDir error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4CreateDir success! ")
                    WriteLineGreen(msg)
                End If

                lpszPath = "d001"

                ret = Sense4.S4ChangeDir(s4Ctx, lpszPath)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4ChangeDir error ret value {0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4ChangeDir success! ")
                    WriteLineGreen(msg)
                End If

                ret = Sense4.S4VerifyPin(s4Ctx, devPin, devPin.Length, S4Define.S4_DEV_PIN)

                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4VerifyPin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4VerifyPin success! ")
                    WriteLineGreen(msg)
                End If
                'you must change into the target dir before erase it
                ret = Sense4.S4EraseDir(s4Ctx, Nothing)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4EraseDir error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4EraseDir success! ")
                    WriteLineGreen(msg)
                End If

                lpszPath = "\"

                ret = Sense4.S4ChangeDir(s4Ctx, lpszPath)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4ChangeDir error ret value {0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4ChangeDir success! ")
                    WriteLineGreen(msg)
                End If
                Dim fileID As String = "0001"
                Dim lpszPCFilePath As String = "CheckTime.hex"
                Dim pdwFileSize As UInteger = 0
                Dim dwFlags As UInteger = S4Define.S4_CREATE_NEW
                Dim dwFileType As UInteger = S4Define.S4_HEX_FILE
                Dim pdwBytesWritten As UInteger = Nothing
                ret = sense4.PS4WriteFile(s4Ctx, fileID, lpszPCFilePath, pdwFileSize, S4Define.S4_CREATE_NEW, dwFileType, pdwBytesWritten)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("PS4WriteFile error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("PS4WriteFile success! ")
                    WriteLineGreen(msg)
                End If
                'fileID = "0002"
                Dim returnLen As UInteger
                'Dim pBuffer As Byte() = {&H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38, &H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38}

                'Dim realSize As UInteger = Nothing
                'ret = Sense4.S4WriteFile(s4Ctx, fileID, 0, pBuffer, pBuffer.Length, pBuffer.Length, realSize, S4Define.S4_CREATE_NEW, S4Define.S4_EXE_FILE)
                'If ret <> S4Define.S4_SUCCESS Then
                '    msg = String.Format("S4WriteFile error ret value 0x{0:X8}", ret)
                '    WriteLineRed(msg)
                'Else
                '    msg = String.Format("S4WriteFile success! ")
                '    WriteLineGreen(msg)
                'End If
                ret = Sense4.S4ChangePin(s4Ctx, oldUserPin, oldUserPin.Length, newUserPin, newUserPin.Length, S4Define.S4_USER_PIN)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4ChangePin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4ChangePin success! ")
                    WriteLineGreen(msg)
                End If
                'verify the old pin, there must to return the wrong code
                ret = Sense4.S4VerifyPin(s4Ctx, oldUserPin, oldUserPin.Length, S4Define.S4_USER_PIN)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4VerifyPin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4VerifyPin success! ")
                    WriteLineGreen(msg)
                End If


                inBufflen = 10
                ret = Sense4.S4Execute(s4Ctx, fileID, inBuff, inBufflen, outBuff, outBufflen, returnLen)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Execute error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Execute success! {0}", BitConverter.ToString(outBuff,0,returnLen))
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4VerifyPin(s4Ctx, newUserPin, newUserPin.Length, S4Define.S4_USER_PIN)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4VerifyPin error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4VerifyPin success! ")
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4ExecuteEx(s4Ctx, fileID, S4Define.S4_VM_EXE, inBuff, inBufflen, outBuff, outBufflen, returnLen)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Execute error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Execute success! {0}", BitConverter.ToString(outBuff,0,returnLen))
                    WriteLineGreen(msg)
                End If
                ret = Sense4.S4Close(s4Ctx)
                If ret <> S4Define.S4_SUCCESS Then
                    msg = String.Format("S4Close error ret value 0x{0:X8}", ret)
                    WriteLineRed(msg)
                Else
                    msg = String.Format("S4Close success! ")
                    WriteLineGreen(msg)
                End If

            Next



            Console.Read()
        End Sub

    End Class

End Namespace