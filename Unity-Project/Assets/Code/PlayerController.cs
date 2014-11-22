using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera playerCam = null;

    // Constant used to check if input axis close to 0
    private bool updating = true;

    private const float EPSILON = 0.0001f;

    // Use this for initialization
    void Start () {

        if (playerCam == null)
        {
            updating = false;
            Debug.LogWarning("---- Player Camera property is not set for " + name + "! ----");
        }
    }
    
    // Update is called once per frame
    void Update () {

        if (!updating)
            return;

        gameObject.transform.position += getPlayerDesiredMoveDirection();
        gameObject.transform.rotation *= getPlayerDesiredLookDirection();
        playerCam.gameObject.transform.rotation *= getPlayerDesiredLookPitch();
    }

    private Vector3 getPlayerDesiredMoveDirection()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += (-1 * transform.forward);
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.Cross(transform.forward, transform.up);
        if (Input.GetKey(KeyCode.D))
            moveDirection += (-1 * Vector3.Cross(transform.forward, transform.up));

        return moveDirection;
    }

    private Quaternion getPlayerDesiredLookDirection()
    {
         return Quaternion.AngleAxis(Input.GetAxis("Mouse X") * BasicConfig.mouseSensitivity, transform.up);
    }

    private Quaternion getPlayerDesiredLookPitch()
    {
        return Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * BasicConfig.mouseSensitivity, Vector3.left);
    }
}
