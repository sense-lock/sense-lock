1.demo已经完成，可以支持any cpu， x86， x64 ，按照CPU宽度自动加载对应DLL。
2.运行时候需要copy LC的DLL,目录如下
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

3.支持LC全部API声明，demo演示了大部分API使用方法。
4.最后祝你享受此demo。


北京深思数盾科技有限公司。


