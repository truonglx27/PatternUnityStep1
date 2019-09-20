using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TrainAnimation : MonoBehaviour
{
    public GameObject imgBada;
    private GameObject train;
    private GameObject children;
    public GameObject trainQuestion;
    public GameObject ScaleImage;
    public RectTransform[] Picture;
    bool checkedQuestion = false;
    private Vector3 checkTransfrom;
    private int speed;
    private int number;
    void Start()
    {
        train = GameObject.FindGameObjectWithTag("train");
        children = GameObject.FindGameObjectWithTag("children");
        ScaleImage = GameObject.FindGameObjectWithTag("TrainQuestion");
        children.SetActive(false);
        checkTransfrom = train.transform.position;
        speed = -700;
        number = Random.Range(1, 3);
        if (number == 2)
        {
            trainQuestion.SetActive(false);
        }

    }
    private void Update()
    {
        train.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (checkedQuestion == false)
        {
            if (train.transform.position.x <= 1300.0f)
            {
                imgBada.SetActive(false);
            }
            if (train.transform.position.x <= 440.0f)
            {
                speed = 0;
                train.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                StartCoroutine(Example(0.5f));
                checkedQuestion = true;

            }
        }
    }

    private IEnumerator ScalingImages()
    {
        for (var i = 0; i < Picture.Length; i++)
        {
            Picture[i].localScale = new Vector3(1.2f, 1.2f, 1.2f);
            yield return new WaitForSeconds(1);
            Picture[i].localScale = new Vector3(1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(.2f);
        }
    }


    IEnumerator Example(float second)
    {
        yield return new WaitForSeconds(second);
        children.SetActive(true);
        StartCoroutine(ScalingImages());
        aChildren();

    }

    void aChildren()
    {
        for (int i = 0; i < children.transform.childCount; i++)
        {
            children.transform.GetChild(i).SetSiblingIndex(Random.Range(0, children.transform.childCount));
            if (number == 2)
            {
                children.transform.GetChild(0).gameObject.SetActive(false);
                number = 0;
            }
        }

    }
    // IEnumerator ScaleUp(float second, int i)
    // {
    //     Debug.Log("Scale Up");
    //     yield return new WaitForSeconds(second);
    //     ScaleImage.transform.GetChild(i).localScale = new Vector3(1.2f, 1.2f, 1.2f);
    // }
    // IEnumerator ScaleDown(float second, int i)
    // {
    //     ScaleImage.transform.GetChild(i).localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //     yield return new WaitForSeconds(second);
    //     Debug.Log("Scale Down");
    // }

    // void ScaleQ()
    // {
    //     for (int i = 0, a = ScaleImage.transform.childCount; i < a; i++)
    //     {
    //         // StartCoroutine(ScaleUp(2.0f, i));
    //         StartCoroutine(ScaleUp(2.0f, i));
    //         // StartCoroutine(ScaleUp(2.0f));
    //         StartCoroutine(ScaleDown(2.0f, i));
    //         StopCoroutine(ScaleUp(2.0f, i));

    //         StopCoroutine(ScaleDown(2.0f, i));
    //     }

    // }
}
