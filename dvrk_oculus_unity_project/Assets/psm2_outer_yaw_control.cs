using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm2_outer_yaw_control : MonoBehaviour
{
    private DVRK.URDFJoint urdfJoint;

    // Start is called before the first frame update
    void Start()
    {
        urdfJoint = GetComponent<DVRK.URDFJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float val = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).eulerAngles.y;
        if (val > 180f) val = val - 360f;
        
        urdfJoint.SetJointValue(-val);
    }
}
