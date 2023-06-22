# Workshop Repository

This is just a place for me to drop content and pieces to put together for the workshop.

This repository shouldn't be public as we might have purchased content in it but can be a place to bring such content together for redistribution later as needed

## MRTK Setup Related

## Software Requirements

* GitHub Desktop
* Git
* Git LFS
* Unity
* MRTK
* Ability to connect USB
* Other?

## Course Topics

* Setting up development environment
  * Visual Studio 2022
* Git Setup
  * LFS setup
* MRTK Tools for Windows when the headset is wired in
* Unity
  * UWP Setup
  * Grab an Item and save it from a mesh
  * Unity MRTK vs Unity OpenXR
  * Unity Packages Options
    * Unity Probuilder
    * Unity Timeline
    * Unity UI-Toolkit
  * I/O with gaze, gesture, & voice
    * Accessing the camera and the limitations
  * Unity MRTK UI Event System for XR vs traditional Unity UI 2D
  * Getting in data on the headset via Unity WebRequest
  * URP with MRTK Special Shader
  * Azure World Anchors Example
  * Azure Blob storage example
  * Network Multiple People Example through Azure
* .NET Limitations with MRTK vs normal .NET C#

## Five Days

Monday: Setup and Configuration ==> Maybe get to Visual Studio example

* Two Scenarios:
  * Configured Computers on-site 'ready to go'
* Setup Process
  * 2-4 hour block
* HoloLens Setup
  * Microsoft Setup with Local Server and developer mode and wired/wireless access
* Microsoft examples with just Visual Studio to do a deployment
* How to setup Visual Studio for remote connection and remote deployment over local lan

Tuesday: General Unity 101, git and project setup

* General Unity in the AM
* MRTK Project Setup in the PM
  * Project Setup with MRTK Windows tools for project configuration

Wednesday: In Depth MRTK Profiles and Unity Project Settings for UWP

* Going through all of the 12-14 MRTK profiles
* Input Interactions with hands, eyes, & voice
* Gaining access to lower level requests with cameras and depth data on board

Thursday & Friday

* [Holographic Remote Overview](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/native/holographic-remoting-overview)
* [Establish and setup a Unity Environment](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/use-pc-resources) for the following
  * Preview/Debug Unity Application
  * Resources of the PC to power the app instead of the HoloLens systems
  * "In either case, inputs from the HoloLens--gaze, gesture, voice, and spatial mapping--are sent to the PC, content is rendered in a virtual immersive view, and the rendered frames are then sent to the HoloLens."
* Can get into Azure concepts or use the time leftover to go back through other things
* If you're all in on the Holographic remote you don't need to build custom Hololens apps for cloud connecting, just build native PC apps that do that and hand that off to your remote holographic application
* Potree is a WebGL setup: maybe a way to utilize WebXR and the HoloLens as a viewer but would need to better understand Potree.
  * Looking into alternative options here like [FastPoints](https://github.com/eliasnd/FastPoints)
