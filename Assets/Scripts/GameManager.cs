using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int score;
    public Text scoreText;
    public Image scoreBackground;
    public GameObject gameOverScreen;
    public Transform player;
    public Image playBG;
    public Image menuBG;
    public GameObject instructions;

    int gameOverAnimationState;
    bool isGameOver = false;

    void Start()
    {
        gameOverAnimationState = score = 0;
    }

    void Update()
    {
        if (!isGameOver && player.position.y < 0.15f)
            GameOver();
        
        if (isGameOver)
        {
            PlayGameOverAnimation();
        }
    }

    public void PlayGameOverAnimation()
    {
        const float maxScaleY = 10.2f;
        const float minScaleY = 10.2f;
        const float maxScaleX = 4f;

        if (scoreText.rectTransform.localPosition.y > -500)
            scoreText.rectTransform.localPosition -= new Vector3(0, 30f);

        if (scoreBackground.rectTransform.localScale.y < maxScaleY && gameOverAnimationState == 0)
        {
            if (playBG.rectTransform.localScale.x < 3)
            {
                playBG.rectTransform.localScale += new Vector3(0.5f,0);
                menuBG.rectTransform.localScale += new Vector3(0.5f,0);
            }
            scoreBackground.rectTransform.localScale += new Vector3(0, 1f);
        }

        else if (scoreBackground.rectTransform.localScale.y >= maxScaleY && gameOverAnimationState == 0)
            gameOverAnimationState = 1;

        else if (scoreBackground.rectTransform.localScale.y >= minScaleY && gameOverAnimationState == 1)
            scoreBackground.rectTransform.localScale -= new Vector3(0, 0.5f);

        else if (scoreBackground.rectTransform.localScale.y < minScaleY && gameOverAnimationState == 1)
            gameOverAnimationState = 2;

        else if (scoreBackground.rectTransform.localScale.x < maxScaleX && gameOverAnimationState == 2)
        {
            scoreText.fontSize = 100;
            scoreText.text = "Score\n" + score;
            scoreBackground.rectTransform.localScale += new Vector3(0.4f, 0);
        }

        else if (scoreBackground.rectTransform.localScale.x >= maxScaleX && gameOverAnimationState == 2)
            gameOverAnimationState = 3;

        else if(gameOverAnimationState == 3)
        {
            gameOverAnimationState = 4;
            gameOverScreen.SetActive(true);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Destroy(player.GetComponent<Controller>());
        Destroy(instructions);
    }

}
