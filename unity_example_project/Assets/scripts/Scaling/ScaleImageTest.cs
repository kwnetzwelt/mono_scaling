/*
using NUnit.Framework;
using System;

namespace AssemblyCSharp
{
	[TestFixture()]
	public class ScaleImageTest
	{
		[Test()]
		public void ThirdScaleTest ()
		{
			
			ScaleImage.Color[] colors = new ScaleImage.Color[9];
			
			colors[0] = new ScaleImage.Color(0,0,0,0);
			colors[1] = new ScaleImage.Color(1,1,1,1);
			colors[2] = new ScaleImage.Color(0,0,0,0);
			
			colors[3] = new ScaleImage.Color(1,1,1,1);
			colors[4] = new ScaleImage.Color(0,0,0,0);
			colors[5] = new ScaleImage.Color(1,1,1,1);
			
			colors[6] = new ScaleImage.Color(0,0,0,0);
			colors[7] = new ScaleImage.Color(1,1,1,1);
			colors[8] = new ScaleImage.Color(0,0,0,0);
			
			ScaleImage si = new ScaleImage(colors, 3);
			
			ScaleImage.Color[] outColors = si.ScaleLinear(1,1);
			
			Assert.IsTrue(outColors.Length == 1);
			
			Assert.IsTrue(outColors[0].a == outColors[0].r);
			
			Assert.IsTrue(outColors[0].a == (4 / 9.0f));
		}
		
		[Test()]
		public void HalfScale ()
		{
			ScaleImage.Color[] colors = new ScaleImage.Color[9];
			
			colors[0] = new ScaleImage.Color(0,0,0,0);
			colors[1] = new ScaleImage.Color(1,1,1,1);
			colors[2] = new ScaleImage.Color(0,0,0,0);
			
			colors[3] = new ScaleImage.Color(1,1,1,1);
			colors[4] = new ScaleImage.Color(0,0,0,0);
			colors[5] = new ScaleImage.Color(1,1,1,1);
			
			colors[6] = new ScaleImage.Color(0,0,0,0);
			colors[7] = new ScaleImage.Color(1,1,1,1);
			colors[8] = new ScaleImage.Color(0,0,0,0);
			
			ScaleImage si = new ScaleImage(colors, 3);
			
			ScaleImage.Color[] outColors = si.ScaleLinear(2,2);
			
			Assert.IsTrue(outColors.Length == 4);
			
			Assert.IsTrue(outColors[0].a == outColors[0].r);
			
		}
	}
}
 */
