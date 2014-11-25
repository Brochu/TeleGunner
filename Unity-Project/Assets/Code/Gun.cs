using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public SOGunData data = null;
    public GameObject tempHitEffect = null;

    public void shoot(Vector3 direction)
    {
        // Add shoot logic
        Debug.Log("POW !");
        Debug.DrawRay(gameObject.transform.position, direction * 500, Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(gameObject.transform.position, direction * 500, out hitInfo, 500))
        {
            Object o = Instantiate(tempHitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.transform.forward));
            StartCoroutine(killHitEffect(o));
        }
    }

    IEnumerator killHitEffect(Object o)
    {
        yield return new WaitForSeconds(0.5f);

        Debug.Log("Destroy hit effect");
        Object.Destroy(o);
    }
}
