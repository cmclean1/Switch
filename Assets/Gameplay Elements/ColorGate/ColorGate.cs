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
				sp.color = ColorLibrary.colorLib.grey;
			} else
				sp.color = ColorLibrary.colorLib.white;
		} else if (type == 1) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.red;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.red;
				}

			} else {
				//	sp.color = ColorLibrary.colorLib.green;
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.green;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.green;
				}
			}
		} else if (type == 2) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.orange;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.orange;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.blue;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.blue;
				}
			}
		} else if (type == 3) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.yellow;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.yellow;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.purple;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.purple;
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
					tt.color = ColorLibrary.colorLib.grey;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.grey;
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
					tt.color = ColorLibrary.colorLib.red;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.red;
				}

			} else {
				//	sp.color = ColorLibrary.colorLib.green;
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.green;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.green;
				}
			}
		} else if (type == 2) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.orange;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.orange;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.blue;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.blue;
				}
			}
		} else if (type == 3) {
			if (Switch == false) {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.yellow;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.yellow;
				}
			} else {
				foreach (SpriteRenderer tt in sps) {
					tt.color = ColorLibrary.colorLib.purple;
				}
				foreach (ParticleSystem p in particles) {
					ParticleSystem.MainModule s = p.main;
					s.startColor = ColorLibrary.colorLib.purple;
				}
			}
		}
		if (used) {
			foreach (ParticleSystem p in particles) {
				ParticleSystem.EmissionModule s = p.emission;
				s.enabled = false;
			}
			GetComponent<BoxCollider2D> ().enabled = false;
			sp.color = ColorLibrary.colorLib.grey;
			foreach (SpriteRenderer s in sps) {
				s.color = ColorLibrary.colorLib.grey;
			}

			//Destroy (gameObject);
		}
	}
}
