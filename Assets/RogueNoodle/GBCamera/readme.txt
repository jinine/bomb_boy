Thanks for checking out this newest version of GBCamera. The shaders in this version have been updated to support more platforms.


In addition, GBCamera is now available as a post-processing effect compatible with Unity's PostProcessing Stack. In order to access this feature, please complete the following steps:

1. Install the Post Processing package if necessary. This can be found in the Package Manager under the Unity Registry section.

2. Install the package found at 'RogueNoodle/GBCamera/gbcamera_PPS.unitypackage' by double-clicking it in the project browser



Inside the newly added PostProcessing folder is an example scene with the effect active. There are a couple of things to note:

1. The example UI in this scene is set to 'Screen Space - Camera' - this allows the effect to apply to the Canvas elements

2. Normally with post-process effects, you'll want to create a layer dedicated to postprocessing to handle volume blends. In this example, the layer has been set to UI and should be changed to a dedicated layer in your own project.


Have fun!
@rogueNoodle