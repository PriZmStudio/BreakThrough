using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField]
    Camera cam;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private WeaponGraphics gfx;
	// Use this for initialization
	void Start () {
        if (cam == null) {
            gfx = gameObject.GetComponent<WeaponGraphics>();
            if (gfx == null) {
                Debug.LogError("NO GFX");
            }
            Debug.LogError("No Camera found for shooting");
            this.enabled = false;
        }
	}
	
	
	void Update () {
        if (!weapon.isAutomatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("Working");
                Shoot();
            }
        }
        else
        {

            if (Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("Working");
                Shoot();
                InvokeRepeating("Shoot", 0, weapon.fireRate);
            }
            if (Input.GetButtonUp("Fire1")) {
                CancelInvoke();
            }
        }
    }

    void Shoot()
    {
        //Debug.Log("hue"+gfx);
        if (gfx == null)
        {
            //Debug.LogError("NO GFX");
            gfx = gameObject.GetComponent<WeaponGraphics>();
        }
        //gameObject.GetComponent<WeaponGraphics>().PlayMuzzleFlash();
        gfx.PlayMuzzleFlash();
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) {
            // We hit something
            //Debug.Log("We hit "+_hit.collider.name);
            gfx.PlayHitEffect(_hit.point, _hit.normal);
            if (_hit.collider.gameObject.tag == "Enemy") {
                _hit.collider.gameObject.GetComponent<EnemyProps>().takeDamage(weapon.damage);
            }
        }
    }
}
