using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PointCloudExporter;
using System.IO;
using System.Linq;

public class BuildPointCloudScriptableObject : MonoBehaviour {
    [Header("PT Cloud Build")]
    public bool BuildPoints;
    public PtCloud ActivePtCloud;
    public Vector3 AlignLocation;
    public Vector3 AlignRotation;
    public float PointRenderSize;
    public string FilePath;
    public string PNGName;
    [Range(1,100)]
    public int LODAmt;
     
    ComputeBuffer _pointBuffer;
    public const int elementSize = sizeof(float) * 4;
    private SimpleImporter lidarPts;
    private List<MeshInfos> _allMesh;
    private Point[] _pointData;
    public int pointCount
    {
        get { return _pointData.Length; }
    }

    public void Start()
    {
        lidarPts = SimpleImporter.Instance;
        
        if (LODAmt == 0)
        {
            LODAmt = 10;
        }
        Vector3[] allVertices;
        Color[] allColors;
        if (BuildPoints)
        {
            //this will replace all data in the passed scriptable object
            string f = Application.streamingAssetsPath + "\\" + FilePath;
            _allMesh = lidarPts.Load(f, true, LODAmt);
            int tVertices = _allMesh.Sum(x => x.vertexCount);
            allVertices = new Vector3[tVertices];
            allColors = new Color[tVertices];
            ActivePtCloud.AlignLocation = AlignLocation;
            ActivePtCloud.AlignRotation = AlignRotation;
            ActivePtCloud.PointRenderSize = PointRenderSize;
            ActivePtCloud.TotalPts = tVertices;
            ActivePtCloud.Points = new Vector3[tVertices];
            ActivePtCloud.Colors = new Color[tVertices];
            ActivePtCloud.LODAmt = LODAmt;

            int runnintCount = 0;
            for (int i = 0; i < _allMesh.Count; i++)
            {
                for (int j = 0; j < _allMesh[i].vertexCount; j++)
                {
                    allVertices[runnintCount] = _allMesh[i].vertices[j];
                    allColors[runnintCount] = _allMesh[i].colors[j];
                    ActivePtCloud.Points[runnintCount] = _allMesh[i].vertices[j];
                    ActivePtCloud.Colors[runnintCount] = _allMesh[i].colors[j];
                    runnintCount++;
                }
            }
            ActivePtCloud.BuildSerializedData(allVertices, allColors);
        }
        else
        {
            //use existing
            ActivePtCloud.OpenSerializedData();
            allVertices = new Vector3[ActivePtCloud.Points.Length];
            allColors = new Color[ActivePtCloud.Points.Length];
            for (int i = 0; i <ActivePtCloud.Points.Length; i++)
            {
                allVertices[i] = ActivePtCloud.Points[i];
                allColors[i] = ActivePtCloud.Colors[i];
            }

        }
        Debug.Log("Size: " + allVertices.Length);
        
        //ActivePtCloud.Initialize(allVertices, allColors);
        //Initialize(allVertices, allColors);
        GetComponent<PtRenderer>().DrawPts();
        this.transform.position = ActivePtCloud.AlignLocation;
        this.transform.rotation = Quaternion.Euler(ActivePtCloud.AlignRotation);
    }    
    //static uint EncodeColor(Color c)
    //{
    //    const float kMaxBrightness = 16;

    //    var y = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
    //    y = Mathf.Clamp(Mathf.Ceil(y * 255 / kMaxBrightness), 1, 255);

    //    var rgb = new Vector3(c.r, c.g, c.b);
    //    rgb *= 255 * 255 / (y * kMaxBrightness);

    //    return ((uint)rgb.x) |
    //           ((uint)rgb.y << 8) |
    //           ((uint)rgb.z << 16) |
    //           ((uint)y << 24);
    //}
   
    //public void Initialize(List<Vector3> positions, List<Color32> colors)
    //{
    //    _pointData = new Point[positions.Count];
    //    for (var i = 0; i < _pointData.Length; i++)
    //    {
    //        _pointData[i] = new Point
    //        {
    //            position = positions[i],
    //            color = EncodeColor(colors[i])
    //        };
    //    }
    //}
    //public void Initialize(Vector3[] positions, Color[] colors)
    //{
    //    _pointData = new Point[positions.Length];
    //    for(var i = 0; i < _pointData.Length; i++)
    //    {
    //        _pointData[i] = new Point {
    //            position = positions[i] ,
    //            color = EncodeColor(colors[i])
    //        };
    //    }
    //}
   
    //public ComputeBuffer computeBuffer
    //{
    //    get
    //    {
    //        if (_pointBuffer == null)
    //        {
    //            _pointBuffer = new ComputeBuffer(pointCount, elementSize);
    //            _pointBuffer.SetData(_pointData);
    //        }
    //        return _pointBuffer;
    //    }
    //}
    //void OnDisable()
    //{
    //    if (_pointBuffer != null)
    //    {
    //        _pointBuffer.Release();
    //        _pointBuffer = null;
    //    }
    //}

}

