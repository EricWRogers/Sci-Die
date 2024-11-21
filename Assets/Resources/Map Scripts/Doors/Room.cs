using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private List<GameObject> enemyObjects; // Will collect enemy children objects in Start
    private HashSet<GameObject> activatedEnemies = new HashSet<GameObject>();

    private void Start()
    {
        enemyObjects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                enemyObjects.Add(child.gameObject);
            }
        }

        GlobalDoorManager.RegisterRoom(this); // Register this room globally
        GlobalDoorManager.OpenDoorsForRoom(this); // Start with all doors in this room open
    }

    public void ActivateEnemies()
    {
        foreach (GameObject enemy in enemyObjects)
        {
            if (enemy != null && !activatedEnemies.Contains(enemy))
            {
                enemy.SetActive(true);
                activatedEnemies.Add(enemy);
            }
        }
    }

    private void Update()
    {
        if (AreAllEnemiesDefeated())
        {
            GlobalDoorManager.OpenDoorsForRoom(this); // Open doors for this room only

            if (GlobalDoorManager.AreAllRoomsClear())
            {
                GlobalDoorManager.OpenAllDoors(); // Open all doors if all rooms are cleared
            }
        }
    }

    public void CloseAllDoors()
    {
        GlobalDoorManager.CloseDoorsForRoom(this);
    }

    public bool AreAllEnemiesDefeated()
    {
        enemyObjects.RemoveAll(enemy =>
        {
            if (enemy == null) return true;
            if (activatedEnemies.Contains(enemy) && !enemy.activeInHierarchy)
            {
                Destroy(enemy); // Destroy the enemy GameObject if deactivated
                return true;
            }
            return false;
        });

        return enemyObjects.Count == 0;
    }
}
