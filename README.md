# Hyperbolica_TestPlugin
Test BepInEx plugin for Hyperbolica game I wrote to mess around with the game.

## BepInEx
To get it to run (or even compile) you have to install the latest BepInEx IL2CPP x64 version inside your game.  
Download: https://builds.bepinex.dev/projects/bepinex_be  
Installation: https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html  
Remember to launch the game at least once to let BepInEx generate the unhollowed assemblies.

## Compiling
After cloning this repo you will have to fix the assembly references, just point them to wherever your game's generated unhollowed assemblies are.  
For BepInEx, they're going to be located in `<Game Folder>\BepInEx\unhollowed`.  
Also, make sure to restore the NuGet packages.

## Running the plugin
Copy the compiled DLL file to the game's plugin folder, located in `<Game Folder>\BepInEx\plugins`.