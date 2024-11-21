using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunHaverScript : MonoBehaviour
{
    public WeaponManager weaponManager;
    public WeaponAsset Pistol;
    public WeaponAsset Shotgun;
    public WeaponAsset MachineGun;
    public WeaponAsset RocketLauncher;
    public WeaponAsset Railgun;
    public bool isColliding = false;
    string weaponTag;
    
    void Update()
    {
        if (isColliding == true && weaponTag == "Pickup1" && Input.GetKeyDown(KeyCode.E))
        {
            weaponManager.UpdateWeapon(Pistol, 0);
            Debug.Log("Pistol");
            isColliding = false;
        }

        if (isColliding == true && weaponTag == "Pickup2" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(Shotgun, 3);
            Debug.Log("Shotgun");
            isColliding = false;
        }

        if (isColliding == true && weaponTag == "Pickup3" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(MachineGun, 4);
            Debug.Log("Machine Gun");
            isColliding = false;
        }
        if (isColliding == true && weaponTag == "Pickup4" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(RocketLauncher, 1);
            Debug.Log("Rocket Launcher");
            isColliding = false;
        }
        if (isColliding == true && weaponTag == "Pickup5" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(Railgun, 2);
            Debug.Log("Railgun");
            isColliding = false;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        isColliding = true;
    }

    void OnTriggerEnter2D(Collider2D col){
        weaponTag = col.transform.tag;
    }
}
