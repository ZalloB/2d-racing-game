using UnityEngine;

public class FinishLineController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("GameLevelManager").GetComponent<GameLevelManager>().SendMessage("CheckWin");
    }
}