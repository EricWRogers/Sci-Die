using System.Collections.Generic;
using UnityEngine;

public static class GlobalDoorManager
{
    private static Dictionary<Room, List<DoorTrigger>> roomDoors = new Dictionary<Room, List<DoorTrigger>>();
    private static List<Room> allRooms = new List<Room>();

    // Register a door and associate it with its room
    public static void RegisterDoor(DoorTrigger door)
    {
        Room room = door.room;
        if (room != null)
        {
            if (!roomDoors.ContainsKey(room))
            {
                roomDoors[room] = new List<DoorTrigger>();
            }
            if (!roomDoors[room].Contains(door))
            {
                roomDoors[room].Add(door);
            }
        }
    }

    // Register each room in the global room list
    public static void RegisterRoom(Room room)
    {
        if (!allRooms.Contains(room))
        {
            allRooms.Add(room);
        }
    }

    // Unregister a door from its room
    public static void UnregisterDoor(DoorTrigger door)
    {
        Room room = door.room;
        if (room != null && roomDoors.ContainsKey(room))
        {
            roomDoors[room].Remove(door);
        }
    }

    // Open all doors in a specific room
    public static void OpenDoorsForRoom(Room room)
    {
        if (roomDoors.ContainsKey(room))
        {
            foreach (DoorTrigger door in roomDoors[room])
            {
                door.OpenDoor();
            }
        }
    }

    // Close all doors in a specific room
    public static void CloseDoorsForRoom(Room room)
    {
        if (roomDoors.ContainsKey(room))
        {
            foreach (DoorTrigger door in roomDoors[room])
            {
                door.CloseDoor();
            }
        }
    }

    // Open all doors globally
    public static void OpenAllDoors()
    {
        foreach (var doors in roomDoors.Values)
        {
            foreach (DoorTrigger door in doors)
            {
                door.OpenDoor();
            }
        }
    }

    // Check if all rooms have defeated enemies
    public static bool AreAllRoomsClear()
    {
        foreach (Room room in allRooms)
        {
            if (!room.AreAllEnemiesDefeated())
            {
                return false;
            }
        }
        return true;
    }
}