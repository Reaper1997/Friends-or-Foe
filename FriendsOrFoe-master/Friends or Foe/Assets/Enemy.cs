
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float health = 50f;

	public void damageTaken(float amount){
		health -= amount;
		if(health<=0f){
			die ();
		}
	}

	void die(){
		Destroy (gameObject);
	}

}
