using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtRenderer : MonoBehaviour
{
    #region Editable attributes

   
    public PtCloud _sourceData;
    //public Camera MainCam;
    [SerializeField] Color _pointTint = new Color(0.5f, 0.5f, 0.5f, 1);

    public Color pointTint
    {
        get { return _pointTint; }
        set { _pointTint = value; }
    }

    [SerializeField] float _pointSize = 0.05f;

    public float pointSize
    {
        get { return _pointSize; }
        set { _pointSize = value; }
    }

    #endregion

    #region Public properties (nonserialized)

    public ComputeBuffer sourceBuffer { get; set; }

    #endregion

    #region Internal resources

    public Shader _pointShader;
    public Shader _diskShader;

    #endregion

    #region Private objects

    Material _pointMaterial;
    Material _diskMaterial;

    #endregion

    #region MonoBehaviour implementation

    //private void Start()
    //{
    //    if (MainCam == null)
    //    {
    //        try
    //        {
    //            MainCam = Camera.main;
    //        }
    //        catch (Exception e)
    //        {
    //            Debug.Log("Camera Error Msg: " + e.Message);
    //        }
          
    //    }
    //}

    void OnDestroy()
    {
        if (_pointMaterial != null)
        {
            if (Application.isPlaying)
            {
                Destroy(_pointMaterial);
                Destroy(_diskMaterial);
            }
            else
            {
                DestroyImmediate(_pointMaterial);
                DestroyImmediate(_diskMaterial);
            }
        }
    }
    private void OnRenderObject()
    {
        DrawPts();
    }
    public void DrawPts()
    {
        
        
        // We need a source data or an externally given buffer.
        if (_sourceData == null && sourceBuffer == null) return;
        
        _pointSize = Mathf.Max(0, _pointSize);
        // Check the camera condition.
        //var camera = MainCam;
       
//        if ((camera.cullingMask & (1 << gameObject.layer)) == 0) return;
     //   if (camera.name == "Preview Scene Camera") return;

        // TODO: Do view frustum culling here.

        // Lazy initialization
        //Debug.Log("Made it here");
        if (_pointMaterial == null)
        {
            //Debug.Log("Pt mat == null");
            _pointMaterial = new Material(_pointShader);
            _pointMaterial.hideFlags = HideFlags.DontSave;
            _pointMaterial.EnableKeyword("_COMPUTE_BUFFER");

            _diskMaterial = new Material(_diskShader);
            _diskMaterial.hideFlags = HideFlags.DontSave;
            _diskMaterial.EnableKeyword("_COMPUTE_BUFFER");
        }

        // Use the external buffer if given any.
        var pointBuffer = sourceBuffer != null ?
            sourceBuffer : _sourceData.PTComputeBuffer;

        if (_pointSize == 0)
        {
            //Debug.Log("Pt size == 0");
            _pointMaterial.SetPass(0);
            _pointMaterial.SetColor("_Tint", _pointTint);
            _pointMaterial.SetMatrix("_Transform", transform.localToWorldMatrix);
            _pointMaterial.SetBuffer("_PointBuffer", pointBuffer);
            Graphics.DrawProceduralNow(MeshTopology.Points, pointBuffer.count, 1);
        }
        else
        {
            //Debug.Log("pt size !=0");
            _diskMaterial.SetPass(0);
            _diskMaterial.SetColor("_Tint", _pointTint);
            _diskMaterial.SetMatrix("_Transform", transform.localToWorldMatrix);
            _diskMaterial.SetBuffer("_PointBuffer", pointBuffer);
            _diskMaterial.SetFloat("_PointSize", pointSize);
            Graphics.DrawProceduralNow(MeshTopology.Points, pointBuffer.count, 1);
            //Debug.Log("Count ptBuffer " + pointBuffer.count);
        }
    }

    #endregion
}
