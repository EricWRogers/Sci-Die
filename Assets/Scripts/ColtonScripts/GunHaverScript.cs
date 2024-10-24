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
            weaponManager.UpdateWeapon(Pistol);
            Debug.Log("Pistol");
            isColliding = false;
        }

        if (isColliding == true && weaponTag == "Pickup2" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(Shotgun);
            Debug.Log("Shotgun");
            isColliding = false;
        }

        if (isColliding == true && weaponTag == "Pickup3" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(MachineGun);
            Debug.Log("Machine Gun");
            isColliding = false;
        }
        if (isColliding == true && weaponTag == "Pickup4" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(RocketLauncher);
            Debug.Log("Rocket Launcher");
            isColliding = false;
        }
        if (isColliding == true && weaponTag == "Pickup5" && Input.GetKeyDown(KeyCode.E)){
            weaponManager.UpdateWeapon(Railgun);
            Debug.Log("Railgun");
            isColliding = false;
        }
    }

    void OnTriggerStay2D(Collider2D col){
        isColliding = true;
        weaponTag = col.transform.tag;
    }
}
