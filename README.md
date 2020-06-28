# Civ5LaunchBridge
Enables you to just start the game without the launcher dropping in background on random monitor.

# What it does
1. Start the launcher
2. Wait for 15 sec till to make sure the launcher had time to start and display
3. Put the Launcher top/left of your monitor setup and put it on top
4. Simulate a click with an offset to hit the Play-Button

# Security
The values in the config are not whitelisted before they are used, this can be a potential security risc if your configuration file gets manipulated.

This tool can be used for pretty much any Window Launcher. The code is cleaned up a little bit to seperate the Windows Interop stuff. Some edge cases might not work. Have fun!
