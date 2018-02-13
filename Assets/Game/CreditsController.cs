using UnityEngine;

public class CreditsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
        }
	}
}
