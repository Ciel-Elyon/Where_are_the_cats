using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour {
    
    public float cooldownTime = 0f;

    private float currTime = 0f;

    private bool onCooldown = false;

    // Start is called before the first frame update
    void Start() {
        onCooldown = false;
    }

    // Update is called once per frame
    void Update() {
        if (!onCooldown)
            return;

        currTime += Time.deltaTime;
        if (currTime >= cooldownTime)
            onCooldown = false;
    }

    public void resetCooldown() {
        onCooldown = true;
        currTime = 0f;
    }

    public bool isOnCooldown() {
        return onCooldown;
    }
}
