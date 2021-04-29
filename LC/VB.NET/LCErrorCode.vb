Public Class LCErrorCode
    'Error Code
    Public Const LC_SUCCESS = 0                           'Successful
    Public Const LC_OPEN_DEVICE_FAILED = 1                'Open device failed
    Public Const LC_FIND_DEVICE_FAILED = 2                'No matching device was found
    Public Const LC_INVALID_PARAMETER = 3                 ' Parameter Error
    Public Const LC_INVALID_BLOCK_NUMBER = 4              ' Block Error
    Public Const LC_HARDWARE_COMMUNICATE_ERROR = 5        ' Communication error with hardware
    Public Const LC_INVALID_PASSWORD = 6                  ' Invalid Password
    Public Const LC_ACCESS_DENIED = 7                     ' No privileges
    Public Const LC_ALREADY_OPENED = 8                    ' Device is open
    Public Const LC_ALLOCATE_MEMORY_FAILED = 9            ' Allocate memory failed
    Public Const LC_INVALID_UPDATE_PACKAGE = 10           ' Invalid update package
    Public Const LC_SYN_ERROR = 11                        ' thread Synchronization error
    Public Const LC_OTHER_ERROR = 12                      ' Other unknown exceptions
End Class
