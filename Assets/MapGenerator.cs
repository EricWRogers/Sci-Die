using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int mapWidth, mapHeight;

    [SerializeField] private GameObject isometricTile;

    void Awake() //calls generate map function
    {
        GenerateMap();
    }

    void GenerateMap()
    //for loop for instantiating the tiles that i do not yet have
    {
        for (int x = mapWidth; x >= 0; x--)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float xOffset = (x + y / 2f);
                        //off set is required to take off some of the value from the tiles in order to make it look isometric
                float yOffset = (x - y / 4f);
                
                GameObject tile = Instantiate(isometricTile, new Vector3(xOffset, yOffset, 0), Quaternion.identity); 


            }
        }
    }
}
