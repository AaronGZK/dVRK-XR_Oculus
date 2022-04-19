using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm1_outer_pitch_control : MonoBehaviour
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
        float val = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).eulerAngles.x;
        if (val > 180f) val = val - 360f;

        val = UDPSender.outer_pitch_joint_angle;        
        
        urdfJoint.SetJointValue(val);

    }
}
