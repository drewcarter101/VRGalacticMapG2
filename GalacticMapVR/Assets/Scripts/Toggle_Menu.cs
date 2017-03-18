using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Menu : MonoBehaviour
{

   public GameObject MenuController;

    // Use this for initialization
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuController.GetComponent<ShowHide>().toggleHome();

        }

    }
}
