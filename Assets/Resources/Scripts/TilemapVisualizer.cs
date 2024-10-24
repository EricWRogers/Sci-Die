using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase floorTile, wallTop, wallBottom, wallLeft, wallRight, wallTopRightCorner, wallTopLeftCorner, wallBottomRightCorner, wallBottomLeftCorner;

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

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    } 

    /*internal void PaintWallTiles(IEnumerable<Vector2Int> wallPositions, HashSet<Vector2Int> floorPositions)
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
            {
                PaintSingleTile(wallTilemap, wallBottomLeftCorner, position);
            }
            else if (hasTop && hasLeft && !hasBottom && !hasRight)
            {
                PaintSingleTile(wallTilemap, wallBottomRightCorner, position);
            }
            else if (hasBottom && hasRight && !hasTop && !hasLeft)
            {
                PaintSingleTile(wallTilemap, wallTopLeftCorner, position);
            }
            else if (hasBottom && hasLeft && !hasTop && !hasRight)
            {
                PaintSingleTile(wallTilemap, wallTopRightCorner, position);
            }
            else if (!hasTop && hasBottom)
            {
                PaintSingleTile(wallTilemap, wallTop, position);
            }
            else if (!hasBottom && hasTop)
            {
                PaintSingleTile(wallTilemap, wallBottom, position);
            }
            else if (!hasLeft && hasRight)
            {
                PaintSingleTile(wallTilemap, wallLeft, position);
            }
            else if (!hasRight && hasLeft)
            {
                PaintSingleTile(wallTilemap, wallRight, position);
            }
        }
    }
    */

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
 
    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
