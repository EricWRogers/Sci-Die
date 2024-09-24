using System.Collections;
using System.Collections.Generic;
using SuperPupSystems.Helper;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public Transform weapon;

    public float fireRate;
    
    private float time = 0.0f;

    public string activeGun;

    public WeaponAsset defaultWeaponAsset;

    public WeaponManager(){

    }

    void Awake()
    {
        UpdateWeapon(defaultWeaponAsset);
    }
    void Update(){


        time += Time.deltaTime;
        float timeToNextFire = 1/fireRate;
        if((activeGun == "RocketLauncher" || activeGun == "Shotgun") && (Input.GetKeyDown(KeyCode.Mouse0))){
            if (activeGun == "RocketLauncher"){
                if(time >= timeToNextFire){
                    Instantiate(bullet, weapon.position, weapon.rotation);
                    time = 0;
                }
            }
            
            if (activeGun == "Shotgun"){
                if(time >= timeToNextFire){
                    Instantiate(bullet, weapon.position, weapon.rotation);
                    time = 0;
                }
            } 
        }

        if ((activeGun == "Pistol" || activeGun == "MachineGun") && (Input.GetKey(KeyCode.Mouse0)) && time >= 0){
            if(activeGun == "Pistol"){
                if(time >= timeToNextFire){
                    Instantiate(bullet, weapon.position, weapon.rotation);
                    time = 0;
                }
            }
            if(activeGun == "MachineGun"){
                if(time >= timeToNextFire){
                    Instantiate(bullet, weapon.position, weapon.rotation);
                    time = 0;
                }
            }
                
        }
        
    }
    public void UpdateWeapon(WeaponAsset m_weaponAsset)
    {
        bullet = m_weaponAsset.bullet;
        activeGun = m_weaponAsset.activeGun;
        fireRate = m_weaponAsset.fireRate;
    }
}
