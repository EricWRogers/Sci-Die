using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
   [SerializeField] private int mapWidth, mapHeight;

   [SerializeField] private GameObject isometricTile;

   void Awake()
   {
        GenerateMap();
   }
   void GenerateMap()
   {
        for (int x = mapWidth; x >= 0; x--)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float xOffset = (x + y) / 2f;
                //math for the offset val of the tiles in order to get the isometric overlapping 2/3 D look
                float yOffset = (x - y) / 4f;

                GameObject tile = Instantiate(isometricTile, new Vector3(xOffset, yOffset, 0), Quaternion.identity); //instantiates the tiles
            }
        }
   }
}