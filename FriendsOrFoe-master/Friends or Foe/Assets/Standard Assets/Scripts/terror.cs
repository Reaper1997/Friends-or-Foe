using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terror : MonoBehaviour {
    public GameObject scareObject;
    public bool played = false;
    public bool trig = false;
    public Renderer render;
    public AudioClip scareSound;
	void Start () {
        render = GetComponent<Renderer>();
        played = false;
        render.enabled = false;
	}

    void onTriggerEnter(Collider other)
    {
        trig = true;
    }

	void Update () {
        render = GetComponent<Renderer>();
        if (trig == true)
        {
            render.enabled = true;
            removeOverTime();
            makeThemScream();
        }
	}

    IEnumerator removeOverTime()
    {
        yield return new WaitForSeconds((float)0.6);
    }

    void makeThemScream()
    {
        if (!played)
        {
            played = true;
            AudioSource audio = new AudioSource();
            audio.PlayOneShot(scareSound); 
        }
    }
}
