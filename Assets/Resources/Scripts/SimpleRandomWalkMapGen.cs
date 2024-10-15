using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //allows us to query any collection in the project
using Random = UnityEngine.Random; 

public class SimpleRandomWalkMapGen : AbstractDungeonGen
{
    [SerializeField]
    protected SimpleRandWalkSO randomWalkParameters;
      
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandWalkSO parameters, Vector2Int position)
    {
        var currentPosition = position;
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
