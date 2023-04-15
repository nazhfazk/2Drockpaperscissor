using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, oppenentChoice_Img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();

    }

    public void SetChoices(GameChoices gameChoices)
    {
        switch (gameChoices)
        {
            case GameChoices.ROCK:

                player_Choice = GameChoices.ROCK;

                playerChoice_Img.sprite = rock_Sprite;

                break;

            case GameChoices.PAPER:

                player_Choice = GameChoices.PAPER;

                playerChoice_Img.sprite = paper_Sprite;

                break;

            case GameChoices.SCISSORS:

                player_Choice = GameChoices.SCISSORS;

                playerChoice_Img.sprite = scissors_Sprite;

                break;
        }

        SetOpponentChoice();

        DetermineWinner();

    }
        void SetOpponentChoice()
         {
            int rnd = Random.Range(0, 3);

            switch (rnd)
            {
            case 0:
                opponent_Choice = GameChoices.ROCK;

                oppenentChoice_Img.sprite = rock_Sprite;

                break;

            case 1:
                opponent_Choice = GameChoices.PAPER;

                oppenentChoice_Img.sprite = paper_Sprite;
                break;

            case 2:
                opponent_Choice = GameChoices.SCISSORS;

                oppenentChoice_Img.sprite = scissors_Sprite;
                break;

            }
         }

    void DetermineWinner()
    {
        if (player_Choice == opponent_Choice)
        {
            infoText.text = "DRAW";
            StartCoroutine(DisplayWinnerAndRestart());

            return;

        }

        if (player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.pscorevalue += 1;

            return;
        }

        if (opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.escorevalue += 1;

            return;
        }

        if (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.pscorevalue += 1;

            return;
        }

        if (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.escorevalue += 1;

            return;
        }

        if (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.pscorevalue += 1;

            return;
        }

        if (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
            Score.escorevalue += 1;

            return;
        }


    }

    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();

    }

}

