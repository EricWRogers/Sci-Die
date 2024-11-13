using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScrap : MonoBehaviour
{
    public int maxScrap;
    public int minScrap;

    public GameObject scrapPrefab;

    public void dropScrap()
    {
        int scrapCount = Random.Range(maxScrap, minScrap);
        Vector3 scrapPosition = transform.position;

        for (int i = 0; i < scrapCount; i++)
        {
            Instantiate(scrapPrefab, transform.position, transform.rotation);
        }
    }
    
}
