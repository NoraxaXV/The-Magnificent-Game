using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGenerator
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapWidth;
        public int mapHeight;
        public float noiseScale;
        
        public int octaves;
        [Range(-1,1)] public float persistence;
        public float lacunarity;

        public int seed;
        public Vector2 offset;

        public bool autoUpdate;

        public void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale, octaves, persistence, lacunarity);

            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawNoiseMap(noiseMap);
        }
    }
}