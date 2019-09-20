using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropZone : MonoBehaviour, IDropHandler
{
    private GameObject train;
    string nameGameObject = "";
    bool checkedQuestion = false;
    private Vector3 checkTransfrom;
    private GameObject children;
    private int speed = 0;
    private int a = 0;
    private void Start()
    {
        train = GameObject.FindGameObjectWithTag("train");
        children = GameObject.FindGameObjectWithTag("children");
        Debug.Log(children.transform.childCount);
        for (int i = 0, b = children.transform.childCount; i < b; i++)
        {
            if (children.transform.GetChild(i).gameObject.activeSelf)
                a++;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Draggble d = eventData.pointerDrag.GetComponent<Draggble>();
        if (d != null)
        {
            d.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (gameObject.tag == "Question")
            {
                nameGameObject = eventData.pointerDrag.name;
                d.transform.localScale = new Vector3(0.9f, 0.7f, 1f);
            }
            d.parentToReturnTo = this.transform;
        }
    }
    private void Update()
    {

        train.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (nameGameObject == "Family")
            SceneManager.LoadScene("SampleScene");
        Debug.Log("a= " + a);

        if (a == 2)
        {
            Debug.Log("a= " + a);
            if (checkedQuestion == false)
            {
                if (nameGameObject == "Son")
                {
                    checkedQuestion = true;
                    speed = -500;
                    train.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                    StartCoroutine(Example(2f));
                }
            }
        }
        if (a == 3)
        {
            Debug.Log("a= " + a);

            if (checkedQuestion == false)
            {
                if (nameGameObject == "Son" && nameGameObject == "Sister")
                {
                    checkedQuestion = true;
                    speed = -500;
                    train.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                    StartCoroutine(Example(2f));
                }

            }
        }
    }

    IEnumerator Example(float second)
    {
        yield return new WaitForSeconds(second);
        speed = 0;
    }
}
