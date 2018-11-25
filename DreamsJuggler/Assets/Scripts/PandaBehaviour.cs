using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaBehaviour : MonoBehaviour
{
    private Vector3 temporaryPosition;
    private float offset;

    public float speedX, speedY, radius;
    
	private void Start ()
    {
        temporaryPosition = transform.position;
        offset = transform.position.y;
    }

    private void Update ()
    {
        PandaMovement();
        ScreenJesus.INSTANCE.CheckIfPandaMarginIsHit(this);
    }

    private void PandaMovement()
    {
        temporaryPosition.x += speedX * Time.deltaTime;
        temporaryPosition.y = Mathf.Sin(speedY * Time.realtimeSinceStartup) * radius + offset;
        transform.position = temporaryPosition;
    }
}
