using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MysteryController : MonoBehaviour {
    // prefabs to choose from
    public GameObject catPrefab;
    public GameObject cheesePrefab;
    public GameObject smokeParticle;

    private AudioSource audio;
    private SphereCollider collider;
    private MeshRenderer renderer;

    public AudioClip[] poofSounds;

    [Header("Probability that the cat is spawned instead of the cheese.")]
    [Range(1, 100)]
    public int catProb = 50;

    // reference to the prefab we instantiated
    private GameObject prefabInstance;

    // reference to the cooldown manager
    CooldownManager cooldownManager;

    // bool to set that we will delete ourselves
    private bool setDelete = false;

    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
        collider = GetComponent<SphereCollider>();
        renderer = GetComponentInChildren<MeshRenderer>();
        int choice = UnityEngine.Random.Range(0, 100);
        Vector3 newPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        if (choice < catProb) {
            prefabInstance = GameObject.Instantiate(catPrefab, newPos, Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 359.99f), Vector3.up));
            prefabInstance.transform.parent = GameObject.FindGameObjectWithTag("Avoidance").transform;
        }
        else {
            prefabInstance = GameObject.Instantiate(cheesePrefab, newPos, Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 359.99f), Vector3.up));
            prefabInstance.transform.parent = GameObject.FindGameObjectWithTag("Collectable").transform;
        }
        prefabInstance.SetActive(false);

        // get the cooldown manager
        cooldownManager = GameObject.FindGameObjectWithTag("CooldownManager").GetComponent<CooldownManager>();
    }

    // Update is called once per frame
    void Update() {
        if (setDelete) {
            collider.enabled = false;
            renderer.enabled = false;
}
    }

    // was chosen to be flipped
    private void OnMouseDown() {
        // do nothing if on cooldown
        if (cooldownManager.isOnCooldown())
            return;

        // TODO: flip animation
        StartCoroutine("CoFlipAnimation");

        // activate what was hidden
        prefabInstance.SetActive(true);

        // reset the cooldown
        cooldownManager.resetCooldown();
    }

    bool coFlipStarted = false;
    IEnumerator CoFlipAnimation() {
        if (coFlipStarted)
            yield break;
        coFlipStarted = true;

        // TODO: animation, sounds, and game feel (maybe a poof of smoke to reveal what's there
        GameObject.Instantiate(smokeParticle, transform.position, Quaternion.identity);
        audio.PlayOneShot(poofSounds[UnityEngine.Random.Range(0, poofSounds.Length)]);

        // then delete self
        setDelete = true;

        yield break;
    }
}
