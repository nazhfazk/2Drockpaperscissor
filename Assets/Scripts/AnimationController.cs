using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerChoiceHandlerAnimation, choiceAnimation;
    
    public void ResetAnimation()
    {
        playerChoiceHandlerAnimation.Play("ShowHandler");
        choiceAnimation.Play("RemoveChoices");
    }

    public void PlayerMadeChoice()
    {
        playerChoiceHandlerAnimation.Play("RemoveHandler");
        choiceAnimation.Play("ShowChoices");
    }

}
