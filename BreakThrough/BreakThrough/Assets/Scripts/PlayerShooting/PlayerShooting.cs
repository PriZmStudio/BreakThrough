using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField]
    Camera cam;

    [SerializeField]
    private LayerMask mask;
	// Use this for initialization
	void Start () {
        if (cam == null) {
            Debug.LogError("No Camera found for shooting");
            this.enabled = false;
        }
	}
	
	
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask)) {
            // We hit something
            Debug.Log("We hit "+_hit.collider.name);
        }
    }
}
