using UnityEngine;
using System.Collections;
using UnityEditor;
public class ScaleTextureContext {
	
	public enum ScaleType
	{
		Point,
		Linear,
		Lanczos
	}
	
	[MenuItem("Assets/Scale Lanczos")]
	public static void ScaleLanczos()
	{
		UnityEngine.Object obj = Selection.activeObject;
		if(obj is Texture2D)
		{
			string path = AssetDatabase.GetAssetPath(obj);
			string newPath = path + "_scaled_lanczos.png";
			Scale(ScaleType.Lanczos, path, newPath);
		}
	}
	
	[MenuItem("Assets/Scale Linear")]
	public static void ScaleLinear()
	{
		UnityEngine.Object obj = Selection.activeObject;
		if(obj is Texture2D)
		{
			string path = AssetDatabase.GetAssetPath(obj);
			string newPath = path + "_scaled_linear.png";
			
			Scale(ScaleType.Linear,path,newPath);
		}
	}
	
	[MenuItem("Assets/Scale Point")]
	public static void ScalePoint()
	{
		UnityEngine.Object obj = Selection.activeObject;
		if(obj is Texture2D)
		{
			string path = AssetDatabase.GetAssetPath(obj);
			string newPath = path + "_scaled_point.png";
			
			Scale(ScaleType.Point,path,newPath);
		}
	}
	
	public static void Scale(ScaleType _type, string _path, string _target)
	{
		string path = _path;
		string newPath = _target;
		//
		// load the texture from the disc by 
		// setting the importer to use RGBA32 and ensure the texture is readable
		//
		
		TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
		TextureImporterSettings orgSettings = new TextureImporterSettings();
		
		ti.ReadTextureSettings(orgSettings);
		
		ti.textureFormat = TextureImporterFormat.RGBA32;
		ti.isReadable = true;
		AssetDatabase.ImportAsset(path);
		
		// get the pixels
		Texture2D originalTexture = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;	
		Color32[] c1 = originalTexture.GetPixels32();
		int orgWidth = originalTexture.width;
		int orgHeight = originalTexture.height;
		originalTexture = null;
		
		//
		// restore original import settings
		//
		
		ti = AssetImporter.GetAtPath(path) as TextureImporter;
		ti.SetTextureSettings(orgSettings);
		AssetDatabase.ImportAsset(path);
		
		
		// arbitrary target size
		int width = 433;
		//preserve aspect ratio
		int height = Mathf.RoundToInt((width / (float)orgWidth) * orgHeight); 
		
		
		
		//actually scale the data
		switch(_type)
		{
			case ScaleType.Lanczos: c1 = ScaleUnityTexture.ScaleLanczos(c1, orgWidth, width, height ); break;
			case ScaleType.Linear: c1 = ScaleUnityTexture.ScaleLinear(c1, orgWidth, width, height ); break;
			case ScaleType.Point: c1 = ScaleUnityTexture.ScalePoint(c1, orgWidth, width,height); break;
		}
		
		
		// create target texture
		Texture2D outT = new Texture2D(width, height, TextureFormat.RGBA32,false);
		// set the pixels
		outT.SetPixels32(c1);
		// encode the texture
		byte[] outBytes = outT.EncodeToPNG();
		
		// save texture
		System.IO.File.WriteAllBytes(newPath, outBytes);
		AssetDatabase.ImportAsset(newPath);
		
		// Apply the same import settings for this texture
		ti = AssetImporter.GetAtPath(newPath) as TextureImporter;
		ti.SetTextureSettings(orgSettings);
			
		AssetDatabase.ImportAsset(newPath);
		
	}
}
