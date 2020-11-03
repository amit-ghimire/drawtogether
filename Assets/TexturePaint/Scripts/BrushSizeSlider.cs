using UnityEngine;
using UnityEngine.UI;

public class BrushSizeSlider : MonoSingleton<BrushSizeSlider>
{
    public int BrushSize { get; private set; }

    private void Start()
    {
        BrushSize = 5;
    }

    public void ChangeBrushSize(float value) 
    {
        BrushSize = (int)value;
    }
}
