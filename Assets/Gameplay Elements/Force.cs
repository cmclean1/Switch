using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Force : MonoBehaviour {
	public int direction;
	public GameObject particle;
	public float strength;
	public GameObject part;
	public List<GameObject> parts;
	/*
	 * 0 = right
	 * 1 = down
	 * 2 = left
	 * 3 = up
	 * */
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float range;
		switch (direction) {
		case 0:
			range = Random.Range (transform.position.y - (transform.localScale.y * .5f), transform.position.y + (transform.localScale.y * .5f));
			part = Instantiate (particle, transform) as GameObject;
			part.transform.position = new Vector2 (transform.position.x - (transform.localScale.x * .5f)+.01f, range);
			parts.Add(part);
			break;	
		case 1:
			range = Random.Range (transform.position.x - (transform.localScale.x * .5f), transform.position.x + (transform.localScale.x * .5f));
			part = Instantiate (particle, transform) as GameObject;
			part.transform.position = new Vector2 (range, transform.position.y + (transform.localScale.y * .5f)-.01f);
			//particle.transform.parent = gameObject.transform;
			parts.Add(part);
			break;	
		case 2:
			range = Random.Range (transform.position.y - (transform.localScale.y * .5f), transform.position.y + (transform.localScale.y * .5f));
			part = Instantiate (particle, transform) as GameObject;
			//particle.transform.parent = gameObject.transform;
			part.transform.position = new Vector2 (transform.position.x + (transform.localScale.x * .5f)-.01f, range);
			parts.Add(part);
			break;	
		case 3:
			 range = Random.Range (transform.position.x - (transform.localScale.x * .5f), transform.position.x + (transform.localScale.x * .5f));
			part = Instantiate (particle, transform) as GameObject;
			//particle.transform.parent = gameObject.transform;
			part.transform.position = new Vector2 (range, transform.position.y - (transform.localScale.y * .5f)+.01f);
			parts.Add(part);
			break;	
		}
		parts.Clear ();
	}
}
