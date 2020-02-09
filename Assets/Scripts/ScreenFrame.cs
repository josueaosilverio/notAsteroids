using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFrame : MonoBehaviour
{

    [SerializeField]
    private bool top = false;
    [SerializeField]
    private bool bottom = false;
    [SerializeField]
    private bool left = false;
    [SerializeField]
    private bool right = false;

    void Start()
    {


        if (top)
        {

           

            transform.localScale = new Vector3(50f, 0.2f);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 10));
            transform.position = worldPoint;

        } else  if (bottom)
        {

            transform.localScale = new Vector3(50F, 0.2f);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
            transform.position = worldPoint;

        } else  if (left)
        {

            transform.localScale = new Vector3(0.2f, 50F);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
            transform.position = worldPoint;

        } else  if (right)
        {

            transform.localScale = new Vector3(0.2f, 50F);

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10));
            transform.position = worldPoint;

        } else
        {
            Debug.LogError("No side set on boundary");
        }



    }
}
