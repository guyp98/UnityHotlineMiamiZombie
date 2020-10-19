using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeColdWepon : ItemObject
{
    public float range;
    public float damage;
    public float spanInAngles;

    //ray cast
    [SerializeField] private LayerMask layerMask;
    private float fov;
    private float viewDistance;
    private Vector3 origin;
    private float startingAngle;

    public void Awake()
    {
        fov = spanInAngles;
        viewDistance = range;
        origin = Vector3.zero;
    }

    public override void attack()
    {
       

       int rayCount = 60;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
           Debug.Log(raycastHit2D.collider==true);
            if (raycastHit2D.collider == null)
            {
                
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //Debug.Log("aaa");
                // Hit object
                vertex = raycastHit2D.point;
                GameObject gotHit = raycastHit2D.collider.gameObject;
                enemyHealth enemyHealth= gotHit.GetComponent<enemyHealth>();
                if (enemyHealth!=null)
                {
                    enemyHealth.Gothit(damage);
                    break;
                }
            }
            Debug.DrawRay(origin,vertex,new Color(),1f);
            angle -= angleIncrease;

        }
    }


    

    public override void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }

    public override void SetOrigin(Vector3 origin)
    {
        
        this.origin = origin;
    }
}
