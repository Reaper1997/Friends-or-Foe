using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(AudioSource))]

public class NewBehaviourScript : MonoBehaviour {

    AudioClip[] ground;
    bool step = true;
    double audioStepLengthWalk = 0.45;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Ground" && step == true || controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Untagged" && step == true)
        {
            walkOnGroud();
        }
        else
        {

        }
    }

    IEnumerator walkOnGroud()
    {
        step = false;
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = ground[Random.Range(0, ground.Length)];
        audio.volume = (float) 0.1;
        audio.Play();
        yield return new WaitForSeconds((float) audioStepLengthWalk);
        step = true;
    }

}
