using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecm_outer_pitch_control : MonoBehaviour
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
        float val = Camera.main.transform.rotation.eulerAngles.x;
        if (val > 180f) val = val - 360f;
        val = val*6f;
        urdfJoint.SetJointValue(val);
    }
}
