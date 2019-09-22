using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCabin : MonoBehaviour
{
    public Transform parent;
    public Sprite sprite;
    public GameObject cainQuestion;
    public Sprite spriteQuestion;
    private int numberCabin;
    private int speed;
    bool checkedQuestion = false;

    void Start()
    {
        speed = -250;
        numberCabin = 6;
        for (int i = 0; i < numberCabin; i++)
        {
            Instantiate(cainQuestion, parent);
            cainQuestion.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
        }
        parent.transform.GetChild(numberCabin + 1).GetChild(0)
            .GetComponent<Image>().sprite = spriteQuestion;
    }

    void Update()
    {

        parent.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (checkedQuestion == false)
        {

            if (parent.transform.position.x <= 440.0f)
            {
                speed = 0;
                parent.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                checkedQuestion = true;
                StartCoroutine(ScalingImages());
            }
        }
    }
    private IEnumerator ScalingImages()
    {
        int a = parent.transform.childCount;
        yield return new WaitForSeconds(.6f);
        for (var i = 1; i < a; i++)
        {
            if (i != a - 1)
            {
                parent.transform.GetChild(i).GetChild(0).localScale = new Vector3(1.2f, 1.2f, 1.2f);
                yield return new WaitForSeconds(1f);
                parent.transform.GetChild(i).GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);
                yield return new WaitForSeconds(.2f);
            }
            else
                parent.transform.GetChild(i).GetChild(0).localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }
    IEnumerator Example(float second)
    {
        yield return new WaitForSeconds(second);

    }

}
