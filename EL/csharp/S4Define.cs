
namespace Elite4SDemo.SenseShield
{
    public class S4Define
    {
        public const int S4_EXCLUSIZE_MODE = 0;                               // exclusive mode 
        public const int S4_SHARE_MODE = 1;                               // sharable mode  

        // the control code value definition

        public const int S4_LED_UP = 0x4;                      // LED up 
        public const int S4_LED_DOWN = 0x8;                      // LED down  
        public const int S4_LED_WINK = 0x28;                      // LED wink  
        public const int S4_GET_DEVICE_TYPE = 0x25;                      // Get the device type 
        public const int S4_GET_SERIAL_NUMBER = 0x26;                      // Get the device serial number  
        public const int S4_GET_VM_TYPE = 0x27;                      // Get the virtual machine type  
        public const int S4_GET_DEVICE_USABLE_SPACE = 0x29;                      // Get the total space Of the device  
        public const int S4_SET_DEVICE_ID = 0x2A;                      // Set the device ID 
        public const int S4_RESET_DEVICE = 0x2;                      // reset the device 
        public const int S4_DF_AVAILABLE_SPACE = 0x31;                      // Get the free space Of current directory 
        public const int S4_EF_INFO = 0x32;                      // Get specified file information In current directory  
        public const int S4_SET_USB_MODE = 0x41;                      // Set the device As a normal usb device 
        public const int S4_SET_HID_MODE = 0x42;                      // Set the device As a HID device 
        public const int S4_GET_CUSTOMER_NAME = 0x2B;                      // Get the customer number 
        public const int S4_GET_MANUFACTURE_DATE = 0x2C;                      // Get the manufacture Date Of the device 
        public const int S4_GET_CURRENT_TIME = 0x2D;                      // Get the current time Of the clock device 
        public const int S4_GET_LICENSE = 0x2E;                      // Get the license   
        public const int S4_FREE_LICENSE = 0x2F;                      // free the license   
        public const int S4_RESET_LICENSE = 0x33;                      // Reset the license   
        public const int S4_SET_NET_CONFIG = 0x30;                      // Set netlock config  
        public const int S4_GET_NET_CONFIG = 0x34;                      // Get netlock config  
        public const int S4_GET_TOTAL_LICENSE = 0x35;                        // Get total license Of device, note: license'll be reset after invoking this control code  


        // device type definition
        public const int S4_LOCAL_DEVICE = 0x0;                            // local device 
        public const int S4_MASTER_DEVICE = 0x1;                            // net master device  
        public const int S4_SLAVE_DEVICE = 0x2;                            // net slave device 


        // virtual machine type definition
        public const int S4_VM_51 = 0x0;                            // inter 51 
        public const int S4_VM_251_BINARY = 0x1;                            // inter 251, binary mode  
        public const int S4_VM_251_SOURCE = 0x2;                            // inter 251, source mode 


        // NetLock license mode
        public const int S4_MODULE_MODE = 0x0;                            // Module mode  
        public const int S4_IP_MODE = 0x1;                            // IP mode 

        // 
        // PIN And key type definition
        public const int S4_USER_PIN = 0xA1;                      // user PIN 
        public const int S4_DEV_PIN = 0xA2;                      // developer PIN   
        public const int S4_AUTHEN_PIN = 0xA3;                      // authentication key Of net device 

        // file type definition

        public const int S4_RSA_PUBLIC_FILE = 0x6;                      // RSA Public key file 
        public const int S4_RSA_PRIVATE_FILE = 0x7;                      // RSA Private key file  
        public const int S4_EXE_FILE = 0x8;                      // executable file Of virtual machine 
        public const int S4_DATA_FILE = 0x9;                      // data file  
        public const int S4_HEX_FILE = 0xA;                      // ‘Supplement parameter to download HEX file
        public const int S4_XA_HEX_FILE = 0xC;                      // ‘Supplement parameter to download XA HEX file

        // 4s Not support
        public const int S4_XA_EXE_FILE = 0xB;                      // executable file Of XA User mode  
        // flag value definition
        public const int S4_CREATE_NEW = 0xA5;                      // create a New file 
        public const int S4_UPDATE_FILE = 0xA6;                      // write data To the specified file 
        public const int S4_KEY_GEN_RSA_FILE = 0xA7;                      // generate RSA key pair files 
        public const int S4_SET_LICENCES = 0xA8;                      // Set the max license number Of the current Module For the net device 
        public const int S4_CREATE_ROOT_DIR = 0xAB;                      // create root directory 
        public const int S4_CREATE_SUB_DIR = 0xAC;                      // create child directory For current directory 
        public const int S4_CREATE_MODULE = 0xAD;                      // create a Module directory For the net device  
        // the following three flags can only be used when creating a New executable file  
        public const int S4_FILE_READ_WRITE = 0x0;                      // the New executable file can be read And written by executable file  
        public const int S4_FILE_EXECUTE_ONLY = 0x100;                      // the New executable file can't be read or written by executable file 
        public const int S4_CREATE_PEDDING_FILE = 0x2000;                      // create a padding file 


        // execuable file executing mode definition

        public const int S4_VM_EXE = 0x0;                      // executing On virtual machine 
        public const int S4_XA_EXE = 0x1;                      // executing On XA User mode    

        // Return value definition

        public const int S4_SUCCESS = 0x0;                      // success 
        public const int S4_UNPOWERED = 0x1;                      // the device has been powered off   
        public const int S4_INVALID_PARAMETER = 0x2;                      // invalid parameter 
        public const int S4_COMM_ERROR = 0x3;                      // communication Error 
        public const int S4_PROTOCOL_ERROR = 0x4;                      // communication protocol Error 
        public const int S4_DEVICE_BUSY = 0x5;                      // the device Is busy 
        public const int S4_KEY_REMOVED = 0x6;                      // the device has been removed  
        public const int S4_INSUFFICIENT_BUFFER = 0x11;                      // the input buffer Is insufficient 
        public const int S4_NO_LIST = 0x12;                      // find no device 
        public const int S4_GENERAL_ERROR = 0x13;                      // general Error, commonly indicates Not enough memory 
        public const int S4_UNSUPPORTED = 0x14;                      // the Function isn't supported 
        public const int S4_DEVICE_TYPE_MISMATCH = 0x20;                      // the device type doesn't match 
        public const int S4_FILE_SIZE_CROSS_7FFF = 0x21;                      // the execuable file crosses address As Integer = &H7FFF 
        public const int S4_CURRENT_DF_ISNOT_MF = 0x201;                      // a net Module must be child directory Of the root directory 
        public const int S4_INVAILABLE_MODULE_DF = 0x202;                      // the current directory Is Not a Module 
        public const int S4_FILE_SIZE_TOO_LARGE = 0x203;                      // the file size Is beyond address As Integer = &H7FFF 
        public const int S4_DF_SIZE = 0x204;                      // the specified directory size Is too small 
        public const int S4_DEVICE_UNSUPPORTED = 0x6A81;                      // the request can't be supported by the device 
        public const int S4_FILE_NOT_FOUND = 0x6A82;                      // the specified file Or directory can't be found  
        public const int S4_INSUFFICIENT_SECU_STATE = 0x6982;                      // the security state doesn't match 
        public const int S4_DIRECTORY_EXIST = 0x6901;                      // the specified directory has already existed 
        public const int S4_FILE_EXIST = 0x6A80;                      // the specified file Or directory has already existed 
        public const int S4_INSUFFICIENT_SPACE = 0x6A84;                      // the space Is insufficient 
        public const int S4_OFFSET_BEYOND = 0x6B00;                      // the offset Is beyond the file size 
        public const int S4_PIN_BLOCK = 0x6983;                      // the specified pin Or key has been locked 
        public const int S4_FILE_TYPE_MISMATCH = 0x6981;                      // the file type doesn't match 
        public const int S4_CRYPTO_KEY_NOT_FOUND = 0x9403;                      // the specified pin Or key cann't be found 
        public const int S4_APPLICATION_TEMP_BLOCK = 0x6985;                      // the directory has been temporarily locked 
        public const int S4_APPLICATION_PERM_BLOCK = 0x9303;                      // the directory has been locked 
        public const int S4_DATA_BUFFER_LENGTH_ERROR = 0x6700;                      // invalid data length 
        public const int S4_CODE_RANGE = 0x10000;                      // the PC register Of the virtual machine Is out Of range 
        public const int S4_CODE_RESERVED_INST = 0x20000;                      // invalid instruction 
        public const int S4_CODE_RAM_RANGE = 0x40000;                      // internal ram address Is out Of range 
        public const int S4_CODE_BIT_RANGE = 0x80000;                      // bit address Is out Of range 
        public const int S4_CODE_SFR_RANGE = 0x100000;                      // SFR address Is out Of range 
        public const int S4_CODE_XRAM_RANGE = 0x200000;                      // external ram address Is out Of range 
        public const long S4_ERROR_UNKNOWN = 0xFFFFFFFFL;                      // unknown Error      
        public const int MAX_MODULE_COUNT = 64;
        public const int MAX_ATR_LEN = 56;                              // max ATR length  
        public const int MAX_ID_LEN = 8;                               // max device ID length  
        public const int S4_RSA_MODULUS_LEN = 128;                             // RSA key modules length,In bytes  
        public const int S4_RSA_PRIME_LEN = 64;                              // RSA key prime length,In bytes 
    }
}