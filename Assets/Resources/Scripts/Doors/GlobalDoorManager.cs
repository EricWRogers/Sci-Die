using System.Collections.Generic;
using UnityEngine;

public static class GlobalDoorManager
{
    private static List<DoorTrigger> allDoors = new List<DoorTrigger>();

    public static void RegisterDoor(DoorTrigger door)
    {
        if (!allDoors.Contains(door))
        {
            allDoors.Add(door); // Add door if not already in the list
        }
    }

    public static void UnregisterDoor(DoorTrigger door)
    {
        if (allDoors.Contains(door))
        {
            allDoors.Remove(door); // Remove door if it exists in the list
        }
    }

    public static void CloseAllDoors()
    {
        foreach (DoorTrigger door in allDoors)
        {
            door.CloseDoor(); // Close each registered door
        }
    }

    public static void OpenAllDoors()
    {
        foreach (DoorTrigger door in allDoors)
        {
            door.OpenDoor(); // Open each registered door
        }
    }
}
