using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecm_outer_yaw_control : MonoBehaviour
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
        float val = Camera.main.transform.rotation.eulerAngles.y;
        if (val > 180f) val = val - 360f;
        val = -val*3f;
        urdfJoint.SetJointValue(val);
    }
}
