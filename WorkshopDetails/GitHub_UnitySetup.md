# GitHub & Unity

Git and GitHub can be very powerful within a Unity environment and once you setup a GitHub project board and tie them together via commits and issue tracking you can have almost a zero cost solution to get you thinking towards other options - but this can also be a full solution.

- Get everyone added to a test organization / GitHub account under a team that can see and help us manage our current repository
- will take time here to show and do this with you all live

## ChangeLog

Not going to get super detailed here - if you're not using a changelog, this '[Keep a ChangeLog](https://keepachangelog.com/en/1.1.0/)' is a great place to at least 'start' and at a minimum I would consider running Changelogs for your internal tools/libraries that you all are creating and/or if you end up running your internal Unity Package Manager solutions - this is ideal and you can basically use ML/AI to help curate existing well curated Commits and Pull-Requests to basically do this for you.

- [Simple Unity Package Changelog Example](https://github.com/JShull/FP_Ray/blob/main/CHANGELOG.md)
- [Semantic Versioning](https://semver.org/)

## GitHub Branch Models

GitHub offers some nice documentation on what they call the '[GitHub Flow Model](https://docs.github.com/en/get-started/quickstart/github-flow)' which is a tighter version and/or similar but not exactly a ['Trunk' branch model](https://trunkbaseddevelopment.com/). The main idea with all of these concepts is that your team is primarily working from sort of 'one branch' but you're using branches in a slightly different way between a Trunk and Flow model. In some cases the only branch that is always in a sort of 'runnable state' is main and everything else is some sort of feature branch. With a trunk model you're generally dealing with an extra 'trunk' or branch that is like 'developer' that all other features flow in and then you use 'main' and/or release branches as a way to manage releases and in both circumstances you're utilizing pull requests to sync work under some sort of review process. I more/less try to push the 'Flow' model as in some cases you might have various branches that sort of go no where and/or live off on the side for various purposes and are cleaned up later on. It really just depends on the needs of the group and/or how you all want to internalize work and then how you want to synchronize these processes that we are talking about.

- For e.g.: running a Trunk model with release branches, in theory you should probably make sure your releases are in-line with a ChangeLog and you're using some form of semantic versioning.
- Then when you do builds and even up to deployments you're always managing that version number and making sure it's the same across the working project board, the documentation, and the publish/deployed environment. This approach is ideal for being able to connect the dots and to allow individuals to step in and out of projects without having to have these long on-boarding processes - by just going through documentation, version history, and repositories.
- Here's a bunch of ways to 'think' about how a version control project aligns to an Disciplined Agile Way of Working:
  - Project Board management: Managing tasking/issues flow to sprints, 'x' number of sprints flow to milestones, milestones flow with internal/external releases and contract obligations/deadlines, and so on and so on until you finish and/or hit whatever it is it looks like for 'delivery'.
  - Software progress and or added features/tools correlate directly with milestones. A milestone is say 6-8 weeks out, a sprint is 2-3 weeks out, and working issues are generally designed around 2-4-8hr (Small/medium/large issues).
  - Looking at it from a time per person perspective: In a 40 hour week an ideal amount of pure development time would be around 32 hours: 8 is left for the mundane emails, stand-ups, demo's, and documentation. Again - in my opinion this is ideal but hard to hit week in and out without being diligent about your time.
    - Depending upon issue needs you might have any sort of combination of issue/tasking (small/medium/large 2-4-8hr), to keep it simple if everything was a 'medium' or 4 hour issue/task you'd have 8 tasks per week, per person.
      - If you're running a 2-week sprint cycle, you'd have 16 issues/tasks per sprint, per person.
      - If you're averaging 3 sprints per milestone you're looking at 48 issues/tasks per milestone, per person.
  - Taking the same information above but now evaluating how you reverse back to that from say a planning or 'sprint-0' setup via maybe some white-boarding an idea you might come up with something like this:
    - New interactions for the user all tied to interactivity around individual lidar points:
      - What this means:
        - the ability to select an individual point cloud item
        - the ability to retrieve that meta data of said item
        - populate that meta data into a custom built Unity Prefab that consists of utilizing a traditional Unity Canvas that contains the following interactive buttons and/or actions:
          - the user can pin that point
          - the user can change the color of that point
          - the user can enlarge/scale that point
          - the user can unpin that point
      - What this sounds like:
        - We need a UI that supports this: design and events to go along with each of these actions
          - High level Panel/menu that contains a list of 'buttons' that directly relate to the UI's needed below upon the user selecting any point
            - Color Wheel UI Prototype: *2-4 hours* Issue #1
            - Scale UI Prototype: *2 hours* Issue #2
            - Pin/Unpin UI Prototype: *2-4 hours* Issue #3
          - Selection Feedback UI (user knows they selected a point): 2 hours for a custom 3D object with a transparent shader
        - We need a high level UI script that has a bunch of stub-outs so we can take advantage of Unity's Event system to utilize the editor to drag and drop functions/actions by events (clicks,hovers, etc, probably want some sort of naming convention so when you're looking through the Editor UnityEvent action list you can easily find what functions you want): *4-8 hours* Issue #4
        - We need a color wheel tool with stubs: *8 hours* mainly for mapping coordinate space and generating a generic way to take a raycast end point back through the camera rendering plane to get that color. Issue # 5
          - 'CW_ColorToolActivated()' //public method: activate our color dropper UI
          - 'CWT_OnDropperSelect()' //public method: update our internal parameter to store/save the color here
          - 'CW_OnDropperHoverEnter()' //public method: update our internal parameters that we are in a state of about to be ready to accept a dropper color
          - 'CW_OnDropperHoverExit()' //public method: update our internal parameters that we are no longer in a state of being ready to accept a dropper color
          - 'CW_ScreenPixelToColor()' //private method: internal system converts mouse/pointer pixel location to the color of said pixel location
        - We need a scale tool with stubs: *4 hours* Issue #6
          - 'ST_OnScaleStart()' //public method: update our internal parameters that we are in a state of the Scale Tool being activated/started
          - 'ST_OnScaleEnd()' //public method: update our internal parameters that we are in a state of the scale tool being finished
          - 'ST_OnScaleChange()' //depending upon the UI element being used, there will be some sort of 0-1 parameter being passed here that we will then map and utilize a scalar Vector(min,max) to physical scale our UI representation size to physical world size
          - 'ST_
        - We need a pin/unpin tool with stubs: *8 hours* mainly for syncing up with our current pooling management system Issue #7
          - 'PT_OnPinStart()' //public method: update our internal parameters that we are in a state of the pin tool being activated/started
          - 'PT_OnPinEnd()' //public method: update our internal parameters that we are in a state of the pin tool being finished
          - 'PT_OnPinHoverEnter()' //public method: update some sort of visual/audio feedback system for Hover Enter
          - 'PT_OnPinHoverExit()' //public method: update some sort of visual/audio feedback system for Hover Exit - undo what we do for HoverEnter
          - 'PT_OnPinSelected()' //public method: user has made the input command to select this specific point - we want to cache the point and start the other internal functions to go get data and keep it in our Dictionary etc.
          - 'PT_UnpinSelected()' //public method: user has made the input command to reverse OnPinSelected - we need to clean up whatever we were doing via the cache and make sure that this item is now out of our Dictionary etc.
        - We need a meta-data retrieval file management tool *2 hours* Issue #8
          - 'OpenMetaFileByPointIndex(); //private method: fired off when we select a point to get more information and fires off when we pin an item, takes in a value that is the index/address of our points, that index has a reference in our current meta database and we then run an internal async command to go open that data file and populate our prefab and/or instantiate/set active an item from our prefab pool: will need references to our object pool system
        - > Looking at the system above, it's clear that we probably can use inheritance for a generic 'Tool' construct, and/or a set of C# interface(s) to keep us honest where the interface is tied to managing these sort of tool public function requirements
          - We will then need to build this base class and the required interfaces as well as define the namespace and the Assembly Definition requirements for this 'tool' based system solution. *2-4 hours* Issue #9
            - This will have to occur before we actually then generate/derive classes from this.
          - We can utilize 'generics' from an OOP concept, but just use Unity prefabs for all UI visuals and object pooling to help manage these prefabs. We really only need 'ONE' of these items for the UI as we click around on different points, when we pin a point we really need to object pool those visuals as they will be on every 'pinned point. *2-4 hours building out prefabs from artist/designer items* Issue #10
      - First Estimate of time: (Take upper values)

      |Issue Number|Small|Medium|Large|
      |---|---|---|---|
      |1|---|x|---|
      |2|x|---|---|
      |3|---|x|---|
      |4|---|---|x|
      |5|---|---|x|
      |6|---|x|---|
      |7|---|---|x|
      |8|x|---|---|
      |9|---|x|---|
      |10|---|x|---|
      |Total|2=4hrs|5=20hrs|3=24hrs|

        - Looking at 48 hours of work over or roughly 1.5 weeks of production time (48/32) for one person.

### GitHub Project Boards

We are going to work through understanding how GitHub Projects can be helpful in keeping you on track.

- New Project
- Milestones
- Issues
- Tags

Initially this can be confusing because GitHub projects are tied to people or organizations first. You can then assign repositories to them as needed.
You're going to think 'Repository Project Board' in reality you should be thinking 'Project Board with Repositories'.

### GitHub Board Cards/Issues

>What is a card?
>>Can anything be a card?

**Everyone lets create our first set of cards:**

- E.g. Learn a new area of Unity? Unity Learn is a great place to start
  > Work item name/job number/title: "Breakdown Unity Learn Modules"
  >
  >Priority level: Low/Medium/High
  >
  >Issue Size: Small/Medium/Large (2-4 hours)
  >
  >Milestone: Timeline
  >
  >Details: E.g. Go through Unity Learn and break out learn modules by interests, alignment with project idea, and time. For each module create a GitHub Issue Card with information about it.

- Unity Template Project & Version
  > Work item name/job number/title: "Pick Unity Version and Starter Template"
  >
  >Priority level: Medium
  >
  >Issue Size: Small (1-2 hours)
  >
  >Due date: October 5th
  >
  >Details: Go through some of the starter templates and/or notes from Johns one-on-one in the pulse document to see if there was a suggested starter template. Make sure that the template and version align - maybe test them before picking one and while I'm testing it think about issues/work I could do to adjust/mod this and make additional issues/cards/drafts on the project

## GitHub Desktop and VSCode Integration with Commits

GitHub allows commits to be crafted in a way to have them be directly tied to existing issues. For example - let me setup and clone my repository as I am supposed to - make sure I'm on Developer branch and let me start working on some of my documents.

At any point I decide to save a file and make sure it's backed up with GitHub - I can use some special characters within my commit to activate a service that lets me assign this commit to an issue... it's really cool and a nice way to work.

You can also reference this information directly in VSCode markdown!! This is really fun... let's look at how I can mention this in my proposal!

## Agile Software Concepts

- **Inception**: Sprint "0", this week could be considered an extended Inception where we are more/less just doing enough to get organized and sort of set in the right direction
- **Construction**: Produce a solution that has enough features/value that you could think of this as 'minimum viable product' (MVP) or another term 'minimum business increment' (MBI).
- **Transition**: 'release sprint' or 'deployment sprint' or if you're going for polish/quality 'hardening sprint' mainly this is about taking your existing solution and getting it into a distributed production environment. In a professional standing this generally is one team 'transitioning' the work to another team who's in charge of maintenance, deployment, and managing of that 'product' and/or direct contact with said customers.

The V Model for Software Development life Cycle
![V Model for Software](./Images/VSoftareModel.png)

System Solution Product Life Cycle.
![System Solution Product Life Cycle Figure 6.3 from Choose your WOW](./Images/SystemSolutionProductLifeCycle.png)

### Kanban

Traditional concepts and to some extent still being used but this is generally one piece and/or a subset of the larger agile puzzle. E.g. we use Kanban boards for most of our project work but aren't as rigid on roles when dealing with students/interns as they are always flowing from role to another as they learn new skills but if you discretized this you would be in line with #3 below.

1.) Start with what you do now
2.) Agree to pursue incremental, evolutionary change
3.) Respect the current process, roles, responsibilities, and titles
4.) Encourage acts of leadership at all levels in your organization

#### Why Kanban?

- Ease of use - we can create boards and issues pretty quickly.
- Flexibility - Kanban boards can be adapted
- Clarity - Kanban lets you decide how granular you want to get
- Collaboration - Where we can keep tabs on specific needs of items and work that allows all other members to drop in and get a gauge of what's going on
- Efficiency - by visualizing the work and following through with it you increase efficiency by reducing duplication of information

### Disciplined Agile (DA) Toolkit

- What I would prefer to run but it takes time and you need a dedicated team that fully adopts these processes.
- [Choose your WOW](https://www.amazon.com/Choose-your-WoW-Disciplined-Optimizing/dp/1628257547) - A disciplined Agile Approach to Optimizing Your way of Working - Scott W. Ambler & Mark Lines
![DaD Continuous Delivery: Agile life cylce](./Images/DAD_LifeCycleAgile.jpg)

**Quick Break/Check-in**

## Unity, Git, & GitHub

We are going to create a blank repository, setup a new Unity project, utilize a gitignore file, and possibly utilize git lfs.

- Pull out a Git Bash Command Line Tool
- in git bash, every line follows with an *enter* key press

```git bash
cd
ls
```

![git bash basic](./Images/gitbash_00.png)

- navigate to wherever you're storing your repositories (for me it's C:\GitHub, but it might be different for you!)

```git bash
cd C:/
ls
cd GitHub
```

![git bash navigate GitHub](./Images/gitbash_01.png)

- create a new folder where

```git bash
mkdir <foldername>
ls
```

![git bash make a directory](./Images/gitbash_02.png)

- go into the directory/folder you made
- add in two other folders, one for Unity and one for Documentation
- create a new file called '.gitignore'
- initialize the repository

```git bash
cd <foldername>
mkdir Unity
mkdir Documentation
> .gitignore
git init
ls -a
```

![git bash create a few folders and a new file](./Images/gitbash_03.png)

- the ls with an '-a' flag will show you hidden files like the .gitignore
- Quick pivot to some automation and using services like ChatGPT / OpenAI
- Here's a bash script that automates everything we just did generated via ChatGPT
- Prompt: "I need a bash file that's main intentions is to help me generate a new blank repository with some default folders in it and a default .gitignore file. I want the bash file to have a few parameters that can be changed prior to it running this automation. Those parameters are going to be a string 'filePath' that is where to create this new repository as well as two more string parameters for the names of the folders it's going to create, string called 'documentation' that is equal to "Documentation", and string called 'unity' that is equal to "Unity". Then the bash script's function is to navigate and create that directory, once in the filepath, create those two folders, create a new file with format of a .gitignore file (leave it blank), and then initialize the repository via a command run at that location 'git init'

```bash
#!/bin/bash

# Variables
filePath=$1
documentation=$2
unity=$3

# Create the project folder and navigate into it
mkdir -p $filePath
cd $filePath

# Create the folders
mkdir $documentation
mkdir $unity

# Create a new .gitignore file
touch .gitignore

# Initialize the repository
git init

```

- Once you have this script saved somewhere, you can navigate to that folder, open up git bash and use this line formatted with the name of your bash script to run the script with the 3 passed parameters, e.g.:

```git bash
./<BASH SCRIPT NAME>.sh "C:/GitHub/TestAutomation" "Documentation" "Unity"
```

![git bash automation](./Images/gitbash_04Auto.png)
 
- At this point we need to go update our .gitignore we created and we need to utilize Unity to build us out a new project via Unity Hub located in our Unity folder.
- I prefer VSCode for working with *.gitignore and/or other text based files over other programs and at this highest root there might only be something like to ignore folders named 'build' or something, really depends on what other pieces of files/information you'd be needing to ignore

```gitignore
# ignore our text.txt file in the root repository
/text.txt 
# ignore any file and director with the name test
test
# ignore all files that start with test
test*
# ignore all files that are of type .md or markdown
*.md
# but we don't want to ignore our readme!
!README.md

#ignore all build folders with capital or lower case
[Bb]uild/
```

- lets create our new Unity Project in this Unity folder and then we need to go find a valid Unity *.gitignore and put that in the Unity project folder that we created through the Unity Hub. We need to do this after we create the Project and we want to make sure we include this before we commit the new Unity folder setup.

![new unity project](./Images/UnityGenericProject.png)

- after Unity creates the project we need to then go and utilize a *.gitignore that will work just for Unity folders and projects.
- [Unity .gitignore from GitHub](https://github.com/github/gitignore/blob/main/Unity.gitignore)
  - copy that raw into a new .gitignore file located inside that Unity project you just created via VSCode

  ![unity .gitignore](./Images/unity_gitignore.png)

- At this point let's now go open up GitHub desktop and push our brand new repository up to GitHub
- let's first make sure our high level .gitignore is correct - comment out those .md ignores!
- open up GitHub desktop and 'add existing repository'
- at this point your first commit on GitHub desktop should only have a handful of changes, if you see hundreds/thousands of changes you probably forgot your Unity *.gitignore and you need to fix that before you do this initial commit

![GitHub Desktop Initial Commit/Setup](./Images/GitHubDesktopInitialSetup.png)

- lets pause here and make sure everyone has gotten to this point and we will then get into scriptable objects, data oriented design, etc. etc.

### Data, Serialization, Scriptable Objects, Unity Assembly Definitions, and Unity Package Manager

I'm going to approach this from going through real-time systems and then getting into just the basics of data formats and importantly how this all falls under *interoperability.*

#### Real-time Systems

Going to breakout three classifications of real-time systems and use the work of some great authors/researchers. The below information is based on the work by Hermann Kopetz book, *'Real-Time Systems', 2011* and on the work by Andrew G. PSaltis in *'Streaming Data',2017*, you may also find other terms being used, ['Hard', 'Firm', and 'Soft'](https://en.wikipedia.org/wiki/Real-time_computing#Real-time_and_high-performance).

1. **Hard:** microseconds-milliseconds
  Think very strict time requirements and generally in embedded systems these are part of vital systems in which if time requirements fail we have a total failure of the system: spaceships, pacemaker, anti-lock brakes.
2. **Soft:** milliseconds-seconds
  Generally these systems can be thought of as social media companies, reservation systems, game chat services, etc.
3. **Near:** seconds-minutes
  Smart home devices, some iOT services, video streaming, etc.

I don't want to get in a back and forth on the differences between soft and near as they are very close together and as systems generally get better and as the internet gets faster these will more than likely combine under one concept.

So why do we care about real-time systems? Well in Unity there are multiple ways to get data, do you need it as fast as possible aka a user input from a controller and what sort of tolerances can our software anticipate in those cases and what ones can we *actually* control? This is why Unity and other game engines run multiple core loops within their engines to guarantee tolerances are hit and also to provide foundational 'time' for you to work with. Point to make here: [Fixed Update vs Update.](https://learn.unity.com/tutorial/update-and-fixedupdate)

### Unity Update vs Fixed Update

Update loop is **NOT** called on a regular timeline - this is really important to understand. Update is running 'as fast as possible' meaning that every frame/loop that Unity processes is directly tied to what's going on within your hardware, software, etc. The time difference between update loops changes each loop and we have no guarantee that Update will maintain a constant interval.

![Unity Execution Order](./Images/monobehaviour_flowchart.svg)

### Unity Scriptable Objects, Structs, Function based concepts, and Package Manager

Most of my recent Unity development has spent more time in Data Oriented Design territory - I would do everything in [DOTS/ECS](https://unity.com/dots) but I also recognize that's overkill for 90% of the applications we are building at VMASC - still worth mentioning and in my opinion for a larger group setup that is planning on continuously building in a Unity environment and want things to be more interoperable I would look into a DOTS/ECS design.

C# Structs and Functions are just as effective in Unity as just about any other programming language. Something to consider if you had developers and/or a team that wasn't necessarily utilizing Unity but was rather up to speed on .NET and you wanted to have some re-use of some code as well a great first step towards being ready for more of a DOTS/ECS based design/solution.

[Scriptable Objects](https://docs.unity3d.com/Manual/class-ScriptableObject.html): if you're not using them, use them. If you have a database and/or already existing data structures you probably don't need them, but they are super great for parameters, settings, and loading in data. For example, most of MRTK's profile system is nothing but a bunch of Scriptable Objects - the other reason why you should be using them: very fast to read/write and Unity can manage millions of them. Unity suggests two main use cases for them 1.) Saving and storing data during an Editor session and 2.) Saving data as an Asset in your Project to use at run time. I generally use them in one direction - to read in. You can write to them in the editor but it can cause some issues and I wouldn't do it. In most cases you're using a Scriptable object because you have some sort of configuration and/or data that you want to use the Unity Editor as the interface mechanism. A combination of serialized structs in a Scriptable Object can be very powerful for a wide range of parameter settings, configurations, etc.

---
> VMASC Nugget
>
> [Humble Design Pattern for Unity](https://www.youtube.com/watch?v=3O_rpTWdGps)
---

- let's create some scriptable objects, below I'm going to have some reference information to keep me on track and for you to take advantage of

```C#
using System;
using UnityEngine;

namespace VMASC.Workshop.Standards
{
    [Serializable]
    public enum WorkshopType
    {
        None,
        Boring,
        Basic,
        Nice
    }
    [Serializable]
    [CreateAssetMenu(fileName = "ScriptableExample", menuName = "ScriptableObjects/VMASC/Workshop/Standards", order = 0)]
    public class Workshop_Example : ScriptableObject
    {
        [Tooltip("Has to be unique")]
        public string Index;
        [Tooltip("match our current internal version information")]
        public string Version;
        [TextArea(2,4)]
        public string Description;
    }
}
```

- [Unity Attributes and flags](https://docs.unity3d.com/Manual/Attributes.html)
  - [A whole bunch of them](https://github.com/teebarjunk/Unity-Built-In-Attributes)
- [Unity/C# Namespaces](https://docs.unity3d.com/Manual/Namespaces.html)
  - [Microsoft Documentation on Namespaces](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/namespaces)
- Back in Unity, Create an Assembly Definition
  - [Unity Assembly Definition Documentation](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html)
  - These have incredibly helped us organize our code and our architecture.

**PACKAGE MANAGER** is Amazing - you all should write your own packages and host them internally or remote.

- [Unity Package Manager Documentation](https://docs.unity3d.com/2021.1/Documentation/Manual/CustomPackages.html)
- [Unity YouTube Create and Host your own Packages](https://www.youtube.com/watch?v=mgsLb3TKljk)
- Example Unity Raycast Package I created
  - [Public Unity Raycast Package](https://github.com/JShull/FP_Ray)
- Referencing Packages in the Assembly Definition Files

### Singleton Curse

I want to briefly get into a Singleton pattern here - we will spend more time on that coming up - I want to open up how easy it is to use but point out that it's a curse as you scale and can cause a lot of problems. Good to be aware of them - they can be helpful in a pinch but in the long run there are better alternatives - but we are guilty of using them at VMASC all the time because in most cases we aren't dealing with a bottleneck problem and instead it's 99% mainly used for setup and managing order of operations to work in and/around Unity's execution of events.

- Let's create a singleton based pattern script that will read in our scriptable object data and do something with it.
- Now that we have our assembly definition covering our standards directory we can just right click create a script and unity will automatically give us our namespace

```C#
//example of a normal C# Unity Singleton Setup
Using UnityEngine;
namespace VMASC.Workshop.Standards
{
    
    private static WorkshopManager _instance;
        public static WorkshopManager Instance { get { return _instance; } }
        [Tooltip("The scriptable object data we want to load on start")]
        public Workshop_Example WorkshopSetupData;

        [Space]
        [Header("Unity Events for our Workshop")]
        public UnityEvent BoringWorkshopStart;
        public UnityEvent BasicWorkshopStart;
        public UnityEvent NiceWorkshopStart;
        public void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        public void Start()
        {
            if (WorkshopSetupData != null)
            {
                switch (WorkshopSetupData.TheWorkshopType)
                {
                    case WorkshopType.None:
                        Debug.LogWarning($"None... really?");
                        break;
                    case WorkshopType.Boring:
                        BoringWorkshopStart.Invoke();
                        break;
                    case WorkshopType.Basic:
                        BasicWorkshopStart.Invoke();
                        break;
                    case WorkshopType.Nice:
                        NiceWorkshopStart.Invoke();
                        break;
                }
            }
            else
            {
                Debug.LogError($"Missing a reference to your WorkshopSetupData, {Time.time}");
            }
        }
}
```

What's nice is you can take this same approach and go back and modify our Scriptable object to include maybe some additional details via a struct using the same serializable attribute to give your scriptable objects a lot of Unity Editor power. This also gets you closely working towards a more data oriented design and is easier later on to modify and/adjust. For a lot of this workflow we are just taking advantage of how Unity derives from MonoBehavior and/or ScriptableObject. Unity primarily has classes as components that are attached to their gameobjects, these sort of classes are all derived from the [MonoBehaviour class](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) and thus are then useable within the Unity Editor/gameobjects. You can also reference other native C# classes and you can bring in compiled dynamic linked libraries *.dll which are a great way to modularize your functions/operations/systems and separate out the work from the data.

### Serialization

Quick note on Serialization is taking a data structure/object and encoding it into something a computer can store and/or transfer in a way that if we understand how it was serialized/encoded, we can deserialize/decode it on the other end and get an exact copy of the original data. I'm aware most of you are all probably familiar with this - just wanted to dedicate a block of text to make sure you all have a reference to this within the Unity attribute world [serializeable](https://docs.unity3d.com/ScriptReference/Serializable.html) - also very easy to setup and store user settings and/or write a quick way to store a local file if you needed to via a serialized class that you then just the native json serialization built in to convert.

## UI Toolkit

This will be adhoc and time dependent, might come back around to this later in the day, but just want to spend time showing you all this really nice feature that Unity has been working on.

- [Unity UIToolkit Documentation](https://docs.unity3d.com/Manual/UIElements.html)
- Setup and install the UI Tookit Package
- Build out a simple UI
- Flex
- Templates
- StyleSheets

### References

- [Choose your WoW](https://www.amazon.com/Choose-your-WoW-Disciplined-Optimizing/dp/1628257547)
- [Scriptable Objects](https://docs.unity3d.com/Manual/class-ScriptableObject.html)
- [Unity Execution Order](https://docs.unity3d.com/Manual/ExecutionOrder.html)
- [Game Design Program Repo](https://github.com/JShull/GAME395_Unity)
- [Game Design Program Weekly Recaps](https://github.com/ODU-GameStudiesDesign/G395_WeeklyFiles)
- [Markdown Guides](https://www.markdownguide.org/extended-syntax/)]
