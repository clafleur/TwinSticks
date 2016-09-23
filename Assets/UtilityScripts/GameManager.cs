using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
    public bool recording = true;
    private float initialFixedDeltaTime;
	// Use this for initialization
	void Start () {
        PlayerPrefManager.UnlockLevel(2);
        print(PlayerPrefManager.IsLevelUnlocked(1));
        print(PlayerPrefManager.IsLevelUnlocked(2));
        initialFixedDeltaTime = Time.fixedDeltaTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResumeGame();
        }

        print("update");
	}

    void PauseGame() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDeltaTime;
    }
}
