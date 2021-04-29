
namespace SenseShield
{
    public class LCErrorCode
    {
        // Error Code
        public const int LC_SUCCESS = 0;                           // Successful
        public const int LC_OPEN_DEVICE_FAILED = 1;                // Open device failed
        public const int LC_FIND_DEVICE_FAILED = 2;                // No matching device was found
        public const int LC_INVALID_PARAMETER = 3;                 // Parameter Error
        public const int LC_INVALID_BLOCK_NUMBER = 4;              // Block Error
        public const int LC_HARDWARE_COMMUNICATE_ERROR = 5;        // Communication error with hardware
        public const int LC_INVALID_PASSWORD = 6;                  // Invalid Password
        public const int LC_ACCESS_DENIED = 7;                     // No privileges
        public const int LC_ALREADY_OPENED = 8;                    // Device is open
        public const int LC_ALLOCATE_MEMORY_FAILED = 9;            // Allocate memory failed
        public const int LC_INVALID_UPDATE_PACKAGE = 10;           // Invalid update package
        public const int LC_SYN_ERROR = 11;                        // thread Synchronization error
        public const int LC_OTHER_ERROR = 12;                      // Other unknown exceptions
    }
}