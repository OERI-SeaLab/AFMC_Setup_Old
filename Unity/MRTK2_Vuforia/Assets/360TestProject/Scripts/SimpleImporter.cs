using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using UnityEngine;

namespace PointCloudExporter
{
	public class SimpleImporter
	{
		// Singleton
		private static SimpleImporter instance;
		private SimpleImporter () {}
		public static SimpleImporter Instance {
			get {
				if (instance == null) {
					instance = new SimpleImporter();
				}
				return instance;
			}
		}
        public List<MeshInfos> Load (string filePath, bool ptsFile,int lod=10,int maximumVertex =65000)
        {
            Debug.Log("File: " + filePath);
            
            if (ptsFile)
            {
                int levelOfDetails = 1;

                List<MeshInfos> AllMesh = new List<MeshInfos>();
                if (File.Exists(filePath))
                {

                    
                    using (StreamReader reader = new StreamReader(filePath, Encoding.ASCII))
                    {
                        //int length = (int)reader.BaseStream.Length;
                        //Debug.Log("Num lines: " + length);
                        int index = 0;
                        string numVertex = reader.ReadLine();
                        int vertexCount = int.Parse(numVertex);
                        Debug.Log("vertex count: " + vertexCount);
                         //int numSubmesh = 0;
                        float numLeftOver = 0;
                        levelOfDetails = 1 + (int)Mathf.Floor(vertexCount / (maximumVertex*lod));
                        numLeftOver = (float)vertexCount % (maximumVertex*lod);
                        Debug.Log("Num Left Over: " + numLeftOver);
                        Debug.Log("LOD" + levelOfDetails);
                        
                        //loop begin just the first one
                        //for(int indy=0;indy<1;indy++)
                        for (int indy = 0; indy < levelOfDetails; indy++)
                        {
                            MeshInfos data = new MeshInfos();
                            int interiorLoopCt = 0;
                            if (indy == levelOfDetails - 1)
                            {
                                //adjusted it by dividing lod
                                data.vertexCount = int.Parse(numLeftOver.ToString())/lod;
                                interiorLoopCt = data.vertexCount;
                                Debug.Log("Last Vertex: " + data.vertexCount.ToString());
                            }
                            else
                            {
                                data.vertexCount = maximumVertex;
                                interiorLoopCt = maximumVertex;
                            }


                            data.vertices = new Vector3[maximumVertex];
                            data.normals = new Vector3[maximumVertex];
                            data.colors = new Color[maximumVertex];
                            data.intensity = new int[maximumVertex];
                            
                            //using lod to skip lines
                           
                            //int maxVertexCount = 0;
                            for(index=0;index< interiorLoopCt; index++)
                            //for (index = 0; index < vertexCount; index++)
                            {
                                string aLine = "";
                                int skipLineCount = 0;
                                if (index + lod < interiorLoopCt)
                                {
                                    //we can skip lines
                                    while (skipLineCount != lod - 1)
                                    {
                                        aLine = reader.ReadLine();
                                        skipLineCount++;
                                    }
                                    aLine = reader.ReadLine();
                                    try
                                    {
                                        string[] allPts = aLine.Split(' ');
                                        if (allPts.Length == 7)
                                        {
                                            data.vertices[index] = new Vector3(-float.Parse(allPts[0]), float.Parse(allPts[1]), float.Parse(allPts[2]));
                                            data.normals[index] = data.vertices[index];
                                            data.intensity[index] = int.Parse(allPts[3]);
                                            data.colors[index] = new Color(float.Parse(allPts[4]) / 255f, float.Parse(allPts[5]) / 255f, float.Parse(allPts[6]) / 255f);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                            
                            AllMesh.Add(data);
                            //loop end
                        }
                    }
                }
                else
                {
                    Debug.Log("No File");
                }
                return AllMesh;
            }
            else
            {
                return null;
            }
        }
		public MeshInfos Load (string filePath, int maximumVertex = 65000)
		{
			MeshInfos data = new MeshInfos();
			int levelOfDetails = 1;
			if (File.Exists(filePath)) {
				using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open))) {
					int cursor = 0;
					int length = (int)reader.BaseStream.Length;
					string lineText = "";
					bool header = true;
					int vertexCount = 0;
					int colorDataCount = 3;
					int index = 0;
					int step = 0;
					while (cursor + step < length) {
						if (header) {
							char v = reader.ReadChar();
							if (v == '\n') {
								if (lineText.Contains("end_header")) {
									header = false;
								} else if (lineText.Contains("element vertex")) {
									string[] array = lineText.Split(' ');
									if (array.Length > 0) {
										int subtractor = array.Length - 2;
										vertexCount = Convert.ToInt32 (array [array.Length - subtractor]);
										if (vertexCount > maximumVertex) {
											levelOfDetails = 1 + (int)Mathf.Floor(vertexCount / maximumVertex);
											vertexCount = maximumVertex;
										}
										data.vertexCount = vertexCount;
										data.vertices = new Vector3[vertexCount];
										data.normals = new Vector3[vertexCount];
										data.colors = new Color[vertexCount];
									}
								} else if (lineText.Contains("property uchar alpha")) {
									colorDataCount = 4;
								}
								lineText = "";
							} else {
								lineText += v;
							}
							step = sizeof(char);
							cursor += step;
						} else {
							if (index < vertexCount) {

								data.vertices[index] = new Vector3(-reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
								data.normals[index] = new Vector3(-reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
								data.colors[index] = new Color(reader.ReadByte() / 255f, reader.ReadByte() / 255f, reader.ReadByte() / 255f, 1f);

								step = sizeof(float) * 6 * levelOfDetails + sizeof(byte) * colorDataCount * levelOfDetails;
								cursor += step;
								if (colorDataCount > 3) {
									reader.ReadByte();
								}

								if (levelOfDetails > 1) { 
									for (int l = 1; l < levelOfDetails; ++l) { 
										for (int f = 0; f < 6; ++f) { 
											reader.ReadSingle(); 
										} 
										for (int b = 0; b < colorDataCount; ++b) { 
											reader.ReadByte(); 
										} 
									} 
								} 

								++index;
							}
						}
					}
				}
			}
			return data;
		}
	}
}
