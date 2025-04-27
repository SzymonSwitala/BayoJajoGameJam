using UnityEngine;

public class ChangeHUE : MonoBehaviour
{
    public Material material;
    public float hueShift = 0.1f;
    public void Change()
    {
        if (material.HasProperty("_Color"))
        {
            Color color = material.color;
            Color.RGBToHSV(color, out float h, out float s, out float v);
            h += hueShift;
            if (h > 1) h -= 1f;
            color = Color.HSVToRGB(h, s, v);
            material.color = color;
        }
    }
}
