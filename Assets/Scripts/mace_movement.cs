using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mace_movement : MonoBehaviour
{
    public AnimationCurve myCurve;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    //Update is called once per frame
    void Update()
    {
        //Creates a curve in whihc the gameObject follows its set path
        transform.position = new Vector3(
            transform.position.x,
            startY + myCurve.Evaluate((Time.time % myCurve.length)),
            transform.position.z
        );
    }
}
