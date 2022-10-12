using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
    [SerializeField] private bool _placeGrabbedGunInHands;
    [SerializeField][Range(1,10)] private int _capacity;
    [SerializeField] private Transform _weaponContainer;
    private Weapon _currentWeapon;
    private List<Weapon> _weapons = new List<Weapon>();

    public Weapon CurrentWeapon => _currentWeapon;
    public Transform WeaponContainer => _weaponContainer;

    private void OnEnable()
    {
        ItemGrabber.OnWeaponGrab += TryAddWeapon;
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;
        string input = Input.inputString;

        for (int i = 1; i <= _weapons.Count; i++)
        {
            if (input.Contains(i.ToString()))
            {
                ChangeWeapon(i-1);
                return;
            }
        }
    }

    private void SetCurrentWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        weapon.gameObject.SetActive(true);
        WeaponIndicator.Instance.SetWeaponPreview(weapon.InventoryView);
    }

    private void ChangeWeapon(int index)
    {
        if (_weapons.ToArray()[index] == _currentWeapon && _currentWeapon.gameObject.activeSelf)
        {
            HideWeapon();
            return;
        }
       
        _currentWeapon?.gameObject.SetActive(false);
        SetCurrentWeapon(_weapons.ToArray()[index]);
    }

    private void HideWeapon()
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = null;
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon?.gameObject.SetActive(false);
        SetCurrentWeapon(weapon);
    }

    public void TryAddWeapon(Weapon weapon)
    {
        if (_weapons.Count >= _capacity)
        {
            Debug.Log("Inventory full");
            return;
        }

        if (_placeGrabbedGunInHands || _weapons.Count == 0)
        {
            ChangeWeapon(weapon);
        }
        else weapon.gameObject.SetActive(false);

        weapon.transform.SetParent(_weaponContainer);
        weapon.transform.localPosition = weapon.WeaponPosition;
        weapon.transform.localRotation = Quaternion.Euler(weapon.WeaponRotation);
        _weapons.Add(weapon);

    }

    private void OnDisable()
    {
        ItemGrabber.OnWeaponGrab -= TryAddWeapon;
    }
}
