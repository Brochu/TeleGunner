using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Constant used to check if input axis close to 0
    private const float EPSILON = 0.0001f;

    // Use this for initialization
    void Start () {
        // Get useful components
    }
    
    // Update is called once per frame
    void Update () {

        // TODO: Get player presses and handle behaviour
        transform.position += getPlayerDesiredMoveDirection();
        transform.rotation = getPlayerDesiredLookDirection();
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
        return Quaternion.AngleAxis(0.0f, transform.forward);
    }
}
