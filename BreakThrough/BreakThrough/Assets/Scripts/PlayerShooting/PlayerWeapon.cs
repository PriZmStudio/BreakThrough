using UnityEngine;

[System.Serializable]
public class PlayerWeapon  {

    public string name = "M11";

    public float damage = 10f;
    public float range = 100f;

    public bool isAutomatic = true;
    public float fireRate = 1 / 3;
}
