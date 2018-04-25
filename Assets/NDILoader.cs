using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using UnityEngine.Networking;
using Crosstales.FB;

public class NDILoader : MonoBehaviour
{
    static List<MeasureData> sensorsDataList;

    public List<MeasureData> SensorDataList
    {
        get
        {
            return sensorsDataList;
        }
    }

    public AudioClip audioClip;

    // Use this for initialization
    void Start()
    {
        sensorsDataList = new List<MeasureData>();
        string extensions = "";
        string path = FileBrowser.OpenSingleFile("Open File", "", extensions);
        StartCoroutine(LoadData(path));
    }

    private bool ParseData(string[] data)
    {
        int measureId;
        float audioTime;
        int wavId;

        NDISensorData[] sensors = new NDISensorData[15];
        int status;
        float x;
        float y;
        float z;
        float q0;
        float qx;
        float qy;
        float qz;

        // Get measure data
        float.TryParse(data[0], out audioTime);
        int.TryParse(data[1], out measureId);
        int.TryParse(data[2], out wavId);

        // Get sensors data
        int sensorsCount = GetNumberOfSensorsAvailable(data);
        for (int i = 0; i < sensorsCount; i++)
        {
            int.TryParse(data[4 + (i * 9)], out status);
            float.TryParse(data[5 + (i * 9)], out x);
            float.TryParse(data[6 + (i * 9)], out y);
            float.TryParse(data[7 + (i * 9)], out z);
            float.TryParse(data[8 + (i * 9)], out q0);
            float.TryParse(data[9 + (i * 9)], out qx);
            float.TryParse(data[10 + (i * 9)], out qy);
            float.TryParse(data[11 + (i * 9)], out qz);
            sensors[i] = new NDISensorData(i, status, x, y, z, q0, qx, qy, qz);
        }

        MeasureData item = new MeasureData(measureId, wavId, audioTime, sensors);
        sensorsDataList.Add(item);
        return true;
    }

    private int GetNumberOfSensorsAvailable(string[] data)
    {
        return (data.Length - 3) / 9;
    }

    IEnumerator LoadData(string fileName)
    {
        string audioClipPath = fileName.Substring(0, fileName.Length - 3 - 1) + ".wav";
        yield return StartCoroutine(LoadAudioClip(audioClipPath));
        
        try
        {
            string line;
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                // Skip the first line
                theReader.ReadLine();

                // Read the data from sensors
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        string[] entries = line.Split('\t');
                        if (entries.Length > 0)
                            ParseData(entries);
                    }
                } while (line != null);

                theReader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    IEnumerator LoadAudioClip(string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + path, AudioType.WAV))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip = DownloadHandlerAudioClip.GetContent(www);
            }
        }
    }
}