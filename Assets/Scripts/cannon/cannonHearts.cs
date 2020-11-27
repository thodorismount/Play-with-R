using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonHearts : MonoBehaviour
{
    public SpriteRenderer heart1, heart2, heart3;
    public GameObject cannon, spriteTrue, spriteFalse;
    public GameObject tryAgainPanel;
    [SerializeField]
    private Animator heartAnimation;

    void Update()
    {
        if (cannonImagesManager.mistakesScore == 1)
        {
            heart1.material = Resources.Load<Material>("grey");
        }
        else if (cannonImagesManager.mistakesScore == 2)
        {
            heart2.material = Resources.Load<Material>("grey");
            heartAnimation.SetBool("playHeartAnimation", true);
        }
        else if (cannonImagesManager.mistakesScore >= 3)
        {
            heartAnimation.SetBool("playHeartAnimation", false);
            heart3.material = Resources.Load<Material>("grey");
            cannon.SetActive(false);
            spriteTrue.SetActive(false);
            spriteFalse.SetActive(false);
            tryAgainPanel.SetActive(true);
        }
    }
}