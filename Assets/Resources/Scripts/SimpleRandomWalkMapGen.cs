using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //allows us to query any collection in the project
using Random = UnityEngine.Random; 

public class SimpleRandomWalkMapGen : MonoBehaviour
{
    [SerializeField] 
    protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        foreach (var position in floorPositions)
        {
            Debug.Log(position);
        }
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProcGenAlg.SimpleRandomWalk(currentPosition, walkLength);  //runs one simple walk alg and creates the floor positions and starts randomly each iteration and starts from any random pos. of the path
            floorPositions.UnionWith(path);
            if(startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

}
