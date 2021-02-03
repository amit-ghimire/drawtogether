using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedTexturePaint : TexturePaint
{
    public static Texture2D Texture { get; private set; }
    private void Start()
    {
        Init();
        Texture = meshGameobject.GetComponent<Renderer>().material.mainTexture as Texture2D;
    }

    public static byte[] GetAllTextureData()
    {
        return Texture.GetRawTextureData();
    }

    internal static void SetAllTextureData(byte[] textureData)
    {
        Texture.LoadRawTextureData(textureData);
        Texture.Apply();
    }
}
