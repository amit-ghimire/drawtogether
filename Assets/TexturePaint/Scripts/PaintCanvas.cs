using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public static Texture2D Texture { get; private set; }
    
    public static byte[] GetAllTextureData() 
    {
        return Texture.GetRawTextureData();
    }

    // Start is called before the first frame update
    void Start()
    {
        PrepareTemporaryTexture();   
    }

    /// <summary>
    /// Create a copy of texture in memory for r/w
    /// </summary>
    private void PrepareTemporaryTexture() 
    {
        Texture = (Texture2D)GameObject.Instantiate(GetComponent<Renderer>().material.mainTexture);
        GetComponent<Renderer>().material.mainTexture = Texture;
    }

    /// <summary>
    /// Set texture data from byte array
    /// </summary>
    /// <param name="textureData">The byte array of texture data to load</param>
    internal static void SetAllTextureData(byte[] textureData) 
    {
        Texture.LoadRawTextureData(textureData);
        Texture.Apply();
    }
}
