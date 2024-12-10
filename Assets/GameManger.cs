using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance {get; private set;}

    private GameObject m_player;
    public WeaponAsset gun;
    public int gunNum;
    public WeaponAsset droneAttack;
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

    public void GetVaribles()
    {
        m_player = GameObject.FindWithTag("Player");
        gun = m_player.GetComponent<WeaponManager>().curWeaponAsset;
        gunNum = m_player.GetComponent<WeaponManager>().curGunNum;
        droneAttack = m_player.GetComponent<WeaponManager>().curDroneAssest;
        scrap = m_player.GetComponent<ScrapManager>().scrapCount;
    }

    public void LoadData(WeaponManager _weaponManager)
    {
        Debug.Log("Load Data");
        m_player = GameObject.FindWithTag("Player");
        _weaponManager.UpdateWeapon(gun, gunNum);

    }

}
