# HoloLens 2 Setup

## The Device

The HoloLens 2 is a fully stand-alone device that allows for highly accurate localization and includes transparent waveguides that allow for our human perception system to be fully tricked into a mixed reality environment.
![HoloLens 2 Exploded Image](./Images/H2_ExplodedDiagram.png)
![HoloLens 2 Front Image](./Images/H2_FrontShot.png)

- RGB Camera
  - Different settings but can go up to 60fps
- Visual Light Cameras
  - Focal Length: 1.08mm
  - FOV: 96.1 Degrees
  - Stereo baseline: 98.6mm
- Display
  - Waveguides
  - resolution... eh some fancy made up measurements via Microsoft 2.5k radiants (light points per radian) but others have determined it's more like 20 pixels per degree (ideally you want something over 40...)
  - Uses laser based scanning (LBS) and runs 2 lasers per color with a 4-way shift to reduce screen door effect.
- Microphone
  - 5 Channel Microphone Array
    - These are fantastic and aren't utilized enough in our opinion.
- On-Board Sensors
  - 4 Visible Light cameras: SLAM and structure from motion, center two are the stereo pair, edge cameras = little more sensitive to light.
  - 2 IR cameras for eye tracking
  - 1 MP [Time of Flight Depth Sensor](https://medium.com/chronoptics-time-of-flight/phase-wrapping-and-its-solution-in-time-of-flight-depth-sensing-493aa8b21c42)
    - Fires two different rates, 45fps near-depth mainly used for hand tracking and a 1-5fps for far-depth sensing being used by spatial mapping.
  - Inertial measurement unit (IMU): Accelerometer, gyroscope, magnetometer greatly helps with drift
    - linear acceleration, rotation, and the magnetometer is used for an estimate of absolute orientation.

---
> VMASC XR Nugget
>
> [Karl Guttag](https://kguttag.com/)
---

The HoloLens 2 is different then most of the other HMD's currently publicly available, most cases going forward for a mixed reality experience you are going to be dealing with Video Pass through - the HoloLens uses a transparent diffractive optical element (DOE) waveguide system.
![WaveGuide](./Images/hololensWaveGuidePatent.jpg)

One of the sort of issues with DOE's is going to be the chroma aberrations and it's why when you look through the HoloLens 2 you sometimes see that sort of oil slick color effect: the light is being broken up and very much like a 'prism' so you have the separation of colors and various sort of focal lengths as it bounces around the waveguide and then it gets reassembled on the grating prior to going back to your eye.

### Room Setup

Depending upon what you're doing and/or use case there are a few staple conditions to consider that deal with lighting, color, space, and surfaces. In an ideal world your physical setup matches your place of performance. E.g. you have access to a warehouse close by for a remote warehouse use case on deployment. In most cases this won't work out, and we can talk about what to expect in those situations and how you can counter them.

- Developing for XR requires two sort of setups: 1.) your normal computer space (office space etc.) and 2.) an open room that you have the ability to setup a physical test environment that meets the standards of what it is you're trying to do. This second space is what we're going to focus in on.
- Ideally you want to be a well light room but you don't want to be fighting natural light as the display cannot compete with direct bright surfaces and or light.
- If you know you're going to be in a controlled environment and you are going to be evaluating a lot of vertical information where the user is looking at the horizon and up, you might consider utilizing and painting a wall a darker color or having some sort of dark backdrop.
- Similar sized rooms with similar 'office' furniture layouts can sometimes confuse the device.
- Breaking up the floor and/or close walls
- Walking the space beforehand and confirming the captured environment within the HoloLens web server is adequate - not missing large areas and/or gaps in the on-board spatial map and/or evaluating that space to find those gaps and/or places where the device has issues tracking and being aware of them and/or avoiding them
- Table-top experiences should be flat and free of other items
- Avoid mirrors and/or heavily glass based areas
- Anything that reflects light can cause the depth sensor to do funny things sometimes but the HoloLens has some pretty good redundancies built in.
- In most cases your dedicated machine should have dedicated GPU resources. Until Apple finally offers their VR device - we still suggest running NVidia RTX cards and custom rigs for this level of work.

#### Let's Configure our Space

Before we jump into the device - let's use what we have currently in the lab to get that space setup. We have some table clothes that we can utilize and I have some different color paper here to help showcase the differences in surface color and material in contrast to the vision system. Given the sensor information explained above - we can expect the depth map to update on static items every 1-5 seconds within 1-3 meters of the device - in some cases it won't register smaller items at all that aren't close to a flat surface.

Let's go ahead and pull out our devices - assuming you all have them configured for you - if not we can walk through that process, if you do, let's walk the space so we can build the local map. 

> Please connect them to our wi-fi.

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

## Version Control Setup

- [Git](https://git-scm.com/downloads)
- [Git LFS](https://git-lfs.com/)
- [GitHub Desktop](https://desktop.github.com/)

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

---
> VMASC XR Nugget
>
> Hololens 2 [Research Mode](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/research-mode) & [HoloLens2ForCV Samples](https://github.com/microsoft/HoloLens2ForCV)
>
---

## Unity Setup

- [Unity Account Setup](https://id.unity.com/en/conversations/c2016f3e-64f8-49dd-aab3-7dbbd1246252001f?view=register)
- [Unity Hub](https://unity.com/download)
  - Latest 2021 Version works great
  - Make sure to have the additional Unity Installation components
    - Universal Windows Platform Build Support\
    - Windows Build Support (IL2CPP)

## MRTK Tools Installation

- [MRTK 3 setup for Windows and Unity](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/new-openxr-project-with-mrtk)
- [MRTK Download Unity Tools](https://www.microsoft.com/en-us/download/details.aspx?id=102778)
- [Starting from a new Unity Project](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/getting-started/setting-up/setup-new-project)
- [Holographic Remoting Documentation](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/native/holographic-remoting-player)
- On the HoloLens you need to go to the Windows Store and search for "HoloGraphic Remoting Player" and install it.
  - Once it's running, you will be given an IP address. On Unity with the correct MRTK Remote package installed you can then configure Unity for when you hit "play" for the experience to show up on the headset.
    - This is a great way to run a simple or complicated experience without having to ever deploy and/or build to the device meaning that most of the processing is occurring on the Unity/PC side. 
  - [Download Link for Holographic Remoting](https://apps.microsoft.com/store/detail/holographic-remoting-player/9NBLGGH4SV40?hl=en-us&gl=us&rtc=1)

## On HoloLens Setup

Developer Mode
> Settings
>
> For Developers
>
> Number of paired devices: -->Pair
>

[HoloLens Developer Settings Video](./Videos/HoloLensDeveloperSettings.mp4)

## Unity Example Project(s)

We are mainly going to be using Microsoft example projects as they are the easiest to get up and going with for Monday/Day 1 it's really just about making sure we can explore and connect to the device via the remote streaming configuration. Time dependent and wherever we run into other problems will steer how far we get from here on out. Tuesday/Day 2 we will spend a lot of time in these example projects as well as just general Unity to understand more about the overall workflow.

- In this repository under the [Unity/MRTKDevTemplate](../Unity/MRTKDevTemplate/)
- A blank project with minimum MRTK requirements is also here under the [Unity/MRTK_Setup_01](../Unity/MRKT_Setup_01/) this project was setup from scratch and doesn't contain a lot of the initial prefabs that make it easy to get up and going - in most cases you are advised to start with an existing Microsoft project with examples/prefabs

**We will be using the MRTKDevTemplate one for most of the week**
You can also find this via [Microsoft Mixed Reality Toolkit](https://github.com/microsoft/MixedRealityToolkit-Unity/tree/mrtk3) repository under the MRTK3 Branch. What is in our repository is a manual copy of all of the required libraries and correct references to the additional local packages that Microsoft utilized for the MRTK3 branch.

- Explore the Unity Package Manager to get an idea of all of the various MRTK packages that were already included.
- ![Unity Package Manager](./Images/PackageManager.png)
- MRTK Profiles

## Unity Build Example && Visual Studio Remote Deploy

We are going to just attempt at a quick test build using Unity to build for UWP and then Visual Studio to deploy it over Wi-Fi.

- Unity Build Settings should already be done for you
  - After it builds open up the *.SLN file in the folder you told it about
- In Visual Studio: On the menu bar, select Project > Properties > Configuration Properties > Debugging
- In the Machine name field fill out the HoloLens IP address

## VLC Stream Setup

You can also utilize VLC to stream and it's a little faster with about 1 second delay vs 3-5 via the web server running on the HoloLens 2.

- [VLC Install ](https://get.videolan.org/vlc/3.0.18/win64/vlc-3.0.18-win64.exe)
- Network URL
  - https://{YOUR-HOLOLOENS-IP}/api/holographic/stream/live.mp4
  - E.g. https://192.168.0.171/api/holographic/stream/live.mp4

---
> VMASC XR Nugget
>
> Fonts on the HoloLens 2: stick between 14-18pt when viewed from 18" away. Avoid semilight fonts as they will wiggle under a 42pt
---

## References

- [Microsoft Introduction To Mixed Reality](https://learn.microsoft.com/en-us/training/modules/intro-to-mixed-reality/)
- [Mixed Reality Cloud Services: Azure Remote Rendering](https://azure.microsoft.com/en-us/products/remote-rendering)
- [Microsoft Mixed Reality Documentation](https://learn.microsoft.com/en-us/windows/mixed-reality/?utm_source=developermscom)
- [HoloLens Emulator Setup](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-the-hololens-emulator)
  - [HoloLens Emulator Download Links]([Title](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/hololens-emulator-archive))
- [Remote App HoloLens](https://learn.microsoft.com/en-us/training/modules/pc-holographic-remoting-tutorials/)
- [Technical Details on the H2 Display](https://kguttag.com/2020/07/04/hololens-2-display-evaluation-part-1-lbs-visual-sausage-being-made/)
- [QR Code Tracking](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/qr-code-tracking-overview)
- [Unity Free Assets](https://assetstore.unity.com/packages/3d/environments/low-poly-fps-map-lite-258453)
