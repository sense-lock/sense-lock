Imports System.Runtime.InteropServices

Namespace SenseShield
    Public Class LCDefine
        Public Shared Function Is64() As Boolean

            If IntPtr.Size = 8 Then
                Return True
            End If
            Return False
        End Function

        Public Const dll32 As String = "./dll/x86/Sense_LC.dll"
        Public Const dll64 As String = "./dll/x64/Sense_LC.dll"

'LE API function interface

'Open matching device according to Developer ID and Index
'
'@parameter vendor[in]  Developer ID (0=All)
'@parameter index[in]  Device Index (0=1st, and so on)
'@parameter handle[out] Device handle returned
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_open", CallingConvention := CallingConvention.StdCall)>
        Friend Shared Function LC_open32(vendor As UInteger, index As UInteger, ByRef handle As UInteger) _
            As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_open", CallingConvention := CallingConvention.StdCall)>
        Friend Shared Function LC_open64(vendor As UInteger, index As UInteger, ByRef handle As UInteger) _
            As UInteger
        End Function

        Friend Shared Function LC_open(vendor As UInteger, index As UInteger, ByRef handle As UInteger) _
            As UInteger
            If Is64() Then
                Return LC_open64(vendor, index, handle)
            End If
            Return LC_open32(vendor, index, handle)
        End Function


'Close an open device
'
'@parameter handle[in]  Device handle opened
'
'@return value
'Successful, 0 returned; failed, predefined error code returned


        <DllImport(dll32, EntryPoint := "LC_close", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_close32(handle As UInteger) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_close", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_close64(handle As UInteger) As UInteger
        End Function

        Public Shared Function LC_close(handle As UInteger) As UInteger
            If Is64() Then
                Return LC_close64(handle)
            End If
            Return LC_close32(handle)
        End Function


'
'
'@parameter handle[in]  Device handle opened
'@parameter flag [in]  Password Type(Admin 0, Generic 1, Authentication 2)
'@parameter passwd[in]  Password(8 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_passwd32(handle As UInteger, flag As UInteger,
                                           <[In], MarshalAs(UnmanagedType.LPArray)> passwd As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_passwd64(handle As UInteger, flag As UInteger,
                                           <[In], MarshalAs(UnmanagedType.LPArray)> passwd As Byte()) As UInteger
        End Function

        Public Shared Function LC_passwd(handle As UInteger,
                                         flag As UInteger,
                                         <[In], MarshalAs(UnmanagedType.LPArray)>
                                         passwd As Byte()) As UInteger
            If Is64() Then
                Return LC_passwd64(handle, flag, passwd)
            End If
            Return LC_passwd32(handle, flag, passwd)
        End Function


'
'
'@parameter handle[in]  Device handle opened
'@parameter block[in]  Number of block to be read
'@parameter buffer[out] Read data buffer (greater than 512 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_read", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_read32(handle As UInteger, block As UInteger,
                                         <Out, MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_read", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_read64(handle As UInteger, block As UInteger,
                                         <Out, MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        Public Shared Function LC_read(handle As UInteger, block As UInteger,
                                       <Out, MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
            If Is64() Then
                Return LC_read64(handle, block, buffer)
            End If
            Return LC_read32(handle, block, buffer)
        End Function

'Write data to specified block
'
'@parameter handle[in]  Device handle opened
'@parameter block[in]  Number of block to be written
'@parameter buffer[in]  Write data buffer (greater than 512 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned

        <DllImport(dll32, EntryPoint := "LC_write", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_write32(handle As UInteger, block As UInteger,
                                          <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_write", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_write64(handle As UInteger, block As UInteger,
                                          <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        Public Shared Function LC_write(handle As UInteger, block As UInteger,
                                        <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
            If Is64() Then
                Return LC_write64(handle, block, buffer)
            End If
            Return LC_write32(handle, block, buffer)
        End Function


' Encrypt data by AES algorithm
'
'@parameter handle[in]  Device handle opened
'@parameter plaintext[in]  Plain text to be encrypted (16 bytes)
'@parameter ciphertext[out] Cipher text after being encrypted (16 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_encrypt", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_encrypt32(handle As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)> plaintext As Byte(),
                                            <[Out], MarshalAs(UnmanagedType.LPArray)> ciphertext As Byte()) _
            As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_encrypt", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_encrypt64(handle As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)> plaintext As Byte(),
                                            <[Out], MarshalAs(UnmanagedType.LPArray)> ciphertext As Byte()) _
            As UInteger
        End Function

        Public Shared Function LC_encrypt(handle As UInteger,
                                          <[In], MarshalAs(UnmanagedType.LPArray)>
                                          plaintext As Byte(),
                                          <[Out], MarshalAs(UnmanagedType.LPArray)>
                                          ciphertext As Byte()) As UInteger
            If Is64() Then
                Return LC_encrypt64(handle, plaintext, ciphertext)
            End If
            Return LC_encrypt32(handle, plaintext, ciphertext)
        End Function


'Decrypt data by AES algorithm
'
'@parameter handle[in]  Device handle opened
'@parameter ciphertext[in]  Cipher text to be decrypted (16 bytes)
'@parameter plaintext[out] Plain text after being decrypted (16 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_decrypt", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_decrypt32(handle As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)>
                                            ciphertext As Byte(),
                                            <[Out], MarshalAs(UnmanagedType.LPArray)>
                                            plaintext As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_decrypt", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_decrypt64(handle As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)>
                                            ciphertext As Byte(),
                                            <[Out], MarshalAs(UnmanagedType.LPArray)>
                                            plaintext As Byte()) As UInteger
        End Function

        Public Shared Function LC_decrypt(handle As UInteger,
                                          <[In], MarshalAs(UnmanagedType.LPArray)> 
                                          ciphertext As Byte(),
                                          <[Out], MarshalAs(UnmanagedType.LPArray)>
                                          plaintext As Byte()) As UInteger
            If Is64() Then
                Return LC_decrypt64(handle, ciphertext, plaintext)
            End If
            Return LC_decrypt32(handle, ciphertext, plaintext)
        End Function


'Setting new password requires developer privileges.
'
'@parameter handle[in]  Device handle opened
'@parameter flag [in]  Password Type(Admin 0, Generic 1, Authentication 2)
'@parameter newpasswd[in]  Password(8 bytes)
'@parameter retries  [in]  Error Count (1~15), -1 disables error count
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
'*/
        <DllImport(dll32, EntryPoint := "LC_set_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_set_passwd32(handle As UInteger,
                                               flag As UInteger, <[In], MarshalAs(UnmanagedType.LPArray)>
                                               passwd As Byte(), retries As UInteger) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_set_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_set_passwd64(handle As UInteger, flag As UInteger,
                                               <[In], MarshalAs(UnmanagedType.LPArray)> passwd As Byte(),
                                               retries As UInteger) As UInteger
        End Function

        Public Shared Function LC_set_passwd(handle As UInteger, flag As UInteger,
                                             <[In], MarshalAs(UnmanagedType.LPArray)> passwd As Byte(),
                                             retries As UInteger) As UInteger
            If Is64() Then
                Return LC_set_passwd64(handle, flag, passwd, retries)
            End If
            Return LC_set_passwd32(handle, flag, passwd, retries)
        End Function


'Change password
'
'@parameter handle[in]  Device handle opened
'@parameter flag [in]  Password type (Authentication 2)
'@parameter oldpasswd[in]  Old Password (8 bytes)
'@parameter newpasswd[in]  New Password (8 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_change_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_change_passwd32(handle As UInteger,
                                                  type As UInteger,
                                                  <[In], MarshalAs(UnmanagedType.LPArray)>
                                                  oldpasswd As Byte(),
                                                  <[In], MarshalAs(UnmanagedType.LPArray)>
                                                  newpasswd As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_change_passwd", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_change_passwd64(handle As UInteger,
                                                  type As UInteger,
                                                  <[In], MarshalAs(UnmanagedType.LPArray)>
                                                  oldpasswd As Byte(),
                                                  <[In], MarshalAs(UnmanagedType.LPArray)>
                                                  newpasswd As Byte()) As UInteger
        End Function

        Public Shared Function LC_change_passwd(handle As UInteger, type As UInteger,
                                                <[In], MarshalAs(UnmanagedType.LPArray)> oldpasswd As Byte(),
                                                <[In], MarshalAs(UnmanagedType.LPArray)> newpasswd As Byte()) _
            As UInteger
            If Is64() Then
                Return LC_change_passwd64(handle, type, oldpasswd, newpasswd)
            End If
            Return LC_change_passwd32(handle, type, oldpasswd, newpasswd)
        End Function


'Retrieve hardware information
'
'@parameter handle[in]  Device handle opened
'@parameter info [out] Retrieve hardware information
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_get_hardware_info", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_get_hardware_info32(handle As UInteger,
                                                      ByRef info As LC_hardware_info) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_get_hardware_info", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_get_hardware_info64(handle As UInteger,
                                                      ByRef info As LC_hardware_info) As UInteger
        End Function

        Public Shared Function LC_get_hardware_info(handle As UInteger, ByRef info As LC_hardware_info) _
            As UInteger
            If Is64() Then
                Return LC_get_hardware_info64(handle, info)
            End If
            Return LC_get_hardware_info32(handle, info)
        End Function


'Retrieve software information
'
'@parameter info [out] Software information
'
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_get_software_info", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_get_software_info32(ByRef info As LC_software_info) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_get_software_info", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_get_software_info64(ByRef info As LC_software_info) As UInteger
        End Function

        Public Shared Function LC_get_software_info(ByRef info As LC_software_info) As UInteger
            If Is64() Then
                Return LC_get_software_info64(info)
            End If
            Return LC_get_software_info32(info)
        End Function

'Calculate hmac value by hardware

'@parameter handle[in]  Device handle opened
'@parameter text [in]  Data to be used in calculating hmac value
'@parameter textlen  [in]  Data length (>=0)
'@parameter digest[out] Hmac value (20 bytes)

'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_hmac", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_hmac32(handle As UInteger,
                                         <[In], MarshalAs(UnmanagedType.LPArray)>
                                         text As Byte(),
                                         textlen As UInteger, <Out, MarshalAs(UnmanagedType.LPArray)>
                                         digest As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_hmac", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_hmac64(handle As UInteger,
                                         <[In], MarshalAs(UnmanagedType.LPArray)>
                                         text As Byte(),
                                         textlen As UInteger, <Out, MarshalAs(UnmanagedType.LPArray)>
                                         digest As Byte()) As UInteger
        End Function

        Public Shared Function LC_hmac(handle As UInteger,
                                       <[In], MarshalAs(UnmanagedType.LPArray)> text As Byte(),
                                       textlen As UInteger,
                                       <Out, MarshalAs(UnmanagedType.LPArray)> digest As Byte()) As UInteger
            If Is64() Then
                Return LC_hmac64(handle, text, textlen, digest)
            End If
            Return LC_hmac32(handle, text, textlen, digest)
        End Function


'Calculate hmac value by software
'
'@parameter text[in]  Data to be used in calculating hmac value
'@parameter textlen[in]  Data length (>=0)
'@parameter key[in]  key to be used in calculating hmac value(20 bytes)
'@parameter digest  [out] hmac value(20 bytes)
'
'@return value
'Successful, 0 returned; failed, predefined error code returned

        <DllImport(dll32, EntryPoint := "LC_hmac_software", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_hmac_software32(<[In], MarshalAs(UnmanagedType.LPArray)> text As Byte(),
                                                  textlen As UInteger,
                                                  <Out, MarshalAs(UnmanagedType.LPArray)> key As Byte(),
                                                  digest As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_hmac_software", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_hmac_software64(<[In], MarshalAs(UnmanagedType.LPArray)>
        text As Byte(), textlen As UInteger, <Out, MarshalAs(UnmanagedType.LPArray)> key As Byte(),
                                                  digest As Byte()) As UInteger
        End Function

        Public Shared Function LC_hmac_software(<[In], MarshalAs(UnmanagedType.LPArray)>
        text As Byte(), textlen As UInteger, <Out, MarshalAs(UnmanagedType.LPArray)> key As Byte(),
                                                digest As Byte()) As UInteger
            If Is64() Then
                Return LC_hmac_software64(text, textlen, key, digest)
            End If
            Return LC_hmac_software32(text, textlen, key, digest)
        End Function

'Reset Remote Update Key and Authentication Key.
'@parameters handle	[IN] Opened device handle
'@parameters type	[IN] Password type (0=Remote Update Key, 1=Authentication Key)
'@parameters key	[IN] Key (20 bytes)
'@return value
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_set_key", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_set_key32(handle As UInteger, type As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)> key As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_set_key", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_set_key64(handle As UInteger, type As UInteger,
                                            <[In], MarshalAs(UnmanagedType.LPArray)> key As Byte()) As UInteger
        End Function

        Public Shared Function LC_set_key(handle As UInteger,
                                          type As UInteger, <[In], MarshalAs(UnmanagedType.LPArray)>
                                          key As Byte()) As UInteger
            If Is64() Then
                Return LC_set_key64(handle, type, key)
            End If
            Return LC_set_key32(handle, type, key)
        End Function

'Update remotely.
'@parameters handle	[IN] Opened device handle
'@parameters buffer	[IN] Buffer area of remote updating package
'Successful, 0 returned; failed, predefined error code returned
        <DllImport(dll32, EntryPoint := "LC_update", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_update32(handle As UInteger,
                                           <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_update", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_update64(handle As UInteger,
                                           <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
        End Function

        Public Shared Function LC_update(handle As UInteger,
                                         <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte()) As UInteger
            If Is64() Then
                Return LC_update64(handle, buffer)
            End If
            Return LC_update32(handle, buffer)
        End Function

'It requires Admin privileges.
'Generate remote updating package.

'@parameters serial	[IN] Serial number of updating dongle
'@parameters block	[IN] Block number (1~3)
'@parameters buffer	[IN] Updating content (Block in byte)
'@parameters key	[IN] Remote updating key (in byte)
'@parameters uptPkg	[OUT] Generated updating package (in byte)

'Successful, 0 returned; failed, predefined error code returned

        <DllImport(dll32, EntryPoint := "LC_gen_update_pkg", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_gen_update_pkg32(<[In], MarshalAs(UnmanagedType.LPArray)> serial As Byte(),
                                                   block As UInteger,
                                                   <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte(),
                                                   <[In], MarshalAs(UnmanagedType.LPArray)>
                                                   key As Byte(),
                                                   <[Out], MarshalAs(UnmanagedType.LPArray)>
                                                   uptPkg As Byte()
                                                   ) As UInteger
        End Function

        <DllImport(dll64, EntryPoint := "LC_gen_update_pkg", CallingConvention := CallingConvention.StdCall)>
        Public Shared Function LC_gen_update_pkg64(<[In], MarshalAs(UnmanagedType.LPArray)> serial As Byte(),
                                                   block As UInteger,
                                                   <[In], MarshalAs(UnmanagedType.LPArray)> buffer As Byte(),
                                                   <[In], MarshalAs(UnmanagedType.LPArray)> key As Byte(),
                                                   <[Out], MarshalAs(UnmanagedType.LPArray)> uptPkg As Byte()) _
            As UInteger
        End Function

        Public Shared Function LC_gen_update_pkg(handle As UInteger,
                                                 <[In], MarshalAs(UnmanagedType.LPArray)> serial As Byte(),
                                                 block As UInteger,
                                                 <[In], MarshalAs(UnmanagedType.LPArray)>
                                                 buffer As Byte(), <[In], MarshalAs(UnmanagedType.LPArray)>
                                                 key As Byte(),
                                                 <[Out], MarshalAs(UnmanagedType.LPArray)>
                                                 uptPkg As Byte()
                                                 ) As UInteger
            If Is64() Then
                Return LC_gen_update_pkg64(serial, block, buffer, key, uptPkg)
            End If
            Return LC_gen_update_pkg32(serial, block, buffer, key, uptPkg)
        End Function


' Hardware information structure
        <StructLayout(LayoutKind.Sequential, CharSet := CharSet.Auto)>
        Public Structure LC_hardware_info
            Dim developerNumber As UInteger' Developer ID
            <MarshalAs(UnmanagedType.ByValArray, SizeConst := 8)> Dim serialNumber As Byte() _
' Unique Device Serial Number
            Dim setDate As UInteger' Manufacturing date
            Dim reservation As UInteger' Reserve
            Overrides Function ToString() As String
                Dim info As String =
                        String.Format(
                            "developerNumber is{0}" & vbCrLf & "serialNumberis{1}" & vbCrLf & "setDate is {2}" & vbCrLf &
                            "reservation is {3}", developerNumber, Bytes2Str(serialNumber), setDate,
                            reservation)
                Return info
            End Function
        End Structure

' Software information structure
        Public Structure LC_software_info
            Dim version As UInteger'Software edition
            Dim reservation As UInteger'Reserve
            Public Overrides Function ToString() As String
                Dim info As String = String.Format("the version is {0}" & vbCrLf & "the reservation is {1}", version,
                                                   reservation)
                Return info
            End Function
        End Structure
    End Class
End Namespace

