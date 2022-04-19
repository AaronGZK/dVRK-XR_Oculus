using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psm2_insertion_control : MonoBehaviour
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
        float val = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) * 0.24f;
        urdfJoint.SetJointValue(val);
    }
}
