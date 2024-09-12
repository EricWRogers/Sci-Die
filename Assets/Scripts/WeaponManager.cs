using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public Transform weapon;

    public float fireRate = 0.0f;
    
    private float time = 0.0f;

    void Update(){

        time += Time.deltaTime;
        float timeToNextFire = 1/fireRate;
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(time >= timeToNextFire){
                Instantiate(bullet, weapon.position, weapon.rotation);
                time = 0;
            }
        }
    }
    
}
