using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap, pillarTilemap;
    [SerializeField]
    private TileBase floorTile, wallTop, wallBottom, wallSideLeft, wallSideRight, wallFull, 
    wallInnerCornerDownRight, wallInnerCornerDownLeft, 
    wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft, 
    pillarTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    public void PaintPillarTiles(HashSet<Vector2Int> pillarPositions)
    {
        PaintTiles(pillarPositions, pillarTilemap, pillarTile);
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if (WallTypesHelper.wallBottom.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }
        else if (WallTypesHelper.wallFull.Contains(typeAsInt))
        {
            tile = wallFull; 
        }

        if (tile != null)
        PaintSingleTile(wallTilemap, /*tile*/ wallTop, position); // Use selected tile here
    }

    


    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile =wallInnerCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallFull;
        }
         else if (WallTypesHelper.wallBottomEightDirections.Contains(typeAsInt))
        {
            tile = wallBottom;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        pillarTilemap.ClearAllTiles();
    }

    /* Uncomment and modify to use PaintWallTiles dynamically
    internal void PaintWallTiles(IEnumerable<Vector2Int> wallPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in wallPositions)
        {
            var neighbors = GetNeighborPositions(position);

            bool hasTop = floorPositions.Contains(neighbors.top);
            bool hasBottom = floorPositions.Contains(neighbors.bottom);
            bool hasLeft = floorPositions.Contains(neighbors.left);
            bool hasRight = floorPositions.Contains(neighbors.right);

            // Determine which tile to place based on surrounding tiles
            if (hasTop && hasRight && !hasBottom && !hasLeft)
                PaintSingleTile(wallTilemap, wallBottomLeftCorner, position);
            else if (hasTop && hasLeft && !hasBottom && !hasRight)
                PaintSingleTile(wallTilemap, wallBottomRightCorner, position);
            else if (hasBottom && hasRight && !hasTop && !hasLeft)
                PaintSingleTile(wallTilemap, wallTopLeftCorner, position);
            else if (hasBottom && hasLeft && !hasTop && !hasRight)
                PaintSingleTile(wallTilemap, wallTopRightCorner, position);
            else if (!hasTop && hasBottom)
                PaintSingleTile(wallTilemap, wallTop, position);
            else if (!hasBottom && hasTop)
                PaintSingleTile(wallTilemap, wallBottom, position);
            else if (!hasLeft && hasRight)
                PaintSingleTile(wallTilemap, wallLeft, position);
            else if (!hasRight && hasLeft)
                PaintSingleTile(wallTilemap, wallRight, position);
        }
    }
    */

    private (Vector2Int top, Vector2Int bottom, Vector2Int left, Vector2Int right) GetNeighborPositions(Vector2Int position)
    {
        return (position + Vector2Int.up, position + Vector2Int.down, position + Vector2Int.left, position + Vector2Int.right);
    }
}
