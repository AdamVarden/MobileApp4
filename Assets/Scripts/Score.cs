using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float currentScore = 0;
    [SerializeField] Text scoreAmount;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
        Debug.Log(currentScore);

    }

    public void UpdateScoreUI()
    {
        string value = string.Format("{0}", currentScore);

        scoreAmount.text = value;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreUI();
        
    }
}
