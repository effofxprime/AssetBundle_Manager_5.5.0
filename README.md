### This is a slightly modified version for Unity 5.5.0.  Unity's AssetBundle Manager didn't work out of the box for me and required some changes.  This project reflects those changes.

Some include:
- Making the manager NON SERVER related.  The server doesn't even work, no clue how to fix
- Fixed how it saw local file paths or the lack there of.
- Changed where AssetBundles are stored, which is in the assets/StreamedAssets folder.  This is the best place to hold them.
- Other minor work.
- ???
- Profit!!

### How To Use

- Import both folders into your /assets/ directory.
- In the Menu Up Top, navigate to AssetBundles
- Choose Build AssetBundles
- Wait... :D

- In the samples directory there are examples of how to load. Let's take the loadscene.cs for example.  It's the only one I've used so far
..* Create a new scene
..* Add an empty game object
..* Attach the 'loadScene.cs' file to the game object
..* Type in your scene name without file extension. This can be just your scene name or the location PLUS your scene name within your project.  IE 'scenes/scenename, scenename' etc etc.  I recommend just the name of the scene, Unity will look for it anyways, just don't have the same scene names across your project or you will have to use by location.
..* Play in Editor

You will need to write a script or add to the sceneloader.cs that then unloads the blank scene.  I had you create a blank scene for example only.  You could write up a cool loading screen that has a loading bar while it works behind the scenes.  Or maybe you're using the LoadAssets.cs to quickly change between character outfits.  Lots of different things you can do here!

Please Note *YOU DO NOT DELETE YOUR ORIGINAL FILES*!!  The BuildPlayer in the AssetBundles menu will take care of excluding those assets out so they are not apart of the build and so that only your assetbundles are used!  I learned this the very HARD way!

##### I am not a programing pro.  I just spent so much time with this that I felt I should share what I've learned and corrected.  If you have problems, don't hesitate to post in the issues!!  I will see what can be done.  Feel free to fork and push changes for approval!  Everyone needs to help out with this cuz Unity has failed to really explain this shit all together.  Be sure to check the issues tab and see if you can help anyone!!
