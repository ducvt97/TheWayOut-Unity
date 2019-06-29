using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class SkillController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 60f;

    private bool isCooldown;
    private bool isBoostSpeed = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isCooldown = true;
        }

        if (isCooldown)
        {
            if (isBoostSpeed)
            {
                ThirdPersonCharacter.instance.SetSpeed(1f);
                Invoke("speedBegin", 10f);
            }
            isBoostSpeed = false;
            imageCooldown.gameObject.SetActive(true);
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount <= 0)
            {
                isCooldown = false;
                isBoostSpeed = true;
                imageCooldown.fillAmount = 1;
                imageCooldown.gameObject.SetActive(false);
            }
        }
    }

    void speedBegin()
    {
        ThirdPersonCharacter.instance.SetSpeed(0.5f);
    }
}
