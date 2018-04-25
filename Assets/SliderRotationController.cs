using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotationController : MonoBehaviour {

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
        Vector3 temp = transform.localRotation.eulerAngles;
        temp.x = sliderValueX;
        transform.localRotation = Quaternion.Euler(temp);
    }

    public void OnSliderChangedY()
    {
        sliderValueY = minY + (maxY - minY) * sliderY.value;
        Vector3 temp = transform.localRotation.eulerAngles;
        temp.y = sliderValueY;
        transform.localRotation = Quaternion.Euler(temp);
    }

    public void OnSliderChangedZ()
    {
        sliderValueZ = minZ + (maxZ - minZ) * sliderZ.value;
        Vector3 temp = transform.localRotation.eulerAngles;
        temp.z = sliderValueZ;
        transform.localRotation = Quaternion.Euler(temp);
    }

}
