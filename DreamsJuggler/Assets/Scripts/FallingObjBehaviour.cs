using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjBehaviour : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float force;
    public float forceCalibration = 2.5f;

    private Vector3 myUp;
    private Rigidbody2D fallingObj;

    private void Start ()
    {
        fallingObj = transform.GetComponent<Rigidbody2D>();
        myUp = transform.TransformDirection(Vector3.up);
    }

    private void FixedUpdate()
    {
        ScreenJesus.INSTANCE.CheckIfTheFallingObjHitTheTopLimit(this);
        ScreenJesus.INSTANCE.CheckIfTheFallingObjHitTheMargins(this);
    }

    private void Update()
    {
        ScreenJesus.INSTANCE.CheckIfTheFallingObjShouldBreak(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FallingObj"))
        {
            Rigidbody2D hitObj = col.rigidbody;
            if(hitObj.transform.position.y >= transform.position.y)
            {
                 hitObj.AddForce(myUp * force);
            }
        }
    }

    public void BoostUp()
    {
        fallingObj.velocity = Vector3.zero;
        fallingObj.AddForce(myUp * force);
    }
}
