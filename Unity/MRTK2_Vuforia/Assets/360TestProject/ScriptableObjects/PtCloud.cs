using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[CreateAssetMenu(fileName = "PtCloud", menuName = "VMASC/PTSData", order = 1)]
public class PtCloud : ScriptableObject
{
    [Tooltip("Used for Alignment")]
    public Vector3 AlignLocation;
    [Tooltip("Used for Rotation")]
    public Vector3 AlignRotation;
    public int TotalPts;
    public string JSONFileLocation ="";
    private PTCloudData _serializedData;
    private float _pointRenderSize;
    private int _LODAmt;
    private Vector3[] points;
    private Color[] colors;
    private Point[] _pointData;
    public const int elementSize = sizeof(float) * 4;
    private ComputeBuffer _pointBuffer;

    public void BuildSerializedData(Vector3[] positions, Color[] colors)
    {
        _serializedData = new PTCloudData();
        _serializedData._TotalPts = positions.Length;
        _serializedData._AlignRotation = AlignRotation;
        _serializedData._AlignTransform = AlignLocation;
        _serializedData._colors = new Color[_serializedData._TotalPts];
        _serializedData._points = new Vector3[_serializedData._TotalPts];
        _serializedData._UColors = new uint[_serializedData._TotalPts];
        _pointData = new Point[positions.Length];
        
        for (var i = 0; i < positions.Length; i++)
        {
            _serializedData._colors[i] = colors[i];
            _serializedData._points[i] = positions[i];
            _serializedData._UColors[i] = EncodeColor(colors[i]);
            
            _pointData[i] = new Point
            {
                position = positions[i],
                color = EncodeColor(colors[i])
            };
        }
        //store serialized data
        string json = JsonUtility.ToJson(_serializedData);
        string file = Path.Combine(Application.streamingAssetsPath, JSONFileLocation);
        File.WriteAllText(file, json);
    }
    public void OpenSerializedData()
    {
        string file = Path.Combine(Application.streamingAssetsPath, JSONFileLocation);
        if (File.Exists(file))
        {
            string dataAsJson = File.ReadAllText(file);
            _serializedData = JsonUtility.FromJson<PTCloudData>(dataAsJson);
        }
        TotalPts = _serializedData._TotalPts;
        AlignLocation = _serializedData._AlignTransform;
        AlignRotation = _serializedData._AlignRotation;
        Initialize(_serializedData._points, _serializedData._colors);
    }
    public void Initialize(Vector3[] positions, Color[] colors)
    {
        _pointData = new Point[positions.Length];
        for (var i = 0; i < _pointData.Length; i++)
        {
            _pointData[i] = new Point
            {
                position = positions[i],
                color = EncodeColor(colors[i])
            };
        }
    }
    public int LODAmt
    {
        get { return _LODAmt; }
        set
        {
            _LODAmt = value;
        }
    }
    public Vector3[] Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
        }
    }

    public Color[] Colors
    {
        get
        {
            return colors;
        }

        set
        {
            colors = value;
        }
    }

    public float PointRenderSize
    {
        get
        {
            return _pointRenderSize;
        }

        set
        {
            _pointRenderSize = value;
        }
    }
    public int PointCount
    {
        get { return _pointData.Length; }
    }
    public ComputeBuffer PTComputeBuffer
    {
        get
        {
            if (_pointBuffer == null)
            {
                _pointBuffer = new ComputeBuffer(PointCount, elementSize);
                _pointBuffer.SetData(_pointData);
            }
            return _pointBuffer;
        }
    }
    static uint EncodeColor(Color c)
    {
        const float kMaxBrightness = 16;

        var y = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        y = Mathf.Clamp(Mathf.Ceil(y * 255 / kMaxBrightness), 1, 255);

        var rgb = new Vector3(c.r, c.g, c.b);
        rgb *= 255 * 255 / (y * kMaxBrightness);

        return ((uint)rgb.x) |
               ((uint)rgb.y << 8) |
               ((uint)rgb.z << 16) |
               ((uint)y << 24);
    }
    void OnDisable()
    {
        if (_pointBuffer != null)
        {
            _pointBuffer.Release();
            _pointBuffer = null;
        }
    }
}
[System.Serializable]
struct Point
{
    public Vector3 position;
    public uint color;
}
[System.Serializable]
public class PTCloudData
{
    public int _TotalPts;
    public Vector3[] _points;
    public Color[] _colors;
    public uint[] _UColors;
    public Vector3 _AlignRotation;
    public Vector3 _AlignTransform;
}
