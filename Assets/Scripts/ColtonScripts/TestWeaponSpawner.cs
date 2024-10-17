using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAndId
{
    public int id;
    public Vector3 pos;
}

public class RockSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    public int numberOfRocks = 5;
    public float spaceRange = 100.0f;
    public float spaceBetweenRocks = 1.0f;
    public float rockSpawnerDeadZone = 5.0f;
    public int tryToPlaceCount = 5;

    private List<PositionAndId> posIds = new List<PositionAndId>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfRocks; i++)
        {
            for (int t = 0; t < tryToPlaceCount; t++)
            {
                Vector3 postion = new Vector3(
                    Random.Range(-spaceRange, spaceRange),
                    Random.Range(-spaceRange, spaceRange),
                   0.0f);

                bool canPlace = true;


                for (int r = 0; r < posIds.Count; r++)
                {
                    if (Vector3.Distance(postion, posIds[r].pos) < spaceBetweenRocks)
                    {
                        canPlace = false;
                        break;
                    }
                }

                if (Vector3.Distance(postion, transform.position) < rockSpawnerDeadZone)
                {
                    canPlace = false;
                }

                if (canPlace == true)
                {
                    PositionAndId positionAndId = new PositionAndId();
                    positionAndId.pos = postion;
                    positionAndId.id = Random.Range(0, prefabs.Count);
                    posIds.Add(positionAndId);
                    break;
                }
            }
        }

        for (int i = 0; i < posIds.Count; i++)
        {
            GameObject rock = Instantiate(
                prefabs[posIds[i].id],
                posIds[i].pos,
                Quaternion.identity,
                transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
