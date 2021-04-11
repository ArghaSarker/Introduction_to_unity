using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 


public class UIManager : MonoBehaviour
{

    public HealthStatus HealthStatus; 
    
    
    [SerializeField] private TMP_Text _scoreText; 
    [SerializeField] private TMP_Text _gameText;
   // [SerializeField] private TMP_Text _lifeText;

    [SerializeField] private TMP_Text _gameOver;
    

    private int _score = 0 ;
    public int _life = 5 ;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score : " + _score;
       // _lifeText.text = "Life :" + _life;
        HealthStatus.setMaxHealth(5);

    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score : " + _score;
        //_lifeText.text = "Life :" + _life;
        if (_life == 0)
        {
            _gameOver.text = "You Failed to Protect the Earth!!!" ; 
        }
        else if (_life > 5)
            _life = 5;
    }

    public void addScore(int score)
    {
        _score += score; 
    }

    public void countLife(int life)
    {
        _life -= life;
        HealthStatus.setHealth(_life);
    }
    
}
