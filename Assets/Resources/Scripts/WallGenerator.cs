using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallInDirections(floorPositions, Direction2D.cardinalDirectionList);
        var cornerWallPositions = FindWallInDirections(floorPositions, Direction2D.diagonalDirectionList);
        //var pillarWallPositions = FindWallInDirections(floorPositions, Direction2D.diagonalDirectionList);
        CreateBasicWall(tilemapVisualizer, basicWallPositions, floorPositions);
        CreateCornerWalls(tilemapVisualizer,cornerWallPositions, floorPositions);
        //CreatePillarWalls(tilemapVisualizer, pillarWallPositions, floorPositions);
    }

    private static void CreatePillarWalls(TilemapVisualizer tilemapVisualizer, object pillarWallPositions, HashSet<Vector2Int> floorPositions)
    {
        throw new NotImplementedException();
    }

    private static void CreateCornerWalls(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in cornerWallPositions)
        {
            string neighborsBinaryType = "";
            foreach (var direction in Direction2D.eightDirectionList)
            {
                var neighborPosition = position + direction;
                if(floorPositions.Contains(neighborPosition))
                {
                    neighborsBinaryType += "1";
                }
                else
                {
                    neighborsBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerWall(position, neighborsBinaryType);
        }
    }

    private static void CreateBasicWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in basicWallPositions) //item in collection
        {
            string neighborsBinaryType = "";
            foreach(var direction in Direction2D.cardinalDirectionList)
            {
                var neighborPosition = position + direction;
                if(floorPositions.Contains(neighborPosition))
                {
                    neighborsBinaryType += "1";
                }
                else
                {
                    neighborsBinaryType += "0";
                }
            }
                     
           tilemapVisualizer.PaintSingleBasicWall(position, neighborsBinaryType);
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

/*public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallInDirections(floorPositions, Direction2D.cardinalDirectionList);
        foreach (var position in basicWallPositions) //item in collection
        {
            tilemapVisualizer.PaintWallTiles(position);
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
*/

