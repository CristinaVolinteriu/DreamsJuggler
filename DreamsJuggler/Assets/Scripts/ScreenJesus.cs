using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenJesus : MonoBehaviour
{
    public static ScreenJesus INSTANCE = null;
    private const float EXPLOSION_OFFSET = 1.2f;

    private Vector3 screenDimensions;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            if (INSTANCE != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    public void CheckIfTheFallingObjShouldBreak(FallingObjBehaviour fallingObj)
    {
        Transform fallingObjTransform = fallingObj.transform;
        Vector3 deathPos = new Vector3(fallingObjTransform.position.x, -screenDimensions.y + EXPLOSION_OFFSET, -1);

        if (fallingObjTransform.position.y <= -screenDimensions.y)
        {
            Instantiate(fallingObj.explosionPrefab, deathPos, Quaternion.identity);
            if (!GameManager.INSTANCE.GameOver)
            {
                GameManager.INSTANCE.LostObjects += 1;
            }
            Destroy(fallingObjTransform.gameObject);
        }
    }

    public void CheckIfTheFallingObjHitTheTopLimit(FallingObjBehaviour fallingObj)
    {
        Transform fallingObjTransform = fallingObj.transform;
        Rigidbody2D fallingObjRigidyBody = fallingObj.GetComponent<Rigidbody2D>();

        if (fallingObjTransform.position.y > screenDimensions.y + fallingObjTransform.localScale.y * 2)
        {
            fallingObjRigidyBody.velocity = Vector3.zero;
            fallingObjTransform.position = new Vector3(fallingObjTransform.position.x, screenDimensions.y + fallingObjTransform.localScale.y * 2, 0);
        }
    }

    public void CheckIfTheFallingObjHitTheMargins(FallingObjBehaviour fallingObj)
    {
        Transform fallingObjTransform = fallingObj.transform;
        Rigidbody2D fallingObjRigidyBody = fallingObj.GetComponent<Rigidbody2D>();

        if (fallingObjTransform.position.x <= -screenDimensions.x + fallingObjTransform.localScale.x / 2)
        {
            fallingObjRigidyBody.velocity = Vector3.zero;
            fallingObjRigidyBody.AddForce(fallingObjTransform.right * fallingObj.force / fallingObj.forceCalibration);
        }

        if (fallingObjTransform.position.x >= screenDimensions.x - fallingObjTransform.localScale.x / 2)
        {
            fallingObjRigidyBody.velocity = Vector3.zero;
            fallingObjRigidyBody.AddForce(fallingObjTransform.right * fallingObj.force / fallingObj.forceCalibration * -1);
        }
    }

    public void CheckIfPandaMarginIsHit(PandaBehaviour panda)
    {
        Transform pandaTransform = panda.transform;
        SpriteRenderer pandaSpriteRenderer = panda.gameObject.GetComponent<SpriteRenderer>();

        if (pandaTransform.position.x < -screenDimensions.x + pandaTransform.localScale.x / 2 ||
            pandaTransform.position.x > screenDimensions.x - pandaTransform.localScale.x / 2)
        {
            panda.speedX *= -1;

            if (panda.speedX > 0)
            {
                pandaSpriteRenderer.flipX = false;
            }
            else
            {
                pandaSpriteRenderer.flipX = true;
            }
        }
    }
}
