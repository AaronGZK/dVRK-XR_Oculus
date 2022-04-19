using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm2_outer_wrist_pitch_control : MonoBehaviour
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
        float val = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y * 90f;
        urdfJoint.SetJointValue(val);
    }
}
