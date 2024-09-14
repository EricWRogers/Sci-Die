using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //allows us to query any collection in the project
using Random = UnityEngine.Random; 

public class SimpleRandomWalkMapGen : AbstractDungeonGen
{
    [SerializeField]
    private SimpleRandWalkData randomWalkParameters;
      
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.paintFloorTiles(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProcGenAlg.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);  //runs one simple walk alg and creates the floor positions and starts randomly each iteration and starts from any random pos. of the path
            floorPositions.UnionWith(path);
            if(randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

}
