using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGate : MonoBehaviour
{

	SpriteRenderer sp;
	SpriteRenderer[] sps;
	 int type;
	 bool Switch;
	public bool used;
	ParticleSystem[] particles;
	// Use this for initialization
	void Start ()
	{
		type = GetComponent<ElementColorControl> ().type;
		Switch = GetComponent<ElementColorControl> ().Switch;
		particles = GetComponentsInChildren<ParticleSystem> ();
		sps = GetComponentsInChildren<SpriteRenderer> ();
		used = false;
		sp = GetComponent<SpriteRenderer> ();
		if (type == 0) {
			if (Switch == false) {
				sp.color = new Color (0, 0, 0);
			} else
				sp.color = new Color (1, 1, 1);
		} else if (type == 1) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.red;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.red;
				}

			} else {
				//	sp.color = Color.green;
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.green;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.green;
				}
			}
		} else if (type == 2) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = new Color (1, .647f, 0);
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = new Color (1, .647f, 0);
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.blue;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.blue;
				}
			}
		} else if (type == 3) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.yellow;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.yellow;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.magenta;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.magenta;
				}
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		type = GetComponent<ElementColorControl> ().type;
		Switch = GetComponent<ElementColorControl> ().Switch;
		if (type == 0) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.gray;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.gray;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.white;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.white;
				}
			}
		} else if (type == 1) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.red;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.red;
				}

			} else {
				//	sp.color = Color.green;
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.green;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.green;
				}
			}
		} else if (type == 2) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = new Color (1, .647f, 0);
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = new Color (1, .647f, 0);
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.blue;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.blue;
				}
			}
		} else if (type == 3) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.yellow;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.yellow;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = Color.magenta;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = Color.magenta;
				}
			}
		}
		if (used) {
			foreach (ParticleSystem p in particles) {
				ParticleSystem.EmissionModule s = p.emission;
				s.enabled = false;
			}
			GetComponent<BoxCollider2D> ().enabled = false;
			sp.color = new Color (.1f, .1f, .1f);
			foreach (SpriteRenderer s in sps) {
				s.color = new Color (.5f, .5f, .5f);
			}

			//Destroy (gameObject);
		}
	}
}
