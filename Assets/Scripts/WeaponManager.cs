using System.Collections;
using System.Collections.Generic;
using SuperPupSystems.Helper;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bullet;

    public GameObject railgunReady;

    public Transform weapon;
    public GameObject [] bulletSpawns;

    private PlayerControls controls;

    public float fireRate;
    
    private float time = 0.0f;

    public string activeGun;

    private float destroyTimer;

    private float railgunCharge;

    public bool isCharging = true;
    public bool droneActive = false;
    public bool isShopping = false;
//Drone Vars
     public Transform droneAttackPoint;
    public int attackDmg;
    public float m_angle;
    public LayerMask enemyLayers;
    public Animator Droneanimator;
    public WeaponAsset defaultWeaponAsset;
    public GameObject currentWeapon;

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

    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            droneActive = !droneActive;
        }
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

        if(!droneActive && !isShopping){
            if ((activeGun == "RocketLauncher" || activeGun == "Shotgun" || activeGun == "Railgun") && fireInput){
                if (activeGun == "Shotgun"){
                    if(time >= timeToNextFire){
                        Instantiate(bullet, bulletSpawns[3].transform.position, bulletSpawns[3].transform.rotation);
                        time = 0;
                    }
                }
                if (activeGun == "RocketLauncher"){
                    if(time >= timeToNextFire){
                        Instantiate(bullet, bulletSpawns[1].transform.position, bulletSpawns[1].transform.rotation);
                        time = 0;
                    }
                }
                if (activeGun == "Railgun" && railgunCharge >= 5){
                    GameObject go = Instantiate(bullet, bulletSpawns[2].transform.position, bulletSpawns[2].transform.rotation);
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
                        Instantiate(bullet, bulletSpawns[0].transform.position, bulletSpawns[0].transform.rotation);
                        time = 0;
                    }
                }
                if(activeGun == "MachineGun"){
                    if(time >= timeToNextFire){
                        Instantiate(bullet, bulletSpawns[4].transform.position, bulletSpawns[4].transform.rotation);
                        time = 0;
                    }
                }
            }
                    if (activeGun == "ScissorDrone" && fireInput && timeToNextFire < Time.time)
        {
            
            Invoke(nameof(ScissorAttack), .5f);

            Droneanimator.SetTrigger("ScissorAttack");
            time = 0;
        }
        if (activeGun == "SpearDrone" && fireInput && timeToNextFire < Time.time)
        {

            Invoke(nameof(SpearDrone), .5f);

            Droneanimator.SetTrigger("SpearAttack");
            time = 0;
        }
 

        } else {
            
        }
    }
    public void UpdateWeapon(WeaponAsset m_weaponAsset)
    {
        bullet = m_weaponAsset.bullet;
        activeGun = m_weaponAsset.activeGun;
        fireRate = m_weaponAsset.fireRate;
        currentWeapon = m_weaponAsset.weaponPrefab;
    }

        private void ScissorAttack()
    {
              Debug.Log("ScissorDronedamage");
            
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(droneAttackPoint.position, new Vector2(2,2), m_angle, enemyLayers);


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);
            }
        
    }
    void SpearDrone()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(droneAttackPoint.position, new Vector2(4, 6), m_angle, enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDmg);
        }
    }
}
