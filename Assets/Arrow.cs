using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public GameObject player;
	public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		goal = GameObject.FindGameObjectWithTag("Goal");

    }
    // Update is called once per frame
    void Update()
    {
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		else
		{
			Vector2 dist = new Vector2(goal.gameObject.transform.position.x-player.gameObject.transform.position.x, goal.gameObject.transform.position.y-player.gameObject.transform.position.y);
			dist.Normalize();
			float angle = Mathf.Atan(dist.y/dist.x);

			gameObject.transform.position = new Vector3(player.gameObject.transform.position.x+3f*dist.x,player.gameObject.transform.position.y + 3f*dist.y, -2);
			gameObject.transform.rotation = Quaternion.Euler(0,0,angle*(180/Mathf.PI)-90);
            if(dist.x < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, angle * (180 / Mathf.PI) + 90);

            }
        }
    }
}
