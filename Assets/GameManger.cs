using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance {get; private set;}

    private GameObject m_player;
    public GameObject gun;
    public string droneAttack;
    public int scrap;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    public void Update()
    {
        m_player = GameObject.FindWithTag("Player");
        gun = m_player.GetComponent<WeaponManager>().currentGun;
        droneAttack = m_player.GetComponent<WeaponManager>().currentDrone;
        scrap = m_player.GetComponent<ScrapManager>().scrapCount;
    }
}
