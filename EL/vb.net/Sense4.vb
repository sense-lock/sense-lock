Imports System.Data.SqlTypes
Imports System.Runtime.InteropServices
Imports DWORD = System.UInt16
Namespace SenseShield

    Public Class Sense4
        Public Shared Function Is64() As Boolean

            If IntPtr.Size = 8 Then
                Return True
            End If
            Return False
        End Function


        Private Const dllName32 As String = "/dll/x86/sense4.dll"
        Private Const dllName64 As String = "/dll/x64/sense4.dll"

        <DllImport(dllName32, EntryPoint:="S4Enum",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Enum32(
            <MarshalAs(UnmanagedType.LPArray), Out> ByVal s4Constext As SENSE4_CONTEXT(),
            ByRef size As UInteger) As UInteger
        End Function
        <DllImport(dllName64, EntryPoint:="S4Enum",
           CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Enum64(
            <MarshalAs(UnmanagedType.LPArray), Out> ByVal s4Constext As SENSE4_CONTEXT(),
            ByRef size As UInteger) As UInteger
        End Function
        Friend Shared Function S4Enum(
            <MarshalAs(UnmanagedType.LPArray), Out> ByVal s4Constext As SENSE4_CONTEXT(),
            ByRef size As UInteger) As UInteger
            If Is64() Then
                Return S4Enum64(s4Constext, size)
            End If
            Return S4Enum32(s4Constext, size)
        End Function

        <DllImport(dllName32, EntryPoint:="S4Open",
           CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Open32(
            ByRef s4Constext As SENSE4_CONTEXT) As UInteger
        End Function
        <DllImport(dllName64, EntryPoint:="S4Open",
           CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Open64(
            ByRef s4Constext As SENSE4_CONTEXT) As UInteger
        End Function
        Friend Shared Function S4Open(
            ByRef s4Constext As SENSE4_CONTEXT) As UInteger
            If Is64() Then
                Return S4Open64(s4Constext)
            End If
            Return S4Open32(s4Constext)
        End Function

        <DllImport(dllName32, EntryPoint:="S4OpenEx",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4OpenEx32(
      ByRef s4Constext As SENSE4_CONTEXT,
      ByRef s4Openinfo As S4OPENINFO) As UInteger
        End Function
        <DllImport(dllName64, EntryPoint:="S4OpenEx",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4OpenEx64(
      ByRef s4Constext As SENSE4_CONTEXT,
      ByRef s4Openinfo As S4OPENINFO) As UInteger
        End Function
        Friend Shared Function S4OpenEx(
    ByRef s4Constext As SENSE4_CONTEXT,
    ByRef s4Openinfo As S4OPENINFO) As UInteger
            If Is64() Then
                Return S4OpenEx64(s4Constext, s4Openinfo)
            End If
            Return S4OpenEx32(s4Constext,s4Openinfo)
        End Function


        <DllImport(dllName32, EntryPoint:="S4Close",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Close32(
       ByRef s4Constext As SENSE4_CONTEXT) As UInteger
        End Function
        <DllImport(dllName64, EntryPoint:="S4Close",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Close64(
       ByRef s4Constext As SENSE4_CONTEXT) As UInteger
        End Function
        Friend Shared Function S4Close(
     ByRef s4Constext As SENSE4_CONTEXT) As UInteger
            If Is64() Then
                Return S4Close64(s4Constext)
            End If
            Return S4Close32(s4Constext)
        End Function

        <DllImport(dllName32, EntryPoint:="S4Control",
           CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Control32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal ctlCode As UInteger,
            ByVal inBuff As Byte(),
            ByVal inBuffLen As UInteger,
            <Out, MarshalAs(UnmanagedType.LPArray)> ByVal outBuff As Byte(),
            ByVal outBuffLen As UInteger,
            ByRef BytesReturned As UInteger) As UInteger
        End Function
        <DllImport(dllName64, EntryPoint:="S4Control",
           CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Control64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal ctlCode As UInteger,
            <[In], MarshalAs(UnmanagedType.LPArray)> ByVal inBuff As Byte(),
            ByVal inBuffLen As UInteger,
            <[Out], MarshalAs(UnmanagedType.LPArray)> ByVal outBuff As Byte(),
            ByVal outBuffLen As UInteger,
            ByRef BytesReturned As UInteger) As UInteger
        End Function
        Friend Shared Function S4Control(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal ctlCode As UInteger,
            ByVal inBuff As Byte(),
            ByVal inBuffLen As UInteger,
            ByVal outBuff As Byte(),
            ByVal outBuffLen As UInteger,
            ByRef BytesReturned As UInteger) As UInteger
            If Is64() Then
                Return S4Control64(s4Ctx, ctlCode, inBuff, inBuffLen, outBuff, outBuffLen, BytesReturned)
            End If
            Return S4Control32(s4Ctx, ctlCode, inBuff, inBuffLen, outBuff, outBuffLen, BytesReturned)
        End Function


        <DllImport(dllName64, EntryPoint:="S4ChangeDir",
            CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ChangeDir64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszPath As String) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4ChangeDir",
            CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ChangeDir32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszPath As String) As UInteger
        End Function
        Friend Shared Function S4ChangeDir(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal lpszPath As String) As UInteger
            If Is64() Then
                Return S4ChangeDir64(s4Ctx, lpszPath)
            End If
            Return S4ChangeDir32(s4Ctx, lpszPath)
        End Function

        <DllImport(dllName64, EntryPoint:="S4CreateDir",
            CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4CreateDir64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszDirID As String,
            ByVal dwDirSize As UInteger,
            ByVal dwFlags As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4CreateDir",
            CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4CreateDir32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszDirID As String,
            ByVal dwDirSize As UInteger,
            ByVal dwFlags As UInteger) As UInteger
        End Function
        Friend Shared Function S4CreateDir(
           ByRef s4Ctx As SENSE4_CONTEXT,
           ByVal lpszDirID As String,
           ByVal dwDirSize As UInteger,
           ByVal dwFlags As UInteger) As UInteger
            If Is64() Then
                Return S4CreateDir64(s4Ctx, lpszDirID, dwDirSize, dwFlags)
            End If
            Return S4CreateDir32(s4Ctx, lpszDirID, dwDirSize, dwFlags)
        End Function

        <DllImport(dllName64, EntryPoint:="S4CreateDirEx",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4CreateDirEx64(
           ByRef s4Ctx As SENSE4_CONTEXT,
           <[In], MarshalAs(UnmanagedType.LPStr)>
           ByVal lpszDirID As String,
           ByVal dwDirSize As UInteger,
           ByVal dwFlags As UInteger,
           ByRef s4Createdir As S4CREATEDIRINFO) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4CreateDirEx",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4CreateDirEx32(
           ByRef s4Ctx As SENSE4_CONTEXT,
           <[In], MarshalAs(UnmanagedType.LPStr)>
           ByVal lpszDirID As String,
           ByVal dwDirSize As UInteger,
           ByVal dwFlags As UInteger,
           ByRef s4Createdir As S4CREATEDIRINFO) As UInteger
        End Function
        Friend Shared Function S4CreateDirEx(
         ByRef s4Ctx As SENSE4_CONTEXT,
         ByVal lpszDirID As String,
         ByVal dwDirSize As UInteger,
         ByVal dwFlags As UInteger,
         ByVal s4Createdir As S4CREATEDIRINFO) As UInteger
            If Is64() Then
                Return S4CreateDirEx64(s4Ctx, lpszDirID, dwDirSize, dwFlags, s4Createdir)
            End If
            Return S4CreateDirEx32(s4Ctx, lpszDirID, dwDirSize, dwFlags, s4Createdir)
        End Function

        <DllImport(dllName64, EntryPoint:="S4EraseDir",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4EraseDir64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszDirID As String) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4EraseDir",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4EraseDir32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszDirID As String) As UInteger
        End Function
        Friend Shared Function S4EraseDir(
          ByRef s4Ctx As SENSE4_CONTEXT,
          ByVal lpszDirID As String) As UInteger
            If Is64() Then
                Return S4EraseDir64(s4Ctx, lpszDirID)
            End If
            Return S4EraseDir32(s4Ctx, lpszDirID)
        End Function

        'To be safer,the Pin is must to be the byte()
        <DllImport(dllName64, EntryPoint:="S4VerifyPin",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4VerifyPin64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPArray)>
            ByVal pbPin As Byte(),
            ByVal dwPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4VerifyPin",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4VerifyPin32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPArray)>
            ByVal pbPin As Byte(),
            ByVal dwPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
        End Function
        Friend Shared Function S4VerifyPin(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal pbPin As Byte(),
            ByVal dwPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
            If Is64() Then
                Return S4VerifyPin64(s4Ctx, pbPin, dwPinLen, dwPinType)
            End If
            Return S4VerifyPin32(s4Ctx, pbPin, dwPinLen, dwPinType)
        End Function


        <DllImport(dllName64, EntryPoint:="S4ChangePin",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ChangePin64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal pbOldPin As Byte(),
            ByVal dwOldPinLen As UInteger,
            ByVal pbNewPin As Byte(),
            ByVal dwNewPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4ChangePin",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ChangePin32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal pbOldPin As Byte(),
            ByVal dwOldPinLen As UInteger,
            ByVal pbNewPin As Byte(),
            ByVal dwNewPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
        End Function
        Friend Shared Function S4ChangePin(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal pbOldPin As Byte(),
            ByVal dwOldPinLen As UInteger,
            ByVal pbNewPin As Byte(),
            ByVal dwNewPinLen As UInteger,
            ByVal dwPinType As UInteger) As UInteger
            If Is64() Then
                Return S4ChangePin64(s4Ctx, pbOldPin, dwOldPinLen, pbNewPin, dwNewPinLen, dwPinType)
            End If
            Return S4ChangePin32(s4Ctx, pbOldPin, dwOldPinLen, pbNewPin, dwNewPinLen, dwPinType)
        End Function
        
        <DllImport(dllName64, EntryPoint:="S4WriteFile",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4WriteFile64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            ByVal dwOffset As UInteger,
            ByVal pBuffer As Byte(),
            ByVal dwBufferSize As UInteger,
            ByVal dwFileSize As UInteger,
            ByRef pdwBytesWritten As UInteger,
            ByVal dwFlags As UInteger, ByVal bFileType As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4WriteFile",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4WriteFile32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            ByVal dwOffset As UInteger,
            ByVal pBuffer As Byte(),
            ByVal dwBufferSize As UInteger,
            ByVal dwFileSize As UInteger,
            ByRef pdwBytesWritten As UInteger,
            ByVal dwFlags As UInteger, ByVal bFileType As UInteger) As UInteger
        End Function
        Friend Shared Function S4WriteFile(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal lpszFileID As String,
            ByVal dwOffset As UInteger,
            ByVal pBuffer As Byte(),
            ByVal dwBufferSize As UInteger,
            ByVal dwFileSize As UInteger,
            ByRef pdwBytesWritten As UInteger,
            ByVal dwFlags As UInteger, ByVal bFileType As UInteger) As UInteger
            If Is64() Then
                Return S4WriteFile64(s4Ctx, lpszFileID, dwOffset, pBuffer, dwBufferSize, dwFileSize, pdwBytesWritten, dwFlags, bFileType)
            End If
            Return S4WriteFile32(s4Ctx, lpszFileID, dwOffset, pBuffer, dwBufferSize, dwFileSize, pdwBytesWritten, dwFlags, bFileType)
        End Function

        <DllImport(dllName64, EntryPoint:="PS4WriteFile",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function PS4WriteFile64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
                <[In], MarshalAs(UnmanagedType.LPStr)>
                ByVal lpszPCFilePath As String,
            ByRef pdwFileSize As UInteger,
            ByVal dwFlags As UInteger,
            ByVal dwFileType As UInteger,
            ByRef pdwBytesWritten As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="PS4WriteFile",
                   CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function PS4WriteFile32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszPCFilePath As String,
            ByRef pdwFileSize As UInteger,
            ByVal dwFlags As UInteger,
            ByVal dwFileType As UInteger,
            ByRef pdwBytesWritten As UInteger) As UInteger
        End Function
        Friend Shared Function PS4WriteFile(
          ByRef s4Ctx As SENSE4_CONTEXT,
          <[In], MarshalAs(UnmanagedType.LPStr)>
          ByVal lpszFileID As String,
          <[In], MarshalAs(UnmanagedType.LPStr)>
          ByVal lpszPCFilePath As String,
          ByRef  pdwFileSize As UInteger,
          ByVal dwFlags As UInteger,
          ByVal dwFileType As UInteger,
          ByRef pdwBytesWritten As UInteger) As UInteger
            If Is64() Then
                Return PS4WriteFile64(s4Ctx, lpszFileID, lpszPCFilePath, pdwFileSize, dwFlags, dwFileType, pdwBytesWritten)
            End If
                Return PS4WriteFile32(s4Ctx, lpszFileID, lpszPCFilePath, pdwFileSize, dwFlags, dwFileType, pdwBytesWritten)
        End Function

        <DllImport(dllName64, EntryPoint:="S4Execute", CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Execute64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            <[In], MarshalAs(UnmanagedType.LPArray)> ByVal pInBuff As Byte(),
            ByVal dwInbufferSize As UInteger,
            <Out, MarshalAs(UnmanagedType.LPArray)> ByVal pOutBuffer As Byte(),
            ByVal dwOutBufferSize As UInteger,
            ByRef pdwBytesReturned As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4Execute", CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4Execute32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            <[In], MarshalAs(UnmanagedType.LPArray)> ByVal pInBuff As Byte(),
            ByVal dwInbufferSize As UInteger,
            <Out, MarshalAs(UnmanagedType.LPArray)> ByVal pOutBuffer As Byte(),
            ByVal dwOutBufferSize As UInteger,
            ByRef pdwBytesReturned As UInteger) As UInteger
        End Function
        Friend Shared Function S4Execute(
            ByRef s4Ctx As SENSE4_CONTEXT,
            ByVal lpszFileID As String,
            ByVal pInBuff As Byte(),
            ByVal dwInbufferSize As UInteger,
            ByVal pOutBuffer As Byte(),
            ByVal dwOutBufferSize As UInteger,
            ByRef pdwBytesReturned As UInteger) As UInteger
            If Is64() Then
                Return S4Execute64(s4Ctx, lpszFileID, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, pdwBytesReturned)
            End If
            Return S4Execute32(s4Ctx, lpszFileID, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, pdwBytesReturned)

        End Function

        <DllImport(dllName64, EntryPoint:="S4ExecuteEx", CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ExecuteEx64(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            ByVal dwFlag As UInteger,
            <[In], MarshalAs(UnmanagedType.LPArray)> ByVal pInBuff As Byte(),
            ByVal dwInbufferSize As UInteger,
            <Out, MarshalAs(UnmanagedType.LPArray)> ByVal pOutBuffer As Byte(),
            ByVal dwOutBufferSize As UInteger,
            ByRef pdwBytesReturned As UInteger) As UInteger
        End Function
        <DllImport(dllName32, EntryPoint:="S4ExecuteEx", CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function S4ExecuteEx32(
            ByRef s4Ctx As SENSE4_CONTEXT,
            <[In], MarshalAs(UnmanagedType.LPStr)>
            ByVal lpszFileID As String,
            ByVal dwFlag As UInteger,
            <[In], MarshalAs(UnmanagedType.LPArray)> ByVal pInBuff As Byte(),
            ByVal dwInbufferSize As UInteger,
            <Out, MarshalAs(UnmanagedType.LPArray)> ByVal pOutBuffer As Byte(),
            ByVal dwOutBufferSize As UInteger,
            ByRef pdwBytesReturned As UInteger) As UInteger
        End Function
        Friend Shared Function S4ExecuteEx(
          ByRef s4Ctx As SENSE4_CONTEXT,
          ByVal lpszFileID As String,
            ByVal dwFlag As UInteger,
          ByVal pInBuff As Byte(),
          ByVal dwInbufferSize As UInteger,
          ByVal pOutBuffer As Byte(),
          ByVal dwOutBufferSize As UInteger,
          ByRef pdwBytesReturned As UInteger) As UInteger
            If Is64() Then
                Return S4ExecuteEx64(s4Ctx, lpszFileID,dwFlag, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, pdwBytesReturned)
            End If
            Return S4ExecuteEx32(s4Ctx, lpszFileID,dwFlag, pInBuff, dwInbufferSize, pOutBuffer, dwOutBufferSize, pdwBytesReturned)

        End Function


    End Class

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure SENSE4_CONTEXT
        Public dwIndex As UInteger       'device index
        Public dwVersion As UInteger     'version		
        Public hLock As UIntPtr         'device handle 64 bit is Uint64,32bit is Uint32

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)>
        Public reserve As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=56)>
        Public bAtr As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Public bID As Byte()
        Public dwAtrLen As UInteger
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure EFINFO
        Public EfID As UShort
        Public EfType As Byte
        Public EfSize As UShort
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure S4_MANUFACTURE_DATE
        Public wYear As UShort
        Public byMonth As Byte
        Public byDay As Byte
        Public Overrides Function ToString() As String
            Dim thisString = string.Format("The manufacture time is {0}-{1}-{2}",wYear,byMonth,byDay)
            return thisString
        End Function
    End Structure

    '<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure TM
        Public tm_sec As UInteger
        Public tm_min As UInteger
        Public tm_hour As UInteger
        Public tm_mday As UInteger
        Public tm_mon As UInteger
        Public tm_year As UInteger
        Public tm_wday As UInteger
        Public tm_yday As UInteger
        Public tm_isdst As UInteger
        Public Overrides Function ToString() As String
            Dim tmString = string.Format("locktime:{0}-{1}-{2}  {3}:{4}:{5} ,which is the {6} day since Sunday, and the {7} day science January 1 ",tm_year+1900,tm_mon+1,tm_mday,tm_hour,tm_min,tm_sec,tm_wday,tm_yday)
            Return tmString
        End Function
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure S4OPENINFO
        Public dwS4OpenInfoSize As UInteger
        Public dwShareMode As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure S4CREATEDIRINFO
        Shared dwS4CreateDirInfoSize As UInteger
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Public szAtr As Byte()
        Public NetConfig As S4NETCONFIG
    End Structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure S4NETCONFIG
        Dim dwLicenseMode As UInteger
        Dim dwModuleCount As UInteger
        <MarshalAs(unmanagedType.ByValArray, sizeconst:=16)>
        Dim ModuleInfo As Byte()
    End Structure

End Namespace

