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
    
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            weaponManager.UpdateWeapon(Pistol);
            Destroy(this.transform.parent);
        }

        if (Input.GetKeyDown("2")){
            weaponManager.UpdateWeapon(Shotgun);
            Destroy(this.transform.parent);
        }

        if (Input.GetKeyDown("3")){
            weaponManager.UpdateWeapon(MachineGun);
            Destroy(this.transform.parent);
        }
        if (Input.GetKeyDown("4")){
            weaponManager.UpdateWeapon(RocketLauncher);
            Destroy(this.transform.parent);
        }
        if(Input.GetKeyDown("5")){
            weaponManager.UpdateWeapon(Railgun);
            Destroy(this.transform.parent);
        }
    }
}
