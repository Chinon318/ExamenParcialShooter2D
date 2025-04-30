using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerScore {get; set; }

    public bool gameOver {get; set; }


    public TMP_Text txt_Score;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        txt_Score = GameObject.Find("txt_Score").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (txt_Score == null)
        {
            txt_Score = GameObject.Find("txt_Score").GetComponent<TMP_Text>();
        }
        txt_Score.text = playerScore.ToString();
    }
}
