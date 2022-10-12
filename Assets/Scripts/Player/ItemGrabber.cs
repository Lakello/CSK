using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    private GunInventory _gunInventory;
    private Item _itemToGrab;

    public delegate void WeaponGrab(Weapon weapon);
    public static WeaponGrab OnWeaponGrab;

    private void Awake()
    {
        _gunInventory = GetComponentInChildren<GunInventory>();
    }

    private void Update()
    {
        TryGrabItem(_itemToGrab);
    }

    private void TryGrabItem(Item item)
    {
        if (item == null) return;
        if(Input.GetKeyDown(KeyCode.E) && item.Isdropped)
        {
            item.Grab(transform);
            _itemToGrab = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponentInParent<Item>(); 
        if (item != null)
        {
            _itemToGrab = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_itemToGrab != null )
        {
            _itemToGrab = null;
        }
    }
}

