using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovment : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movment;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        camUpdate();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.fixedDeltaTime);
        LookDir();
        fieldOfView.SetOrigin(rb.position);

    }
    void LookDir()// calculats the player angle of looking acording to mouse
    {

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        fieldOfView.SetAimDirection(new Vector3(lookDir.x, lookDir.y, (int)angle));

    }
    void camUpdate()// move cam wuth player
    {
        Vector3 playerPosition = transform.position;
        playerPosition.z = transform.position.z - 1;
        cam.transform.position = playerPosition;
    }
}