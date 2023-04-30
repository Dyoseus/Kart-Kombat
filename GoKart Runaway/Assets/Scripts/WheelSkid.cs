using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSkid : MonoBehaviour
{
    [SerializeField] float intensityModifier = 1.5f;

    Skidmarks skidMarkcontroller;
    GoKartController GoKartController;

    int lastSkidId = -1;

    // Start is called before the first frame update
    void Start()
    {
        skidMarkcontroller = FindObjectOfType<Skidmarks>();
        GoKartController = GetComponentInParent<GoKartController>();
    }

    // Update is called once per frame
    void Update()
    {

        float intensity = GoKartController.SideSlipAmount;
        if(intensity < 0) {
            intensity = -intensity;
        }

        if(intensity > 0.17f){
            lastSkidId = skidMarkcontroller.AddSkidMark(transform.position, transform.up, intensity * intensityModifier, lastSkidId);
        } else {
            lastSkidId = -1;
        }
        
    }
}
