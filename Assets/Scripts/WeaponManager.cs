using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public Transform weapon;

    public float updateTime = 0.0f;
    
    public float frequency = 0.0f;

    void Awake(){
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Update(){
        updateTime = updateTime += Time.deltaTime;
        if (updateTime <= frequency){
            if(Input.GetKey(KeyCode.Mouse0)){
                Instantiate(bullet, weapon.position, weapon.rotation);
            }
            updateTime = 0.0f;
        }
        
    }
    
}
