using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mace_movement : MonoBehaviour
{
    public AnimationCurve myCurve;

    //Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z); //Creates a curve in whihc the gameObject follows its set path
    }
}
