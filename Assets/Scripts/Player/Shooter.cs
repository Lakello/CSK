using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private GunInventory _gunInventory;

    void Awake()
    {
        _gunInventory = GetComponent<GunInventory>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _gunInventory.CurrentWeapon != null)
        {
            _gunInventory.CurrentWeapon.Shoot();
        }
    }
}
