using System.Collections;
using System.Collections.Generic;
using SuperPupSystems.Helper;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public GameObject railgunReady;

    public Transform weapon;

    public float fireRate;
    
    private float time = 0.0f;

    public string activeGun;

    private float destroyTimer;

    private float railgunCharge;

    public bool isCharging = true;

    public WeaponAsset defaultWeaponAsset;

    public WeaponManager(){

    }

    void Awake()
    {
        UpdateWeapon(defaultWeaponAsset);
    }

    private void Start()
    {

    }
    void Update()
    {
        time += Time.deltaTime;
        float timeToNextFire = 1/fireRate;
        if (isCharging){
            railgunCharge += Time.deltaTime;
            if(railgunCharge >= 5){
                isCharging = false;
                railgunReady.SetActive(true);
            }
        }
        if((activeGun == "RocketLauncher" || activeGun == "Shotgun" || activeGun == "Railgun") && (Input.GetKeyDown(KeyCode.Mouse0))){
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

            if (activeGun == "Railgun" && railgunCharge >= 5){
                GameObject go = Instantiate(bullet, weapon.position, weapon.rotation);
                time = 0;
                railgunCharge = 0;
                isCharging = true;
                railgunReady.SetActive(false);
                destroyTimer += 1;
                if(destroyTimer == 3.0f){
                    Destroy(go);
                    destroyTimer = 0;
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
