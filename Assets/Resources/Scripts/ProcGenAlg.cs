using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProcGenAlg 
//makes available for any class to have access to this script
{
    //hash set data types is a collection that allows the storing of unique values
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousposition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousposition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousposition = newPosition;
        }
        return path;
    }

}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP/N
        new Vector2Int(0,-1), //DOWN/S
        new Vector2Int(1,0), //RIGHT/E
        new Vector2Int(-1,0), //LEFT/W

        new Vector2Int(-1,1), //NW
        new Vector2Int(1,1), //NE
        new Vector2Int(-1,-1), //SW
        new Vector2Int(1,-1), //SE

    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        //return cardinalDirectionList[Random.Range(0, 3)];
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)]; 
    }
}

//public static class Direction2D
//{
    //public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    //{
        //new Vector2Int(0, 1), //UP
        //new Vector2Int(1, 0), //RIGHT
        //new Vector2Int(0, -1), //DOWN
        //new Vector2Int(-1, 0), //LEFT
    //};

    //public static Vector2Int GetRandomCardinalDirection()
    //{
        //return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    //}
//}
