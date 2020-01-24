using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGenerator
{
    public static class Noise
    {
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity)
        {
            
            float[,] noiseMap = new float[mapWidth, mapHeight];

            System.Random prng = new System.Random (seed);
            Vector2[] octaveOffsets = new Vector2[octaves];
            for (int i = 0; i < octaves; i++) {
                float offsetX = prng.Next(-10000, 10000);
                float offsetY = prng.Next(-10000, 10000);

                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }
            
            if (scale <= 0)
            {
                scale = 0.001f;
            }

            float maxNoiseHeight = float.MinValue;
            float minNoiseheight = float.MaxValue;

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;
                    
                    for (int o = 0; o < octaves; o++)
                    {
                        float sampleX = x / scale * frequency;
                        float sampleY = y / scale * frequency;

                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }
                    if (noiseHeight > maxNoiseHeight)
                    {
                        maxNoiseHeight = noiseHeight;
                    }
                    else if(noiseHeight < minNoiseheight)
                    {
                        minNoiseheight = noiseHeight;
                    }
                    noiseMap[x, y] = noiseHeight;
                }
            }
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseheight, maxNoiseHeight, noiseMap[x, y]);
                }
            }
                    return noiseMap;
        }
    }
}
