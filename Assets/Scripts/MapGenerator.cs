using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGenerator
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapWidth = 100;
        public int mapHeight = 100;
        public float noiseScale = 0.25f;
        
        public int octaves = 3;
        [Range(-1,1)] public float persistence = 0.1f;
        public float lacunarity = 1;

        public int seed = 1;
        public Vector2 offset;

        public bool autoUpdate;

        public void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawNoiseMap(noiseMap);
        }
        private void OnValidate()
        {
            if (mapWidth < 1) 
            {
                mapWidth = 1;
            }
            if (mapHeight < 1) 
            {
                mapHeight = 1;
            }

        }
    }
}