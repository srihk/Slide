using UnityEngine;
using System.Collections;

public class TerrainGen : MonoBehaviour
{
    public int depth = 0;
    public int width = 256;
    public int height = 256;
    public float scale = 2f;
    public float offsetx = 100f;
    public float offsety = 100f;
    void Start()
    {
        offsetx = Random.Range(0f, 9999f);
        offsety = Random.Range(0f, 9999f);
    }
    void FixedUpdate()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }
    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = height + 1;
        data.size = new Vector3(width, depth, height);
        data.SetHeights(0, 0, GenerateHeights());
        return data;
    }
    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }
    float CalculateHeight(int x, int y)
    {
        float xc = (float)x / width * scale + offsetx;
        float yc = (float)y / height * scale + offsety;
        return Mathf.PerlinNoise(xc, yc);
    }
}
