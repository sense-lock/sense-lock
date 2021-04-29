Namespace SenseShield
    Public Class S4Define
        Public Const S4_EXCLUSIZE_MODE As UInteger = 0                               ' exclusive mode 
        Public Const S4_SHARE_MODE As UInteger = 1                               ' sharable mode  

        'the control code value definition

        Public Const S4_LED_UP As UInteger = &H4                      ' LED up 
        Public Const S4_LED_DOWN As UInteger = &H8                      ' LED down  
        Public Const S4_LED_WINK As UInteger = &H28                      ' LED wink  
        Public Const S4_GET_DEVICE_TYPE As UInteger = &H25                      ' Get the device type 
        Public Const S4_GET_SERIAL_NUMBER As UInteger = &H26                      ' Get the device serial number  
        Public Const S4_GET_VM_TYPE As UInteger = &H27                      ' Get the virtual machine type  
        Public Const S4_GET_DEVICE_USABLE_SPACE As UInteger = &H29                      ' Get the total space Of the device  
        Public Const S4_SET_DEVICE_ID As UInteger = &H2A                      ' Set the device ID 
        Public Const S4_RESET_DEVICE As UInteger = &H2                      ' reset the device 
        Public Const S4_DF_AVAILABLE_SPACE As UInteger = &H31                      ' Get the free space Of current directory 
        Public Const S4_EF_INFO As UInteger = &H32                      ' Get specified file information In current directory  
        Public Const S4_SET_USB_MODE As UInteger = &H41                      ' Set the device As a normal usb device 
        Public Const S4_SET_HID_MODE As UInteger = &H42                      ' Set the device As a HID device 
        Public Const S4_GET_CUSTOMER_NAME As UInteger = &H2B                      ' Get the customer number 
        Public Const S4_GET_MANUFACTURE_DATE As UInteger = &H2C                      ' Get the manufacture Date Of the device 
        Public Const S4_GET_CURRENT_TIME As UInteger = &H2D                      ' Get the current time Of the clock device 
        Public Const S4_GET_LICENSE As UInteger = &H2E                      ' Get the license   
        Public Const S4_FREE_LICENSE As UInteger = &H2F                      ' free the license   
        Public Const S4_RESET_LICENSE As UInteger = &H33                      ' Reset the license   
        Public Const S4_SET_NET_CONFIG As UInteger = &H30                      ' Set netlock config  
        Public Const S4_GET_NET_CONFIG As UInteger = &H34                      ' Get netlock config  
        Public Const S4_GET_TOTAL_LICENSE As UInteger = &H35                        ' Get total license Of device, note: license'll be reset after invoking this control code  


        'device type definition
        Public Const S4_LOCAL_DEVICE As UInteger = &H0                            ' local device 
        Public Const S4_MASTER_DEVICE As UInteger = &H1                            ' net master device  
        Public Const S4_SLAVE_DEVICE As UInteger = &H2                            ' net slave device 


        'virtual machine type definition
        Public Const S4_VM_51 As UInteger = &H0                            ' inter 51 
        Public Const S4_VM_251_BINARY As UInteger = &H1                            ' inter 251, binary mode  
        Public Const S4_VM_251_SOURCE As UInteger = &H2                            ' inter 251, source mode 


        'NetLock license mode
        Public Const S4_MODULE_MODE As UInteger = &H0                            ' Module mode  
        Public Const S4_IP_MODE As UInteger = &H1                            ' IP mode 

        '
        'PIN And key type definition
        Public Const S4_USER_PIN As UInteger = &HA1                      ' user PIN 
        Public Const S4_DEV_PIN As UInteger = &HA2                      ' developer PIN   
        Public Const S4_AUTHEN_PIN As UInteger = &HA3                      ' authentication key Of net device 

        'file type definition

        Public Const S4_RSA_PUBLIC_FILE As UInteger = &H6                      ' RSA Public key file 
        Public Const S4_RSA_PRIVATE_FILE As UInteger = &H7                      ' RSA Private key file  
        Public Const S4_EXE_FILE As UInteger = &H8                      ' executable file Of virtual machine 
        Public Const S4_DATA_FILE As UInteger = &H9                      ' data file  
        Public Const S4_HEX_FILE As UInteger = &HA                      ‘Supplement parameter to download HEX file
        Public Const S4_XA_HEX_FILE As UInteger = &HC                      ‘Supplement parameter to download XA HEX file

        '4s Not support
        Public Const S4_XA_EXE_FILE As UInteger = &HB                      ' executable file Of XA User mode  
        'flag value definition
        Public Const S4_CREATE_NEW As UInteger = &HA5                      ' create a New file 
        Public Const S4_UPDATE_FILE As UInteger = &HA6                      ' write data To the specified file 
        Public Const S4_KEY_GEN_RSA_FILE As UInteger = &HA7                      ' generate RSA key pair files 
        Public Const S4_SET_LICENCES As UInteger = &HA8                      ' Set the max license number Of the current Module For the net device 
        Public Const S4_CREATE_ROOT_DIR As UInteger = &HAB                      ' create root directory 
        Public Const S4_CREATE_SUB_DIR As UInteger = &HAC                      ' create child directory For current directory 
        Public Const S4_CREATE_MODULE As UInteger = &HAD                      ' create a Module directory For the net device  
        ' the following three flags can only be used when creating a New executable file  
        Public Const S4_FILE_READ_WRITE As UInteger = &H0                      ' the New executable file can be read And written by executable file  
        Public Const S4_FILE_EXECUTE_ONLY As UInteger = &H100                      ' the New executable file can't be read or written by executable file 
        Public Const S4_CREATE_PEDDING_FILE As UInteger = &H2000                      ' create a padding file 


        'execuable file executing mode definition

        Public Const S4_VM_EXE As UInteger = &H0                      ' executing On virtual machine 
        Public Const S4_XA_EXE As UInteger = &H1                      ' executing On XA User mode    

        'Return value definition

        Public Const S4_SUCCESS As UInteger = &H0                      ' success 
        Public Const S4_UNPOWERED As UInteger = &H1                      ' the device has been powered off   
        Public Const S4_INVALID_PARAMETER As UInteger = &H2                      ' invalid parameter 
        Public Const S4_COMM_ERROR As UInteger = &H3                      ' communication Error 
        Public Const S4_PROTOCOL_ERROR As UInteger = &H4                      ' communication protocol Error 
        Public Const S4_DEVICE_BUSY As UInteger = &H5                      ' the device Is busy 
        Public Const S4_KEY_REMOVED As UInteger = &H6                      ' the device has been removed  
        Public Const S4_INSUFFICIENT_BUFFER As UInteger = &H11                      ' the input buffer Is insufficient 
        Public Const S4_NO_LIST As UInteger = &H12                      ' find no device 
        Public Const S4_GENERAL_ERROR As UInteger = &H13                      ' general Error, commonly indicates Not enough memory 
        Public Const S4_UNSUPPORTED As UInteger = &H14                      ' the Function isn't supported 
        Public Const S4_DEVICE_TYPE_MISMATCH As UInteger = &H20                      ' the device type doesn't match 
        Public Const S4_FILE_SIZE_CROSS_7FFF As UInteger = &H21                      ' the execuable file crosses address As UInteger = &H7FFF 
        Public Const S4_CURRENT_DF_ISNOT_MF As UInteger = &H201                      ' a net Module must be child directory Of the root directory 
        Public Const S4_INVAILABLE_MODULE_DF As UInteger = &H202                      ' the current directory Is Not a Module 
        Public Const S4_FILE_SIZE_TOO_LARGE As UInteger = &H203                      ' the file size Is beyond address As UInteger = &H7FFF 
        Public Const S4_DF_SIZE As UInteger = &H204                      ' the specified directory size Is too small 
        Public Const S4_DEVICE_UNSUPPORTED As UInteger = &H6A81                      ' the request can't be supported by the device 
        Public Const S4_FILE_NOT_FOUND As UInteger = &H6A82                      ' the specified file Or directory can't be found  
        Public Const S4_INSUFFICIENT_SECU_STATE As UInteger = &H6982                      ' the security state doesn't match 
        Public Const S4_DIRECTORY_EXIST As UInteger = &H6901                      ' the specified directory has already existed 
        Public Const S4_FILE_EXIST As UInteger = &H6A80                      ' the specified file Or directory has already existed 
        Public Const S4_INSUFFICIENT_SPACE As UInteger = &H6A84                      ' the space Is insufficient 
        Public Const S4_OFFSET_BEYOND As UInteger = &H6B00                      ' the offset Is beyond the file size 
        Public Const S4_PIN_BLOCK As UInteger = &H6983                      ' the specified pin Or key has been locked 
        Public Const S4_FILE_TYPE_MISMATCH As UInteger = &H6981                      ' the file type doesn't match 
        Public Const S4_CRYPTO_KEY_NOT_FOUND As UInteger = &H9403                      ' the specified pin Or key cann't be found 
        Public Const S4_APPLICATION_TEMP_BLOCK As UInteger = &H6985                      ' the directory has been temporarily locked 
        Public Const S4_APPLICATION_PERM_BLOCK As UInteger = &H9303                      ' the directory has been locked 
        Public Const S4_DATA_BUFFER_LENGTH_ERROR As UInteger = &H6700                      ' invalid data length 
        Public Const S4_CODE_RANGE As UInteger = &H10000                      ' the PC register Of the virtual machine Is out Of range 
        Public Const S4_CODE_RESERVED_INST As UInteger = &H20000                      ' invalid instruction 
        Public Const S4_CODE_RAM_RANGE As UInteger = &H40000                      ' internal ram address Is out Of range 
        Public Const S4_CODE_BIT_RANGE As UInteger = &H80000                      ' bit address Is out Of range 
        Public Const S4_CODE_SFR_RANGE As UInteger = &H100000                      ' SFR address Is out Of range 
        Public Const S4_CODE_XRAM_RANGE As UInteger = &H200000                      ' external ram address Is out Of range 
        Public Const S4_ERROR_UNKNOWN As Long = &HFFFFFFFF                      ' unknown Error      

        Public Const MAX_MODULE_COUNT As UInteger = 64

        Public Const MAX_ATR_LEN As UInteger = 56                              ' max ATR length  
        Public Const MAX_ID_LEN As UInteger = 8                               ' max device ID length  
        Public Const S4_RSA_MODULUS_LEN As UInteger = 128                             ' RSA key modules length,In bytes  
        Public Const S4_RSA_PRIME_LEN As UInteger = 64                              ' RSA key prime length,In bytes 

    End Class
End Namespace