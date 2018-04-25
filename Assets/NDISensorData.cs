public class NDISensorData
{
    private int id;
    private int status;

    private float x;
    private float y;
    private float z;

    private float q0;
    private float qx;
    private float qy;
    private float qz;

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

    public int Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }

    public float Z
    {
        get
        {
            return z;
        }

        set
        {
            z = value;
        }
    }

    public float Q0
    {
        get
        {
            return q0;
        }

        set
        {
            q0 = value;
        }
    }

    public float Qx
    {
        get
        {
            return qx;
        }

        set
        {
            qx = value;
        }
    }

    public float Qy
    {
        get
        {
            return qy;
        }

        set
        {
            qy = value;
        }
    }

    public float Qz
    {
        get
        {
            return qz;
        }

        set
        {
            qz = value;
        }
    }

    public NDISensorData(int id, int status, float x, float y, float z, float q0, float qx, float qy, float qz)
    {
        this.Id = id;
        this.Status = status;
        this.X = x;
        this.Y = y;
        this.Z = z;
        this.Q0 = q0;
        this.Qx = qx;
        this.Qy = qy;
        this.Qz = qz;
    }

    override
    public string ToString()
    {
        return string.Format("id: {0} x: {1} y: {2} z: {3} qX: {4} qY: {5} qZ: {6} q0: {6}", id, x, y, z, qx, qy, qz, q0);
    }
}