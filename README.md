# Unity-Simple-Combat
**Weapon Handling**:
The WeaponUser holds all the weapons on an object to allow switching between them. Not ideal but put all the transforms which have a component that implements IWeapon onto the "transformsWithWeapons" field in the WeaponUser and the script will determine if the transform has a weapon.

**Shooting**:
Put a **Gun** script on the camera or something and make sure to set up a firepoint transform as  a child of the gun.

**Hitboxes**:
To use hitbox, just add the Hitbox component to an object WITH A COLLIDER and NOT on the IgnoreRaycast layer. Shoot at it. It will eventually die.

**Entities**
The entity class is used to absorb the damage of a game object composed of multiple hitboxes. For example, on a human-type enemy, you'd have hitboxes on on the arms, legs, chest, head, et cetera. Each hitbox takes damage and can multiply it (damage * multiplier) based on what the body part is (so a headshot is worth a lot more than a hit to the hand) and pass that damage on to the main Entity class.
*One implementation idea is that you do damage to both the **hitbox and the entity** so that if you have a Mech, you could (when a hitbox 'dies') **disable parts of the body** and accumulate damage on the main unit.*
 You guys can figure that out. I don't want to box anyone in or make what's called "simple combat" into "complex combat, my way."

**Hitmarker**:
I didn't include a hitmarker sprite because it wasn't mine to post. They're easy to find by googling "hitmarker png". Place a canvas in the scene with an image and place the hitmarker sprite into the image. Then place the hitmarker script and the ImageAffector script on the image object. Place the image component into the image field of the Image Affector and the rect transform of the Image object into the rect transform field. Then place the object with the ImageAffector script into the Image affector field of the hitmarker component. The hitmarker will not show up unless in the scene and if the gun is firing at a hitbox.

**GunfireSounds**
On the gun script theres a class called SoundBank which allows the user to add a list of audioclips from which the gun will choose one at random to play once a shot is fired. If too little time has passed or the gun is out of ammo, there is also a SoundBank for click sounds which does the same thing.

**Ejecting Shells (Launching projectiles)**:
If you want the gun to **eject shells**, create a shell prefab with a rigidbody to eject from the gun. Place another transform as a child of the gun and put the Launcher script on it with the shell you created as its prefab to launch and the transform itself as the launch point. Then place the object with the launcher script onto the shell ejector field on the gun object.



