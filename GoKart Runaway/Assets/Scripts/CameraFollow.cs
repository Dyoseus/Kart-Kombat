using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform observable;
    [SerializeField] float aheadSpeed;
    [SerializeField] float followDamping;
    [SerializeField] float cameraHeight;
    [SerializeField] float zOffset; // New Z axis offset parameter
 
    Rigidbody observableRigidBody;

    void Start()
    {
        observableRigidBody = observable.GetComponent<Rigidbody>();

        // Set the camera's parent to null so that it is no longer a child of the player
        transform.parent = null;
    }

    void Update()
    {
        if (observable == null)
        {
            return;
        }

        Vector3 targetPosition = observable.position + new Vector3(0f, cameraHeight, zOffset) + observableRigidBody.velocity * aheadSpeed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followDamping * Time.deltaTime);
    }
}
