# MRTK Overview Document

This is a document curated towards utilizing existing MRTK documentation and notes to go along with Day 3 of the workshop. This is to help keep us on task as well as provide a place for us to share additional resources and information for all things MRTK.

## What is MRTK?

On the surface it looks like a lot of just different example projects and snippets of code and what not to help build HoloLens 2 projects but it's incredibly much much more. At the core MRTK is really an ethos instilled as an SDK to allow developers to build interactions across multiple input hardware for mixed reality experiences. It lays down a set of foundational spatial interaction techniques as well as user interface techniques that are adaptive to the device so really you don't have to write a lot of boiler plate code to work from say a HoloLens 2 deployment to a VR deployment to a mobile phone deployment - touch across each one of those devices has it's own specific development requirements, MRTK helps fill that in for you automatically just by understanding and utilizing MRTK and understanding it's profile system.

In our opinion, MRTK was way ahead of the rest of the SDK's out there and only until the last few months have other software/hardware groups caught up. Initially launched in 2017, the first version was rough, and was overdue. The originally HoloLens launched in 2015 with not a lot of specialized interaction capability. The team building MRTK started building the software to meet the original device and more importantly be ready for the second device. V1 was really only utilized for the HoloLens 1 device, it wasn't until MRTK V2 and when the second HoloLens 2 device came out that it really hit a nice stride. Version 2 came out right around general availability for the H2 device and it was amazing from day 1. It gave Unity developers a way to immediately build for the HoloLens 2, includes a simulator, and their entire software architecture lets you build across other existing VR devices as well as Android and iOS devices. This was before OpenXR finalized their requirements and before Unity and even Oculus had a nice SDK on the market. Up until this point a lot of the work towards interactions was either work from Valve via SteamVR SDK, being done by misc. indie groups selling assets on the Unity store, and/or specialized research labs around the country. It was a real minefield in terms of development as you would spend a lot of time on writing interaction code for one specific hardware.

Now with all of that being said, everyone else has just about caught up and the work coming out of Unity specifically with their Interaction SDK 2.4 should be heavily looked at. We want to make sure everyone starts to understand that MRTK might not actually be the best way forward now, but at this very moment in time, it's still probably the go-to solution for rapid prototyping specifically for the HoloLens 2 device. Talking with some of the developers of Unity's internal XR interaction kit has lead me to believe that by the end of this year most of the advantages that MRTK offer will be all internal to the Unity XR Interaction toolkit

## Input System

### Hand Tracking

### Eye Tracking

### Voice Services

### Gesturing

## Profiles

## Solvers

## Spatial Awareness

## MRTK Shader

### MRTK Resources

- [Microsoft MRTK GitHub](https://github.com/microsoft/MixedRealityToolkit-Unity)
- [MRTK holoDevelopers Slack Channel](https://holodevelopers.slack.com/)
- [MRTK Namespace API Documentation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.mixedreality.toolkit?view=mixed-reality-toolkit-unity-2020-dotnet-2.8.0)
