mono_scaling
============

Provides software scaling algorithms for textures and images for mono, c-sharp complete with Unity3D integration. 

The repository includes an example project for unity. In there you will find classes/examples for scaling unity's Texture2D. 

All Scripts are in namespace "Scaling". So if you wonder, why there is nothing there to use... type "using Scaling;" in the top line of your script. 
You can then Load a texture2D and read its pixels using the handy GetPixels32() method. You should be aware that this method has restrictions. It only works on certain texture formats and if the texture is readable! If you are doing this at runtime, note that the code is not optimized for performance (or in any way at all). 

Which algorithms are included?
------------------------------

* Point Scaling
* Linear Filtered Scaling
* Lanczos Filtered Scaling

DISCLAIMER: There is no guarantee that these filters work or even do what their name is saying. They should however scale the source image ... somehow. 

I'm not using Unity3D and still want your code
----------------------------------------------

That's easy! Just grab the contents of 
```sh
unity_example_project\Assets\scripts\Scaling
```

Everything you need is there. 

How Do I actually scale anything?
---------------------------------

The code includes the Scaling.ScaleImage class. To scale an image you simply create an instance with your original image and call the scale method you want to use. 

```c-sharp
Scaling.ScaleImage l = new Scaling.ScaleImage(colors, _width);
resultColors = l.ScaleLanczos(_targetWidth,_targetHeight);
```

The Scaling namespace uses its own color representation struct called SColor. SColor is a struct containing four float variables (ranging from 0 to 1) for red, green, blue and alpha value. For Unity coders there are helper functions to convert SColor to UnityEngine.Color.
 
