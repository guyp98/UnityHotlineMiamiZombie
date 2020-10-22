using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public GameObject player;
    public Rigidbody2D rb;
    public float waitTime = 2f;
    public float moveSpeed = 3f;
    public float directionChangeTime = 1f;
    private GameObject lastPlayerPosition;
    private float latestDirectionChangeTime;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private bool isWaiting;
    public Vector3 bottomLeftLimit;
    public Vector3 topRightLimit;
    // Start is called before the first frame update
    void Start()
    {
        isWaiting = false;
        latestDirectionChangeTime = 0f;
        lastPlayerPosition = player;
        bottomLeftLimit = new Vector3(rb.position.x - 3, rb.position.y - 3, 0);
        topRightLimit = new Vector3(rb.position.x + 3, rb.position.y + 3, 0);
        CalcuateNewMovementVector();
    }

    // Update is called once per frame
    void Update()
    {
        // If the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime && !isWaiting)
        {
            isWaiting = true;
            Invoke("InvokeIsWaiting", waitTime);
            movementPerSecond = Vector3.zero;
        }
        // Move enemy 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
 
        // $$anonymous$$eep the enemy inside the bounds of a particular area
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
        Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
        //Debug.Log(transform.position.x +" " + transform.position.y + " " + transform.position.z);

        // rotate the enemy and navMesh
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * (Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);

        fieldOfView.SetOrigin(rb.position);
        fieldOfView.SetAimDirection(new Vector3(movementDirection.x, movementDirection.y, angle));
    }
    void InvokeIsWaiting()
    {
        latestDirectionChangeTime = Time.time;
        CalcuateNewMovementVector();
        isWaiting = false;
    }

    void CalcuateNewMovementVector()
    {
        // Create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
    }
}

