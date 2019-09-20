using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCabin : MonoBehaviour
{
    public Transform parent;
    public Sprite family;
    // public List<Sprite> Sprites;
    public GameObject cainQuestion;
    private int numberCabin;
    private int speed;
    public GameObject keyImage;
    bool checkedQuestion = false;



    void Start()
    {
        speed = -250;
        numberCabin = 6;
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = family;
        // keyImage = GameObject.FindGameObjectWithTag("keyImage");
        keyImage.GetComponent<>().sprite = family;

        for (int i = 0; i < numberCabin - 1; i++)
        {
            Instantiate(cainQuestion, parent);
        }


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
        yield return new WaitForSeconds(.6f);
        for (var i = 1; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).GetChild(0).localScale = new Vector3(1.2f, 1.2f, 1.2f);
            yield return new WaitForSeconds(1.5f);
            parent.transform.GetChild(i).GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(.2f);
        }
    }
    IEnumerator Example(float second)
    {
        yield return new WaitForSeconds(second);

    }

    // IEnumerator WaitItroGameRun(float second)
    // {
    //     yield return new WaitForSeconds(second);
    // }
}
