using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecm_insertion_control : MonoBehaviour
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
        float x = Camera.main.transform.position.x;
        float y = Camera.main.transform.position.y;
        float z = Camera.main.transform.position.z;
        if (z<=0) z = 0;
        float val = Mathf.Sqrt(x*x+z*z) * 3f;
        urdfJoint.SetJointValue(val);
    }
}
