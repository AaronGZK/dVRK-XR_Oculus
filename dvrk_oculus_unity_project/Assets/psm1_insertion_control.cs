using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm1_insertion_control : MonoBehaviour
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
        float val = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) * 0.24f;

        val = UDPSender.outer_insertion_joint_angle;

        urdfJoint.SetJointValue(val);
    }
}
