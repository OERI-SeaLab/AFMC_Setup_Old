using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointCloudExporter
{
	public class MeshInfos
	{
		public Vector3[] vertices;
		public Vector3[] normals;
        public int[] intensity;
		public Color[] colors;
		public int vertexCount;
		public Bounds bounds;
	}
}
