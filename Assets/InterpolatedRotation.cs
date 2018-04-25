using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolatedRotation : MonoBehaviour {

    public Quaternion targetRotation;

    public float speed = 0.85F;

    // Update is called once per frame
    void Update () {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.time * speed);
    }
}
