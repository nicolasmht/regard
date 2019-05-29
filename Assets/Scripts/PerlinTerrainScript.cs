using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrainScript : MonoBehaviour
{

    public float[,] terrainHeightData;
    public int rowsandcolumns = 0;
    public float refinement = 0f;
    public float multiplier = 0f;
    float perlinNoise = 0f;
    Terrain terrain;

    // Start is called before the first frame update
    void Start() {

        terrainHeightData = new float[rowsandcolumns, rowsandcolumns];
        terrain = GetComponent<Terrain>();

        for (int i = 0; i < rowsandcolumns; i++) {
            for (int j = 0; j < rowsandcolumns; j++) {
                /*
                if (
                    i < rowsandcolumns/2 + 60 && i > rowsandcolumns/2 - 60
                   ) {
                    terrainHeightData[i, j] = -(float)0.05f;
                } else {

                    perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
                    terrainHeightData[i, j] = perlinNoise * multiplier;
                }*/
                perlinNoise = Mathf.PerlinNoise(i * refinement, j * refinement);
                terrainHeightData[i, j] = perlinNoise * multiplier;
            }
        }

        terrain.terrainData.SetHeights(0, 0, terrainHeightData);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
