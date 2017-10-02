using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
	Announcer announcer;
	Collider2D[] Backgrounds;
	Collider2D squareOn;
	SpriteRenderer squareColor;
	public int type;
	public bool Switch;
	public SpriteRenderer sp;
	Vector2 dieScale;
	GameObject controlla;
	LevelControlla control;
	bool dying;
	Color switchColor;
	public Color currentColor;
	public bool touchedGate;
	public GameObject colorGateIndicator;
	public bool blackOrWhite;
	float deathRate;
	float restoreRate;
	float colorGateStart;
	float colorGateEnd;
	float ColorGateDuration;
	// Use this for initialization
	void Start ()
	{
		announcer = Announcer.announcer;
		blackOrWhite = true;
		type = 0;
		Switch = false;
		sp = GetComponent<SpriteRenderer> ();
		if (type == 0) {
			sp.color = new Color (.15f, .15f, .15f);
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = Color.red;
			} else
				sp.color = Color.green;
		} else if (type == 2) {
			if (Switch == false) {
				sp.color = new Color (1, .647f, 0);
			} else
				sp.color = Color.blue;
		} else if (type == 3) {
			if (Switch == false) {
				sp.color = Color.yellow;
			} else
				sp.color = Color.magenta;
		}
		switchColor = Color.white;
		currentColor = Color.white;
		dying = false;
		dieScale = transform.localScale;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		control = LevelControlla.control;
		transform.position = control.transform.position;
		touchedGate = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (type == 0) {
		} else if (type == 1) {
			if (Switch == false) {
				switchColor = Color.red;
			} else
				switchColor = Color.green;
		} else if (type == 2) {
			if (Switch == false) {
				switchColor = new Color (1, .647f, 0);
			} else
				switchColor = Color.blue;
		} else if (type == 3) {
			if (Switch == false) {
				switchColor = Color.yellow;
			} else
				switchColor = Color.magenta;
		}
		Backgrounds = Physics2D.OverlapPointAll (transform.position);
		if (Backgrounds.Length != 0) {
			squareOn = Backgrounds [0];
		}
		if (squareOn == null) {
		} else
			squareColor = squareOn.gameObject.GetComponent<SpriteRenderer> ();
		if (Backgrounds.Length == 0) {
			squareColor = null;
		}
		if (squareOn != null) {
			foreach (Collider2D bg in Backgrounds) {
				squareOn = bg;	
				if (squareOn.gameObject.tag == "ColorGate" && !touchedGate) {
					touchedGate = true;
					blackOrWhite = true;
					StartCoroutine (gateSwitch ());
					colorGateStart = Time.time;
					colorGateEnd = Time.time + 2f;
					sp.color = Color.white;
					Switch = squareOn.gameObject.GetComponent<ElementColorControl> ().Switch;
					type = squareOn.gameObject.GetComponent<ElementColorControl> ().type;
					squareOn.gameObject.GetComponent<ColorGate> ().used = true;
					colorGateIndicator.GetComponent<SpriteRenderer> ().color = new Color (squareColor.color.r, squareColor.color.g, squareColor.color.b, .5f);
					Instantiate (colorGateIndicator, transform.position, Quaternion.identity);
				} else if (squareOn.gameObject.tag == "Goal") {
					sp.color = Color.white;
					Destroy (gameObject);
					control.nextLevel = true;
					print (control.maxLevel > control.whichLevel);
					if (control.maxLevel > control.whichLevel) {
						if (ManageSaveData.control.levelUnlocked == control.whichLevel) {
							ManageSaveData.control.levelUnlocked = control.whichLevel + 1;
						}
					}
				} else if (squareOn.gameObject.tag == "PowerGate") {
					if (!squareOn.gameObject.GetComponent<ColorGate> ().used) {
						controlla.GetComponent<ManagePowerups> ().powerUps [squareOn.gameObject.GetComponent<PowerGate> ().whichPower] += squareOn.gameObject.GetComponent<PowerGate> ().powerAmount;
						displayPower (squareOn.gameObject.GetComponent<PowerGate> ().whichPower, squareOn.gameObject.GetComponent<PowerGate> ().powerAmount);
					}
					squareOn.gameObject.GetComponent<ColorGate> ().used = true;

				}
				if (squareOn.GetComponent ("Force") != null) {
					if (squareOn.GetComponent<Force> ().enabled) {
						getForced (squareOn.GetComponent<Force> ().direction);
					}
				}
				if (squareOn.GetComponent<isButton> () != null) {
					squareOn.GetComponent<isButton> ().activated = true;
				}
			}
		}
		if (squareColor != null) {
			if (squareColor.color == Color.white || squareColor.color == currentColor || touchedGate) {
				dying = false;
			} else if (squareColor.color == switchColor && !touchedGate) {
				blackOrWhite = false;
				sp.color = currentColor;
				currentColor = switchColor;
				Switch = !Switch;
			} else if (squareColor.color != switchColor && !touchedGate) {
				dying = true;
			}
		} else {  
			if (Backgrounds.Length == 0 && !touchedGate) {
				dying = true;
			}
		}
		die ();

	}

	void displayPower (int whichPower, int powerAmount)
	{
		print ("ues");
		switch (whichPower) {
		case 0:
			if (powerAmount == 1) {
				announcer.Display ("Powerup: increased fov!");
			} else if (powerAmount == -1) {
				announcer.Display ("Powerdown: decreased fov!");
			}
			break;
		case 1:
			if (powerAmount == 1) {
				announcer.Display ("Powerup: increased speed!");
			} else if (powerAmount == -1) {
				announcer.Display ("Powerdown: decreased speed!");
			}
			break;
		case 2:
			if (powerAmount == 1) {
				announcer.Display ("Powerup: slower shrinking!");
			} else if (powerAmount == -1) {
				announcer.Display ("Powerdown: faster shrinking!");
			}
			break;
		}
	}

	void getForced (int direction)
	{
		Rigidbody2D rb2d = GetComponent<Rigidbody2D> ();
		float vel = 6;
		switch (direction) {
		case 0:
			rb2d.AddForce (new Vector2 (vel, 0));
			break;
		case 1:
			rb2d.AddForce (new Vector2 (0, -vel));
			break;
		case 2:
			rb2d.AddForce (new Vector2 (-vel, 0));		
			break;
		case 3:
			rb2d.AddForce (new Vector2 (0, vel));
			break;
		}

	}

	void GateSwitch ()
	{
		if (Time.time > colorGateEnd && touchedGate) {
			touchedGate = false;
			blackOrWhite = false;

			if (type == 0) {
				if (Switch == false) {
					sp.color = new Color (0, 0, 0);
				} else
					sp.color = new Color (1, 1, 1);
			} else if (type == 1) {
				if (Switch == false) {
					sp.color = Color.red;
					currentColor = Color.green;
				} else {
					sp.color = Color.green;
					currentColor = Color.red;
				}
			} else if (type == 2) {
				if (Switch == false) {
					sp.color = new Color (1, .647f, 0);
					currentColor = Color.blue;
				} else {
					sp.color = Color.blue;
					currentColor = new Color (1, .647f, 0);
				}
			} else if (type == 3) {
				if (Switch == false) {
					sp.color = Color.yellow;
					currentColor = Color.magenta;
				} else {
					sp.color = Color.magenta;
					currentColor = Color.yellow;
				}
			}

		}
	}

	IEnumerator gateSwitch ()
	{
		yield return new WaitForSeconds (2);
		touchedGate = false;
		blackOrWhite = false;

		if (type == 0) {
			if (Switch == false) {
				sp.color = new Color (0, 0, 0);
			} else
				sp.color = new Color (1, 1, 1);
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = Color.red;
				currentColor = Color.green;
			} else {
				sp.color = Color.green;
				currentColor = Color.red;
			}
		} else if (type == 2) {
			if (Switch == false) {
				sp.color = new Color (1, .647f, 0);
				currentColor = Color.blue;
			} else {
				sp.color = Color.blue;
				currentColor = new Color (1, .647f, 0);
			}
		} else if (type == 3) {
			if (Switch == false) {
				sp.color = Color.yellow;
				currentColor = Color.magenta;
			} else {
				sp.color = Color.magenta;
				currentColor = Color.yellow;
			}
		}


		//currentColor = Color.magenta;

	}

	void die ()
	{
		if (controlla.GetComponent<ManagePowerups> ().powerUps [2] == 1) {
			deathRate = .005f;
			restoreRate = .02f;
		} else if (controlla.GetComponent<ManagePowerups> ().powerUps [2] == -1) {
			deathRate = .02f;
			restoreRate = .0025f;
		} else {
			deathRate = .01f;
			restoreRate = .005f;
		}
		if (dying) {
			dieScale.x -= deathRate;
			dieScale.y -= deathRate;
			if (transform.localScale.x <= .2f) {
				control.dead = true;
				Destroy (gameObject);
			}
		} else {
			dieScale.x += restoreRate;
			dieScale.y += restoreRate;
			if (transform.localScale.x >= 1f) {
				dieScale.x = 1;
				dieScale.y = 1;
			}
		}
		transform.localScale = dieScale;

	}
}
