using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.Mathematics;

public class enemyGFX : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public GameObject FOV;
    //public AIPath aiPath;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool isBoss = false;
    public float range = 5f;
    public GameObject enemy;
    public RandomMove RanMove;

    void Start()
    {
    }
    private void FixedUpdate()
    {
        
        //LookDir();
        CheckCollider();
        
    }
    public void CheckCollider()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance <= range)
        {
            Vector2 lookDir = new Vector2(player.transform.position.x, player.transform.position.y) - rb.position;
            float angleDraw = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angleDraw;
            transform.GetComponent<AIPath>().canMove = true;
            RanMove.enabled = false;
        }
        else
        {
            Vector2 lookDir = new Vector2(player.transform.position.x, player.transform.position.y) - rb.position;
            float angleDraw = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.GetComponent<AIPath>().canMove = false;
            FOV.SetActive(true);
            fieldOfView.SetOrigin(rb.position);
            fieldOfView.SetAimDirection(new Vector3(lookDir.x, lookDir.y, (int)angleDraw));
            RanMove.bottomLeftLimit = new Vector3(enemy.transform.position.x - 3, enemy.transform.position.y - 3, 0);
            RanMove.topRightLimit = new Vector3(enemy.transform.position.x + 3, enemy.transform.position.y + 3, 0);
            RanMove.enabled = true;
            this.enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        enemy.GetComponent<AIPath>().maxSpeed = speed;
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "player")
        {
            //Debug.Log("decrease health");
            collider.gameObject.GetComponent<HealthSystem>().SubHealth(1);
        }
    }
}
