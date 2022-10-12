using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite _dropped;
    [SerializeField] private Sprite _inventoryView;

    public Sprite Dropped => _dropped;
    public Sprite InventoryView => _inventoryView;
    public bool Isdropped => GetComponentInParent<GunInventory>() == null;

    public abstract void Grab(Transform container);
}
