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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
    }
}
