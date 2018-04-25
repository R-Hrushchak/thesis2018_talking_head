using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPositionController : MonoBehaviour
{
    public float minX;
    public float maxX;
    public Slider sliderX;

    public float minY;
    public float maxY;
    public Slider sliderY;

    public float minZ;
    public float maxZ;
    public Slider sliderZ;

    float sliderValueX;
    float sliderValueY;
    float sliderValueZ;

    public void OnSliderChangedX()
    {
        sliderValueX = minX + (maxX - minX) * sliderX.value;
        Vector3 temp = transform.localPosition;
        temp.x = sliderValueX;
        transform.localPosition = temp;
    }

    public void OnSliderChangedY()
    {
        sliderValueY = minY + (maxY - minY) * sliderY.value;
        Vector3 temp = transform.localPosition;
        temp.y = sliderValueY;
        transform.localPosition = temp;
    }

    public void OnSliderChangedZ()
    {
        sliderValueZ = minZ + (maxZ - minZ) * sliderZ.value;
        Vector3 temp = transform.localPosition;
        temp.z = sliderValueZ;
        transform.localPosition = temp;
    }

}
