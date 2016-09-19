using UnityEngine;


public class WeaponGraphics : MonoBehaviour {
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffectPrefab;

    public void PlayMuzzleFlash()
    {
        //Debug.Log("Simulating");
        muzzleFlash.Play(true);
        //muzzleFlash.Simulate(10.0f);
        //muzzleFlash.Simulate(1.0f, true, false);
    }

    public void PlayHitEffect(Vector3 _pos, Vector3 _norm)
    {
        ParticleSystem _hitEffect = (ParticleSystem) Instantiate(hitEffectPrefab, _pos, Quaternion.LookRotation(_norm));
        Destroy(_hitEffect.gameObject, 2f);
    }
}
