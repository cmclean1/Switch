using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    GameObject controlla;
    float detectionRadius = 7;
    public bool attacking;
    public GameObject black;
    bool setTime = true;
    float time = 0;
    float rotation;
    int moveType;
    float moveTime;
    /* 0 = left
     * 1 = down-left
     * 2 = down
     * 3 = down-right
     * 4 = right
     * 5 = up-right
     * 6 = up
     * 7 = up-left
     */ 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<SpriteRenderer>().color = ColorLibrary.colorLib.grey;
        controlla = GameObject.FindGameObjectWithTag("Controlla");

        //rotation = 0;

        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
            setTime = true;
        }
        if (attacking)
        {
            GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
            attack();
        }


    }
    void checkMove()
    {
        Vector2 dist = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
        dist.Normalize();
        if (dist.x < .1 && dist.x > -.1 && dist.y > 0)//down
        {
            moveType = 2;
            rotation = 90f;
        }
        else if (dist.x < .1 && dist.x > -.1 && dist.y < 0)//up
        {
            moveType = 6;
            rotation = 90f;
        }
        else if (dist.y < .1 && dist.y > -.1 && dist.x < 0)//left
        {
            moveType = 0;
            rotation = 0;
        }
        else if (dist.y < .1 && dist.y > -.1 && dist.x > 0)//right
        {
            moveType = 4;
            rotation = 0;
        }
        else if (dist.y > 0 && dist.x > 0)//down-left
        {
            moveType = 1;
            rotation = -45;
        }
        else if (dist.y > 0 && dist.x < 0)//down-right
        {
            moveType = 3;
            rotation = 45;
        }
        else if (dist.y < 0 && dist.x > 0)//up-left
        {
            moveType = 7;
            rotation = -45;
        }
        else if (dist.y < 0 && dist.x < 0)//up-right
        {
            moveType = 5;
            rotation = 45;
        }
    }

    void attack()
    {
        switch (moveType)
        {
            case 0:
                transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y - .1f);
                break;
            case 1:
                transform.position = new Vector2(transform.position.x - .1f, transform.position.y - .1f);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x + .1f, transform.position.y - .1f);
                break;
            case 7:
                transform.position = new Vector2(transform.position.x - .1f, transform.position.y + .1f);
                break;
            case 5:
                transform.position = new Vector2(transform.position.x + .1f, transform.position.y + .1f);
                break;
            case 4:
                transform.position = new Vector2(transform.position.x - .1f, transform.position.y);
                break;
            case 6:
                transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
                break;
            default:
                // transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
                break;
        }
        if (time < Time.time)
        {
            GameObject snake = Instantiate(black, transform.position, Quaternion.Euler(0, 0, rotation));
            snake.transform.localScale = new Vector3(.7f, .7f, 1);
            time = Time.time + .04f;
        }
        if (moveTime < Time.time)
        {
            moveTime = Time.time + .3f;
            checkMove();

        }
        // Vector3 dis = (transform.position - player.transform.position);
        //rb2d.drag = 1;
        // dis = Vector3.Normalize(dis);
        // rb2d.AddForce(dis * -Random.Range(9f, 11f));
    }
}
