# HoloLens 2 Setup

## OS Requirements and Emulation Setup

If you're going to be using the Emulator you need to be running either Windows Pro, Enterprise, or Education. Your standard Windows Installation does not support "Hyper-V". Hyper-V is the core requirement for the HoloLens Emulator.

Developer Mode
> Settings
>
> Update & Security
>
> For developers

![Developer Mode](./Images/WindowsDeveloperMode.png)

Emulator Hyper-V Setup
> Control Panel
>
> Programs
>
> Programs & Features
>
> Windows Features on/off & look for Hyper-V and select it
>> Restart Your Computer

![HyperVSetup](./Images/HyperVSetup.png)

Windows Long Paths
> Registry Key
>
> Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem\LongPathsEnabled

![LongPath](./Images/LongPaths.png)

## Visual Studio 2022 Setup

Currently just using Community 2022 but any paid version will work as well. There are going to be additional software library requirements than just normal Visual Studio.

- .NET Desktop
- Desktop Development with C++
- UWP
  - Additional requirements for UWP
    - Windows SDK 10 or 11
    - USB Device Connectivity
    - C++ v142
- Unity Extension

## Version Control Setup

- [Git](https://git-scm.com/downloads))
- [Git LFS](https://git-lfs.com/)
- [GitHub Desktop](https://desktop.github.com/)

## Unity Setup

- [Unity Hub](https://unity.com/download)
- Archived Version: [2021.3.21f1](https://unity.com/releases/editor/qa/lts-releases?version=2021.3)
- Manually have to add in Unity Additional Components
  - Universal Windows Platform Build Support\
  - Windows Build Support (IL2CPP)

## MRTK Tools Installation

- [MRTK Setup Tools for Windows and Unity](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/new-openxr-project-with-mrtk)


## VLC Stream Setup

- [VLC Install ](https://get.videolan.org/vlc/3.0.18/win64/vlc-3.0.18-win64.exe)
- Network URL
  - https://{YOUR-HOLOLOENS-IP}/api/holographic/stream/live.mp4
  - E.g. https://192.168.0.171/api/holographic/stream/live.mp4

#### References

- [Microsoft Introduction To Mixed Reality](https://learn.microsoft.com/en-us/training/modules/intro-to-mixed-reality/)
- [Mixed Reality Cloud Services: Azure Remote Rendering](https://azure.microsoft.com/en-us/products/remote-rendering)
- [Microsoft Mixed Reality Documentation](https://learn.microsoft.com/en-us/windows/mixed-reality/?utm_source=developermscom)
- [HoloLens Emulator Setup](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-the-hololens-emulator)
  - [HoloLens Emulator Download Links]([Title](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/hololens-emulator-archive))
- [Remote App HoloLens](https://learn.microsoft.com/en-us/training/modules/pc-holographic-remoting-tutorials/)