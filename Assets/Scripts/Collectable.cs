using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField, Min(1)] private int scoreAdd = 10;
    [SerializeField] private IntEventChannel scoreChannel;

    void OnTriggerEnter(Collider coll){
        if (!coll.CompareTag("Player")) return;
        GameManager.AddScore(scoreAdd);
        scoreChannel.Invoke(scoreAdd);
        Destroy(gameObject);
    }
}
