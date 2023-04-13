# Unity-Simple-Combat

Put a gun script on the camera or something and make sure to set up a firepoint transform as  a child of the gun.

If you want the gun to **eject shells**, create a shell prefab with a rigidbody to eject from the gun. Place another transform as a child of the gun and put the Launcher script on it with the shell you created as its prefab to launch and the transform itself as the launch point. Then place the object with the launcher script onto the shell ejector field on the gun object.

I didn't include a hitmarker sprite because it wasn't mine to post. They're easy to find by googling "hitmarker png". Place a canvas in the scene with an image and place the hitmarker sprite into the image. Then place the hitmarker script and the ImageAffector script on the image object. Place the image component into the image field of the Image Affector and the rect transform of the Image object into the rect transform field. Then place the object with the ImageAffector script into the Image affector field of the hitmarker component. The hitmarker will not show up unless in the scene and if the gun is firing at a hitbox.

To use hitbox, just add the Hitbox component to an object WITH A COLLIDER and NOT on the IgnoreRaycast layer. Shoot at it. It will eventually die.
