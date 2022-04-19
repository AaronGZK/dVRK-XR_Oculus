using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm1_yaw_control : MonoBehaviour
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
        float val = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) * 90f;
        urdfJoint.SetJointValue(val);
    }
}
