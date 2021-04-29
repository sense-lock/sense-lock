1. Demo has been completed, which can support any CPU, x86, x64, and automatically load the corresponding DLL according to the CPU width.
2. The DLL of copy LC is required when the program is running. The directory is as follows
Dir:.
│  LCDefine.cs
│  LCErrorCode.cs
│  LC_CSharp.csproj
│  LC_CSharp.sln
│  Program.cs
│  readme_CN.txt
│  readme_EN.txt
│
└─bin
    ├─Debug
    │  └─dll
    │      ├─x64
    │      │      Sense_LC.dll
    │      │
    │      └─x86
    │              Sense_LC.dll
    │
    ├─Release
    │  └─dll
    │      ├─x64
    │      │      Sense_LC.dll
    │      │
    │      └─x86
    │              Sense_LC.dll
    │
    ├─x64
    │  ├─Debug
    │  │  └─dll
    │  │      ├─x64
    │  │      │      Sense_LC.dll
    │  │      │
    │  │      └─x86
    │  │              Sense_LC.dll
    │  │
    │  └─Release
    │      ├─dll
    │      │  ├─x64
    │      │  │      Sense_LC.dll
    │      │  │
    │      │  └─x86
    │      │          Sense_LC.dll
    │      │
    │      └─zh-CHS
    │              mscorlib.resources.dll
    │
    └─x86
        ├─Debug
        │  └─dll
        │      ├─x64
        │      │      Sense_LC.dll
        │      │
        │      └─x86
        │              Sense_LC.dll
        │
        └─Release
            └─dll
                ├─x64
                │      Sense_LC.dll
                │
                └─x86
                        Sense_LC.dll

Sense_ LC.dll
3. All LC API statements are supported, and demo demonstrates the usage of most APIs.
Finally, I wish you enjoy this demo.
Beijing Shensi Shudun Technology Co., Ltd.