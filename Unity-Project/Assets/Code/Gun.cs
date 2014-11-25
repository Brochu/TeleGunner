using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public SOGunData data;

    public void shoot(Vector3 direction)
    {
        // Add shoot logic
        Debug.Log("POW !");
        Debug.DrawRay(gameObject.transform.position, direction * 500, Color.red);
    }
}
