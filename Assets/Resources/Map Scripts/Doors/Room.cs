using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private List<GameObject> enemyObjects; // Dynamically collects enemies in the room
    private HashSet<GameObject> activatedEnemies = new HashSet<GameObject>();
    private GameObject redLight; // Red flashing light
    private GameObject greenLight; // Green flashing light

    private void Start()
    {
        // Collect enemy objects tagged with "Enemy"
        enemyObjects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                enemyObjects.Add(child.gameObject);
            }
            else if (child.CompareTag("RedLight"))
            {
                redLight = child.gameObject;
                redLight.SetActive(false); // Ensure red light starts off
            }
            else if (child.CompareTag("GreenLight"))
            {
                greenLight = child.gameObject;
                greenLight.SetActive(false); // Ensure green light starts off
            }
        }

        GlobalDoorManager.RegisterRoom(this);
        GlobalDoorManager.OpenDoorsForRoom(this); // Start with all doors open
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

        // Turn on the red light when enemies are activated
        if (redLight != null)
        {
            redLight.SetActive(true);
        }

        // Turn off the green light
        if (greenLight != null)
        {
            greenLight.SetActive(false);
        }
    }

    private void Update()
    {
        if (AreAllEnemiesDefeated())
        {
            GlobalDoorManager.OpenDoorsForRoom(this);

            if (GlobalDoorManager.AreAllRoomsClear())
            {
                GlobalDoorManager.OpenAllDoors();
            }

            // Turn off the red light and turn on the green light
            if (redLight != null)
            {
                redLight.SetActive(false);
            }

            if (greenLight != null)
            {
                greenLight.SetActive(true);
            }
        }
    }

    public bool AreAllEnemiesDefeated()
    {
        enemyObjects.RemoveAll(enemy =>
        {
            if (enemy == null) return true;

            if (activatedEnemies.Contains(enemy) && !enemy.activeInHierarchy)
            {
                Destroy(enemy); // Destroy defeated enemies
                return true;
            }
            return false;
        });

        return enemyObjects.Count == 0; // True if all enemies are defeated
    }
}
