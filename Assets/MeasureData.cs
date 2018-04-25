public class MeasureData
{
    private int id;
    private int wavId;
    private float audioTime;

    NDISensorData[] sensors;



    public MeasureData(int id, int wavId, float audioTime, NDISensorData[] sensors)
    {
        this.Id = id;
        this.WavId = wavId;
        this.AudioTime = audioTime;
        this.Sensors = sensors;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public int WavId
    {
        get
        {
            return wavId;
        }

        set
        {
            wavId = value;
        }
    }

    public float AudioTime
    {
        get
        {
            return audioTime;
        }

        set
        {
            audioTime = value;
        }
    }

    public NDISensorData[] Sensors
    {
        get
        {
            return sensors;
        }

        set
        {
            sensors = value;
        }
    }
}