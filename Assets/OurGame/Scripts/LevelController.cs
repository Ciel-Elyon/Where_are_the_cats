using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    public GameObject[] buttons;

    public GameObject winLossText;

    // Start is called before the first frame update
    void Start() {
        foreach (var button in buttons) {
            if (button != null)
                button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel() {
        SceneManager.LoadScene(1);
    }

    public void LoadTitle() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ShowButtons() {
        foreach (var button in buttons) {
            if (button != null)
                button.SetActive(true);
        }
    }

    public void SetLoseText() {
        if (winLossText != null)
            winLossText.GetComponent<TMP_Text>().text = "*squeak* *squeak* (Loser!)";
    }
}
