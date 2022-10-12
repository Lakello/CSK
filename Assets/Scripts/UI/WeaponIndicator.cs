using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIndicator : MonoBehaviour
{
    public static WeaponIndicator Instance;

    private Image _weaponPrewiew;

    private void Awake()
    {
        _weaponPrewiew = GetComponent<Image>();
        _weaponPrewiew.enabled = false;
        if (Instance == null) Instance = this;
    }

    public void SetWeaponPreview(Sprite image)
    {
        _weaponPrewiew.enabled = !(image == null);
        _weaponPrewiew.sprite = image;
    }
}
