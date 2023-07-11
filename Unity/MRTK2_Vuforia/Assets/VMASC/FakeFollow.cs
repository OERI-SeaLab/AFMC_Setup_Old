using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFollow : MonoBehaviour
{

    public Transform Target;
    public void Update()
    {
        if(Target != null)
        {
            this.transform.position = Target.position;
        }
    }
}
