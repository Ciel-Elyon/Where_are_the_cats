using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: lol this actually became a cat controller

public class WinLoseCollider : MonoBehaviour {
    GameObject rat;

    // Start is called before the first frame update
    void Start() {
        rat = GameObject.FindGameObjectWithTag("Rat");
    }

    // Update is called once per frame
    void Update() {
        var dir = Vector3.Normalize(rat.transform.position - transform.position);
        transform.forward = dir;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == rat) {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<LevelController>().ShowButtons();
            rat.GetComponent<RatController>().die();
        }
    }
}
