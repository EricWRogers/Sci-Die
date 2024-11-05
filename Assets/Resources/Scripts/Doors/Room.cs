using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Assign enemy prefabs in the Inspector
    public List<Transform> spawnPoints; // Assign specific spawn points in the Inspector 
    private List<GameObject> activeEnemies = new List<GameObject>(); // Tracks the instantiated enemies
    public List<DoorTrigger> doors; // Assign doors for the room in the Inspector
    public bool enemiesActivated = false;

    private void Start()
    {
        OpenAllDoors(); // Start with all doors open
    }

    public void ActivateEnemies()
    {
        if (enemiesActivated) return; // Prevent re-activation if already activated
        enemiesActivated = true; // Set flag to indicate enemies are now active

        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            // Spawn each enemy at a specific spawn point 
            Vector3 spawnPosition = (i < spawnPoints.Count) ? spawnPoints[i].position : transform.position;
            GameObject enemyInstance = Instantiate(enemyPrefabs[i], spawnPosition, Quaternion.identity);
            activeEnemies.Add(enemyInstance);
            enemyInstance.SetActive(true); // Ensure the enemy is active in the scene
        }
    }

    private void Update()
    {
        // Continuously check if all enemies are defeated to reopen the doors
        if (AreAllEnemiesDefeated())
        {
            OpenAllDoors(); // Reopen all doors when enemies are defeated
        }
    }

    public void CloseAllDoors()
    {
        foreach (DoorTrigger door in doors)
        {
            door.CloseDoor(); //Closes all Le do
        }
    }

    public void OpenAllDoors()
    {
        foreach (DoorTrigger door in doors)
        {
            door.OpenDoor();
        }
    }

    public bool AreAllEnemiesDefeated()
    {
        activeEnemies.RemoveAll(enemy =>
        {
            if (enemy == null) return true;
            if (!enemy.activeInHierarchy)
            {
                Destroy(enemy);
                return true;
            }
            return false;
        });
        
        return activeEnemies.Count == 0; // Returns true if all enemies are defeated
    }
}

