using Polarith.AI.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public GameObject deathParticles;

    public AudioClip yikesClip;
    public AudioClip squeakClip;
    public AudioClip[] yummyClips;

    Animator animator;
    AIMSimpleController ai;
    AudioSource audio;

    public bool cheeseEaten = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ai = GetComponent<AIMSimpleController>();
        audio = GetComponent<AudioSource>();

        cheeseEaten = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void die() {
        ai.enabled = false;
        animator.SetTrigger("Die");
        var particles = GameObject.Instantiate(deathParticles, gameObject.transform);
        particles.transform.Translate(Vector3.up * .5f);
        audio.PlayOneShot(yikesClip);
    }

    public void cheer() {
        ai.enabled = false;
        animator.SetTrigger("Survive");
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Goal") {
            cheer();
            var temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelController>();
            temp.SetLoseText();
            temp.ShowButtons();
        }
        else if(other.tag == "cheese")
        {
            PlayEatCheeseSound();
            Destroy(other.gameObject);
        }
         
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Goal") {
            cheer();
            var temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelController>();
            temp.SetLoseText();
            temp.ShowButtons();
            audio.PlayOneShot(squeakClip);
        }
    }

    public void PlayEatCheeseSound() {
        foreach (var clip in yummyClips)
            audio.PlayOneShot(clip);
    }
}
