using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(){
        StartCoroutine(UpdateScoreDelayed());
    }

    private IEnumerator UpdateScoreDelayed(){
        yield return new WaitForEndOfFrame();
        scoreText.text = GameManager.Score.ToString();
    }
}
