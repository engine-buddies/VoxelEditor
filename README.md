# Voxel Editor

This is a quick and dirty voxel editor that will spawn one of a couple 
voxel prebafs where the user clicks. 

When you export the data, it will export the positions of each game object
to a `.lve` file. This file will be used in the Light Vox Engine to 
do some simple scene loading with voxels.


### TODO: 

Currently the editor just floors the hit point of the voxel, so it is pretty
hard to click in certain spots. Gotta fix that! 

Camera snaps to 0 at the start when you right click, gotta fix that too.

Add in some load functionality to this so that we aren't just starting over every time. 
