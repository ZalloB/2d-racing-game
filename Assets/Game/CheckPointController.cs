using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {

    public int checkpointnumber;
    public bool CheckpointAdd = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("AddCheckpoint", collision);
    }

    IEnumerator AddCheckpoint(Collider2D collision)
    {
        if (CheckpointAdd)
        {
            CheckpointAdd = false;
            GameObject.Find("GameLevelManager").GetComponent<GameLevelManager>().SendMessage("AddCheckpoint", checkpointnumber);
        }

        yield return new WaitForSeconds(1f);
        CheckpointAdd = true;
    }
}
