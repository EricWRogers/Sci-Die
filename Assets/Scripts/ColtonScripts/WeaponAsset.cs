using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFile", menuName = "WeaponAsset/New")]
public class WeaponAsset : ScriptableObject
{
    public GameObject bullet;
    public string activeGun;
    public float fireRate;

    public int attackDmg;
}