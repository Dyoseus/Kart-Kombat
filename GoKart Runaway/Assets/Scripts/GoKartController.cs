using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoKartController : MonoBehaviour
{
    [SerializeField] float acceleration = 5f;
    [SerializeField] float turnSpeed = 5f;

    Quaternion targetRotation;
    Rigidbody rb;

    Vector3 lastPosition;
    float sideSlipAmount = 0;

    

    public float SideSlipAmount{
        get{
            return sideSlipAmount;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        SetRotationPoint();
        SetSideSlip();
        
    }

    private void SetSideSlip(){
        Vector3 direction = transform.position - lastPosition;
        Vector3 movement = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;

        sideSlipAmount = movement.x;
    }

    private void SetRotationPoint(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if(plane.Raycast(ray, out distance)){
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }

    private void FixedUpdate()
    {
        float accelerationInput = acceleration * (Input.GetMouseButton(0)? 1: Input.GetMouseButton(1)? -1 : 0) * Time.fixedDeltaTime;
        rb.AddRelativeForce(Vector3.forward * accelerationInput);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);  
    }
}