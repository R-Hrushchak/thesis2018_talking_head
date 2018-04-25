using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NDIPlayer : MonoBehaviour {
    public NDILoader loader;

    // Head (reference)
    public GameObject refObject;
    private Transform refInitialTransform;
    private Quaternion refInitialRotation;

    // Jaw
    public GameObject jawObject;
    private Transform jawInitialTransform;
    private Quaternion jawInitialRotation;

    // Tongue back
    public GameObject tongueBackObject;
    private Transform tongueBackInitialTransform;
    private Quaternion tongueBackInitialRotation;

    // Tongue middle
    public GameObject tongueMidObject;
    private Transform tongueMidInitialTransform;
    private Quaternion tongueMidInitialRotation;

    // Tongue tip
    public GameObject tongueTipObject;
    private Transform tongueTipInitialTransform;
    private Quaternion tongueTipInitialRotation;

    // Lip corner left
    public GameObject lipLObject;
    private Transform lipLInitialTransform;
    private Quaternion lipLInitialRotation;
    
    // Lip corner right
    public GameObject lipRObject;
    private Transform lipRInitialTransform;
    private Quaternion lipRInitialRotation;

    // Lip half left
    public GameObject lipLowerHalfLeftObject;
    private Transform lipLowerHalfLeftInitialTransform;

    // Lip half right
    public GameObject lipLowerHalfRightObject;
    private Transform lipLowerHalfRightInitialTransform;

    // Lip upper-half left
    public GameObject lipUpperHalfLeftObject;
    private Transform lipUpperHalfLeftInitialTransform;

    // Lip upper-half right
    public GameObject lipUpperHalfRightObject;
    private Transform lipUpperHalfRightInitialTransform;

    private List<MeasureData> sensorDataList;
    private AudioSource audio;

    // Sensors Configuration
    public int S_REF_ID = 14; // Reference
    public int S_JAW_ID = 5;  // Jaw
    public int S_LIP_L_ID = 3;  // Lip corner L
    public int S_LIP_R_ID = 4;  // Lip corner R
    public int S_TTIP_ID = 2;  // Tongue tip
    public int S_TMID_ID = 1;  // Tongue mid
    public int S_TBACK_ID = 0;  // Tongue back

    // Use this for initialization
    void Start()
    {
        refInitialTransform = refObject.transform;
        jawInitialTransform = jawObject.transform;
        tongueBackInitialTransform = tongueBackObject.transform;
        tongueMidInitialTransform = tongueMidObject.transform;
        tongueTipInitialTransform = tongueTipObject.transform;
        lipLInitialTransform = lipLObject.transform;
        lipRInitialTransform = lipRObject.transform;
        lipLowerHalfLeftInitialTransform = lipLowerHalfLeftObject.transform;
        lipLowerHalfRightInitialTransform = lipLowerHalfRightObject.transform;
        lipUpperHalfLeftInitialTransform = lipUpperHalfLeftObject.transform;
        lipUpperHalfRightInitialTransform = lipUpperHalfRightObject.transform;
    }

    public void Play () {
        if (loader == null)
        {
            return;
        }
    
        sensorDataList = loader.SensorDataList;

        Debug.Log("Sensor data count: " + sensorDataList.Count);

        audio = GetComponent<AudioSource>();
        audio.clip = loader.audioClip;

        StartCoroutine(PlayData());
    }

    IEnumerator PlayData()
    {
        // Sensor initial data
        NDISensorData sensorRef = sensorDataList[0].Sensors[S_REF_ID];          // Head
        NDISensorData sensorJaw = sensorDataList[0].Sensors[S_JAW_ID];          // Jaw
        NDISensorData sensorTongueBack = sensorDataList[0].Sensors[S_TBACK_ID]; // Tongue back
        NDISensorData sensorTongueMid = sensorDataList[0].Sensors[S_TMID_ID];   // Tongue middle
        NDISensorData sensorTongueTip = sensorDataList[0].Sensors[S_TTIP_ID];   // Tongue tip
        NDISensorData sensorLipL = sensorDataList[0].Sensors[S_LIP_L_ID];       // Lip left
        NDISensorData sensorLipR = sensorDataList[0].Sensors[S_LIP_R_ID];       // Lip right

        // Set initial positions

        // Head
        Vector3 refInitialPosition = refInitialTransform.localPosition;
        Vector3 refInitialPositionFromSensor = new Vector3(sensorRef.X, sensorRef.Y, sensorRef.Z);

        // Jaw
        Vector3 jawInitialPosition = jawInitialTransform.localPosition;
        Vector3 jawInitialPositionFromSensor = new Vector3(sensorJaw.X, sensorJaw.Y, sensorJaw.Z);

        // Tongue back
        Vector3 tongueBackInitialPosition = tongueBackInitialTransform.localPosition;
        Vector3 tongueBackInitialPositionFromSensor = new Vector3(sensorTongueBack.X, sensorTongueBack.Y, sensorTongueBack.Z);

        // Tongue middle
        Vector3 tongueMidInitialPosition = tongueMidInitialTransform.localPosition;
        Vector3 tongueMidInitialPositionFromSensor = new Vector3(sensorTongueMid.X, sensorTongueMid.Y, sensorTongueMid.Z);

        // Tongue tip
        Vector3 tongueTipInitialPosition = tongueTipInitialTransform.localPosition;
        Vector3 tongueTipInitialPositionFromSensor = new Vector3(sensorTongueTip.X, sensorTongueTip.Y, sensorTongueTip.Z);

        // Lip corner left
        Vector3 lipLInitialPosition = lipLInitialTransform.localPosition;
        Vector3 lipLInitialPositionFromSensor = new Vector3(sensorLipL.X, sensorLipL.Y, sensorLipL.Z);

        // Lip corner right
        Vector3 lipRInitialPosition = lipRInitialTransform.localPosition;
        Vector3 lipRInitialPositionFromSensor = new Vector3(sensorLipR.X, sensorLipR.Y, sensorLipR.Z);

        // Lip lower-half left
        Vector3 lipLowerHalfLeftInitialPosition = lipLowerHalfLeftInitialTransform.localPosition;

        // Lip lower-half right
        Vector3 lipLowerHalfRightInitialPosition = lipLowerHalfRightInitialTransform.localPosition;

        // Lip upper-half left
        Vector3 lipUpperHalfLeftInitialPosition = lipUpperHalfLeftInitialTransform.localPosition;

        // Lip upper-half right
        Vector3 lipUpperHalfRightInitialPosition = lipUpperHalfRightInitialTransform.localPosition;

        // set end

        // Set initial rotations

        // Head
        refInitialRotation = refInitialTransform.localRotation;
        Quaternion refInitialRotationFromSensor = new Quaternion(sensorRef.Qx, sensorRef.Qy, sensorRef.Qz, sensorRef.Q0); 
        
        // Jaw
        jawInitialRotation = jawInitialTransform.localRotation;
        Quaternion jawInitialRotationFromSensor = new Quaternion(sensorJaw.Qx, sensorJaw.Qy, sensorJaw.Qz, sensorJaw.Q0);

        // Tongue back
        tongueBackInitialRotation = tongueBackInitialTransform.localRotation;
        Quaternion tongueBackInitialRotationFromSensor = new Quaternion(sensorTongueBack.Qx, sensorTongueBack.Qy, sensorTongueTip.Qz, sensorTongueTip.Q0);

        // Tongue middle
        tongueMidInitialRotation = tongueMidInitialTransform.localRotation;
        Quaternion tongueMidInitialRotationFromSensor = new Quaternion(sensorTongueMid.Qx, sensorTongueMid.Qy, sensorTongueMid.Qz, sensorTongueMid.Q0);

        // Tongue tip
        tongueTipInitialRotation = tongueTipInitialTransform.localRotation;
        Quaternion tongueTipInitialRotationFromSensor = new Quaternion(sensorTongueTip.Qx, sensorTongueTip.Qy, sensorTongueTip.Qz, sensorTongueTip.Q0);

        // set end

        // Play audio track
        audio.Play();

        foreach (MeasureData data in sensorDataList)
        {
            // Audio sync with data sensors (some data will be skipped)
            if (audio.timeSamples > data.WavId) continue;

            // Sensor sync data
            sensorRef = data.Sensors[S_REF_ID];         // Head
            sensorJaw = data.Sensors[S_JAW_ID];         // Jaw
            sensorTongueBack = data.Sensors[S_TBACK_ID];  // Tongue back
            sensorTongueMid = data.Sensors[S_TMID_ID];  // Tongue middle
            sensorTongueTip = data.Sensors[S_TTIP_ID];  // Tongue tip
            sensorLipL = data.Sensors[S_LIP_L_ID];      // Lip left
            sensorLipR = data.Sensors[S_LIP_R_ID];      // Lip right

            // Sync positions

            // Head
            Vector3 refPosition = new Vector3(sensorRef.X, sensorRef.Y, sensorRef.Z);
            Vector3 refPositionDelta = (refPosition - refInitialPositionFromSensor).normalized;
            Vector3 refTargetPosition = refInitialPosition + Vector3.Scale(refPositionDelta, new Vector3(0.2f, 0.2f, 0.2f));
            refObject.transform.localPosition = refTargetPosition;

            // Jaw
            Vector3 jawPosition = new Vector3(sensorJaw.X, sensorJaw.Y, sensorJaw.Z);
            Vector3 jawPositionDelta = (jawPosition - jawInitialPositionFromSensor).normalized;
            Vector3 jawTargetPosition = jawInitialPosition + Vector3.Scale(jawPositionDelta, new Vector3(0.2f, 0.2f, 0.2f));
            jawObject.transform.localPosition = jawTargetPosition;

            // Lip corner left
            Vector3 lipLPosition = new Vector3(sensorLipL.X, sensorLipL.Y, sensorLipL.Z);
            Vector3 lipLPositionDelta = (lipLPosition - lipLInitialPositionFromSensor).normalized;
            Vector3 lipLTargetPosition = lipLInitialPosition + Vector3.Scale(lipLPositionDelta, new Vector3(0.15f, 0.15f, 0.15f));
            lipLObject.transform.localPosition = lipLTargetPosition;

            // Lip corner right
            Vector3 lipRPosition = new Vector3(sensorLipR.X, sensorLipR.Y, sensorLipR.Z);
            Vector3 lipRPositionDelta = (lipRPosition - lipRInitialPositionFromSensor).normalized;
            Vector3 lipRTargetPosition = lipRInitialPosition + Vector3.Scale(lipRPositionDelta, new Vector3(0.15f, 0.15f, 0.15f));
            lipRObject.transform.localPosition = lipRTargetPosition;

            // Lip lower-half left
            Vector3 lipLowerHalfLeftTargetPosition = lipLowerHalfLeftInitialPosition + Vector3.Scale(lipLPositionDelta, new Vector3(0.15f, 0.15f, 0.15f));
            lipLowerHalfLeftObject.transform.localPosition = lipLowerHalfLeftTargetPosition;

            // Lip lower-half right
            Vector3 lipLowerHalfRightTargetPosition = lipLowerHalfRightInitialPosition + Vector3.Scale(lipRPositionDelta, new Vector3(0.15f, 0.15f, 0.15f));
            lipLowerHalfRightObject.transform.localPosition = lipLowerHalfRightTargetPosition;

            // Lip upper-half left
            Vector3 lipUpperHalfLeftTargetPosition = lipUpperHalfLeftInitialPosition + Vector3.Reflect(Vector3.Scale(lipLPositionDelta, new Vector3(0.15f, 0.15f, 0.15f)), Vector3.right);
            lipUpperHalfLeftObject.transform.localPosition = lipUpperHalfLeftTargetPosition;

            // Lip upper-half right
            Vector3 lipUpperHalfRightTargetPosition = lipUpperHalfRightInitialPosition + Vector3.Reflect(Vector3.Scale(lipRPositionDelta, new Vector3(0.15f, 0.15f, 0.15f)), Vector3.right);
            lipUpperHalfRightObject.transform.localPosition = lipUpperHalfRightTargetPosition;

            // sync end

            // Sync rotations

            // Head
            Quaternion refRotation = new Quaternion(sensorRef.Qx, sensorRef.Qy, sensorRef.Qz, sensorRef.Q0);
            Quaternion refTargetRotation = refInitialRotation * (refInitialRotationFromSensor * Quaternion.Inverse(refRotation));
            refObject.transform.localRotation = refTargetRotation;
            //refObject.GetComponent<InterpolatedRotation>().targetRotation = refTargetRotation; // interpolated

            // Jaw
            Quaternion jawRotation = new Quaternion(sensorJaw.Qx, sensorJaw.Qy, sensorJaw.Qz, sensorJaw.Q0);
            Quaternion jawTargetRotation = jawInitialRotation * (jawInitialRotationFromSensor * Quaternion.Inverse(jawRotation));
            jawObject.transform.localRotation = jawTargetRotation;
            //jawObject.GetComponent<InterpolatedRotation>().targetRotation = jawTargetRotation; // interpolated

            // Tongue back
            Quaternion tongueBackRotation = new Quaternion(sensorTongueBack.Qx, sensorTongueBack.Qy, sensorTongueBack.Qz, sensorTongueTip.Q0);
            Quaternion tongueBackTargetRotation = tongueBackInitialRotation * (tongueBackInitialRotationFromSensor * Quaternion.Inverse(tongueBackRotation));
            tongueBackObject.transform.localRotation = tongueBackTargetRotation;

            // Tongue middle
            Quaternion tongueMidRotation = new Quaternion(sensorTongueMid.Qx, sensorTongueMid.Qy, sensorTongueMid.Qz, sensorTongueMid.Q0);
            Quaternion tongueMidTargetRotation = tongueMidInitialRotation * (tongueMidInitialRotationFromSensor * Quaternion.Inverse(tongueMidRotation));
            tongueMidObject.transform.localRotation = tongueMidTargetRotation;

            // Tongue tip
            Quaternion tongueTipRotation = new Quaternion(sensorTongueTip.Qx, sensorTongueTip.Qy, sensorTongueTip.Qz, sensorTongueTip.Q0);
            Quaternion tongueTipTargetRotation = tongueTipInitialRotation * (tongueTipInitialRotationFromSensor * Quaternion.Inverse(tongueTipRotation));
            tongueTipObject.transform.localRotation = tongueTipTargetRotation;

            // sync end

            yield return null;
        }
    }
}
