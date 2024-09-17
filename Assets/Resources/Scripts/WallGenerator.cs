using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallInDirections(floorPositions, Direction2D.cardinalDirectionList);
        foreach (var position in basicWallPositions) //item in collection
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }    
    private static HashSet<Vector2Int> FindWallInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList) 
            {
                var neighborPosition = position + direction;
                if(floorPositions.Contains(neighborPosition) == false) // we are considering a position near our floor tile that isnt on the floor tiles list so it must be a wall
                    wallPositions.Add(neighborPosition);
            }
        }
        return wallPositions;
    }
}    

