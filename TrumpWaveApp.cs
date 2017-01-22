// This game presents the current DEFCON status on your Sifteo cubes.
// Stop Trump from exploding:
// * Press Trump: Change Game Mode
// * Flip: Turn the cubes over in DEFCON order, then back again in reverse order
//   to de-escalate the emergency. Effectively a fore and back Mexican Wave
//
// This program demonstrates the following concepts:
//
// * Event handling basics
// * Cube sensor events
// * Image drawing basics
//
// ------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using Sifteo;

namespace TrumpWave {
   
  public class TrumpWaveApp : BaseApp {

    public String[] mImageNames;
    public List<CubeWrapper> mWrappers = new List<CubeWrapper>();
    public Random mRandom = new Random();

// My additions for background and success sounds
	private bool FlipCheck;
	private int FlipToCheck;
	private int FlipStatus;
	private bool ButtonCheck;
	private int ButtonToCheck;
	private int ButtonStatus;
	private Sound mMusic;
	private int lastIndex;
	private int indexDir;
//	private int frameCount;
//	private int countTimer;

    // Here we initialize our app.
    public override void Setup() {

// Logic for correct Defcon completion
	FlipCheck = false;
	ButtonCheck = false;
	lastIndex = 0;
//	countTimer = 0;
//	frameCount = 40;

// Load up the list of images.
     mImageNames = LoadImageIndex();

// Loop through all the cubes and set them up.
     foreach (Cube cube in CubeSet) {

        // Create a wrapper object for each cube. The wrapper object allows us
        // to bundle a cube with extra information and behavior.
		CubeWrapper wrapper = new CubeWrapper(this, cube, lastIndex);
		lastIndex += 1;
        mWrappers.Add(wrapper);
        wrapper.DrawSlide();
      }

    }
    
    // Defer all per-frame logic to each cube's wrapper.
    public override void Tick() {		
		foreach (CubeWrapper wrapper in mWrappers) {
			if (wrapper.mFlipCheck) {
				FlipStatus = wrapper.mImage;
				FlipToCheck = wrapper.mIndex;
				wrapper.mFlipCheck = false;
				FlipCheck = true;
			}
			if (wrapper.mButtonCheck) {
				ButtonStatus = wrapper.mImage;
				ButtonToCheck = wrapper.mIndex;
				wrapper.mButtonCheck = false;
				ButtonCheck = true;
			}
			wrapper.Tick();
      	}
      	
      	if (FlipCheck) {
            FlipCheck = false;
            if (FlipToCheck == lastIndex) {		
                Log.Debug("Correct flipped: " + lastIndex);
				foreach (CubeWrapper wrapper in mWrappers) {
					if(wrapper.mIndex == 0) {
						wrapper.mImage = wrapper.mImage + indexDir; 
						
// counting down. We will need to check direction at some point
					} else if (wrapper.mIndex == FlipToCheck) {
						if (wrapper.mImage < 11) {
							wrapper.mImage += 5; // counting up. We will need to check direction possibly
						}
					}
					wrapper.mNeedDraw = true;
				}

                lastIndex = lastIndex + indexDir;
				if (lastIndex <1) {
					lastIndex = 1;
					indexDir = 1;
				} else if (lastIndex > 5) {
					lastIndex = 5;
					indexDir  = -1;
				}
				CheckSound(1);	
			} else {
				CheckSound(-1);
				Log.Debug("Wrong flipped: " + lastIndex);
				foreach (CubeWrapper wrapper in mWrappers) {
					wrapper.mImage = 16;
					wrapper.mNeedDraw = true;
				}
			}
		}
		
		if (ButtonCheck) {
			ButtonCheck = false;

			if (ButtonStatus == 0) {
				Log.Debug("Trump clicked");
				foreach (CubeWrapper wrapper in mWrappers) {
					wrapper.mImage = wrapper.mIndex + 5;
					wrapper.mNeedDraw = true;
				}	
				lastIndex = 5;		
				indexDir = -1;
				
			} else if (ButtonStatus == 16) {
				foreach (CubeWrapper wrapper in mWrappers) {
					wrapper.mImage = 0;
					wrapper.mNeedDraw = true;
				}	
			} else {
				Log.Debug(ButtonToCheck + "wrongly pressed");
			}
			
		}
    }

	private void CheckSound(int DefDone) {
		if (DefDone == 1) {
/*
			if (mMusic != null) {
				if (mMusic.IsPlaying) {
					mMusic.Stop();
				}
			mMusic = null;
*/				
			Sound s = Sounds.CreateSound("gliss");
			s.Play(1);
//			}

		} else if (DefDone == 0) {
			if (mMusic == null) {
				mMusic = Sounds.CreateSound("music");
			} else if (!mMusic.IsPlaying) {
				mMusic.Play(1,1);
			}
		} else if (DefDone == -1) {
			if (mMusic != null) {
				if (mMusic.IsPlaying) {
					mMusic.Stop();
				}
			
				mMusic = null;
				Sound s = Sounds.CreateSound("bomb");
				s.Play(1);
			}
		}
	}
	
    // ImageSet is an enumeration of your app's images. It is populated based
    // on your app's siftbundle and index. You rarely have to interact with it
    // directly, since you can refer to images by name.
    //
	// Of course in my case, the above was an absolute lie :-( because images seem
	// to load in some weird, consistent order that is unrelated to file names, which
	// made predicting and ordering the images almost impossible (See below for the HACK!
	//
    // In this method, we scan the image set to build an array with the names
    // of all the images.
    private String[] LoadImageIndex() {
      ImageSet imageSet = this.Images;
      ArrayList nameList = new ArrayList();
      foreach (ImageInfo image in imageSet) {
        nameList.Add(image.name);

      }
      String[] rv = new String[nameList.Count];
      for (int i=0; i<nameList.Count; i++) {
				rv[Int32.Parse((string)nameList[i])] = (string)nameList[i];
// This is to force control of image content:
// 0 = Trump
// 1-5 are DEFCON 1 - 5 Tiles for Trump's countdown
// 6-10 are DEFCON 1 - 5 Squares for Player one to flip in order
// 11-16 are DEFCON 1 - 5 Highlighted Squares when Player 2 flips them back correctly
      }
      return rv;
    }

  }

	

  // ------------------------------------------------------------------------
  // ## Wrapper ##
  // "Wrapper" is not a specific API, but a pattern that is used in many Sifteo
  // apps. A wrapper is an object that bundles a Cube object with game-specific
  // data and behaviors.
  public class CubeWrapper {

    public TrumpWaveApp mApp;
    public Cube mCube;
    public int mIndex;
	public int mImage;
    private int mXOffset = 0;
    private int mYOffset = 0;
    private int mScale = 1;
    private int mRotation = 0;

    // This flag tells the wrapper to redraw the current image on the cube. (See Tick, below).
    public bool mNeedDraw = false;
    public bool mFlipCheck = false;
    public bool mButtonCheck = false;

    public CubeWrapper(TrumpWaveApp app, Cube cube, int index) {
	    mApp = app;
	    mCube = cube;
	    mCube.userData = this;
 	    mIndex = index;
		mImage = 0; //Set them all to Trump for now

      // Here we attach more event handlers for button and accelerometer actions.
      mCube.ButtonEvent += OnButton;
      mCube.FlipEvent += OnFlip;
    }

    // ## Button ##
    // This is a handler for the Button event. It is triggered when a cube's
    // face button is either pressed or released. The `pressed` argument
    // is true when you press down and false when you release.
    private void OnButton(Cube cube, bool pressed) {
		if (pressed) {
 //       Log.Debug("Button pressed");
		} else {
// Log.Debug("Button released");
// Do some code for setting the DefCon cubes
			mButtonCheck = true;        
            mNeedDraw = true;

        }
    }

    // ## Flip ##
    // This is a handler for the Flip event. It is triggered when the player
    // turns a cube face down or face up. The `newOrientationIsUp` argument
    // tells you which way the cube is now facing.
    //
    // Note that when a Flip event is triggered, a Tilt event is also
    // triggered.
    private void OnFlip(Cube cube, bool newOrientationIsUp) {
      if (newOrientationIsUp) {
        Log.Debug("Flip face up");
		mFlipCheck = true;
        mNeedDraw = true;
      } else {
        Log.Debug("Flip face down");
		Log.Debug("status: " +mImage.ToString());
		mFlipCheck = true;
        mNeedDraw = true;
      }
    }

    // ## Cube.Image ##
    // This method draws the current image to the cube's display. The
    // Cube.Image method has a lot of arguments, but many of them are optional
    // and have reasonable default values.
    public void DrawSlide() {

      // Here we specify the name of the image to draw, in this case by pulling
      // it from the array of names we read out of the image set (see
      // LoadImageIndex, above).
      //
      // When specifying the image name, leave off any file type extensions
      // (png, gif, etc). Refer to the index file that ImageHelper generates
      // during asset conversion.
      //
      // If you specify an image name that is not in the index, the Image call
      // will be ignored.
      String imageName = this.mApp.mImageNames[this.mImage];

      // You can specify the top/left point on the screen to start drawing at.
      int screenX = mXOffset;
      int screenY = mYOffset;

      // You can draw a portion of an image by specifying coordinates to start
      // reading from (top/left). In this case, we're just going to draw the
      // whole image every time.
      int imageX = 0;
      int imageY = 0;

      // You should always specify the width and height of the image to be
      // drawn. If you specify values that are less than the size of the image,
      // only the portion you specify will be drawn. If you specify values
      // larger than the image, the behavior is undefined (so don't do that).
      //
      // In this example, we assume that the image is 128x128, big enough to
      // cover the full size of the display. If the image runs off the sides of
      // the display (because of offsets due to tilting; see OnTilt, above), it
      // will be clipped.
      int width = 128;
      int height = 128;

      // You can upscale an image by integer multiples. A scaled image still
      // starts drawing at the specified top/left point, but the area of the
      // display it covers (width/height) will be multipled by the scale.
      //
      // The default value is 1 (1:1 scale).
      int scale = mScale;

      // You can rotate an image by quarters. The rotation value is an integer
      // representing counterclockwise rotation.
      //
      // * 0 = no rotation
      // * 1 = 90 degrees counterclockwise
      // * 2 = 180 degrees
      // * 3 = 90 degrees clockwise
      //
      // A rotated image still starts drawing at the specified top/left point;
      // the pixels are just drawn in rotated order.
      //
      // The default value is 0 (no rotation).
      int rotation = mRotation;

      // Clear off whatever was previously on the display before drawing the new image.
      mCube.FillScreen(Color.Black);

      mCube.Image(imageName, screenX, screenY, imageX, imageY, width, height, scale, rotation);
//			Log.Debug(imageName);
      // Remember: always call Paint if you actually want to see anything on the cube's display.
      mCube.Paint();
    }

    // This method is called every frame by the Tick in TrumpWaveApp (see above.)
    public void Tick() {

      // If anyone has raised the mNeedDraw flag, redraw the image on the cube.
      if (mNeedDraw) {
        mNeedDraw = false;
        DrawSlide();
      }
    }

  }
}

// -----------------------------------------------------------------------
//
// TrumpWaveApp.cs
//
// Copyright &copy; 2011 Sifteo Inc. 2017 Dr. Mike Reddy
//
// This program is based upon "Sample Code" as defined in the Sifteo
// Software Development Kit License Agreement. By adapting
// or linking to this program, you agree to the terms of the
// License Agreement.
//
// If this program was distributed without the full License
// Agreement, a copy used to be obtained by contacting
// support@sifteo.com.
// Now, who knows!

