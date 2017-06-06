using UnityEngine;

public class gunScript : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;

	public Camera cam;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			shoot ();
		}
	}

	public void shoot(){
		RaycastHit ray;
		if(Physics.Raycast (cam.transform.position, cam.transform.forward, out ray, range)){
			Debug.Log (ray.transform.name);

			Enemy enemy = ray.transform.GetComponent<Enemy> ();
			if(enemy != null){
				enemy.damageTaken (damage);
			}
		}

	}
}
