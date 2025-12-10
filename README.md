# Ovidianum XR Arena (OXRA)

A starter template XR Arena Application



# Setup

1: Download Unity 2022.3.62f3 LTS.

2: Install Blender as it is a dependency for Unity to build the 3D assets.

2: Browse the Docs and Guides about setting up Unity for Meta Quest development, https://developer.meta.com/horizon/documentation/unity/unity-env-device-setup/ Creating a Developer Account and enabling ADB access on the device will be required.

3: Download the Blender Assets archive and extract it into the Assets folder of the project. "blender assets" folder should be present in "Assets".

4: Open or Import this project into Unity Hub.

5: Open the Arena scene in Scenes/SceneVR-Arena/SceneVR-Arena for editing. the SceneVR-Menu is the initial scene that runs before the Arena one.

6: Play test, press play in editor, use WASD for movement and mouse for UI selection, click "Auto Start", this checks for broadcasting servers on LAN, if there is none, it starts itself as a Host. Interaction is currently limited without headset.

7: Build to device(s). Go to Build Settings, select Android and press Switch Platform. Under "Run Device" select your headset. If it doesn't appear then ADB isn't working correctly.


# Notes

1: FIREWALLS - Take into account any anti virus/firewall blocking, along with additional settings for your particular platform (broadcast address iOS, Network Discovery sharing settings to on in Windows etc).

