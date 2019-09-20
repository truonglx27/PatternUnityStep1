using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroGame : MonoBehaviour
{
    public GameObject imageIntro;
    public Text gameChat;

    void Start()
    {
        StartCoroutine(Example());


    }
    private void Update()
    {
        gameChat.text = "Let's complete the patterns";
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(3f);
        imageIntro.SetActive(false);

    }


}