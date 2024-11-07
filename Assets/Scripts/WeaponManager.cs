using System.Collections;
using System.Collections.Generic;
using SuperPupSystems.Helper;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public GameObject railgunReady;

    public Transform weapon;

    private PlayerControls controls;

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
            controls = new PlayerControls();
            controls.Player.Dash.performed += ctx => Update();
        }
    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
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

        bool fireInput = Input.GetKeyDown(KeyCode.Mouse0) || controls.Player.Fire.triggered;

        if ((activeGun == "RocketLauncher" || activeGun == "Shotgun" || activeGun == "Railgun") && fireInput){
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

 

        if ((activeGun == "Pistol" || activeGun == "MachineGun") && (Input.GetKey(KeyCode.Mouse0) || controls.Player.Fire.ReadValue<float>() > 0) && time >= 0){
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
