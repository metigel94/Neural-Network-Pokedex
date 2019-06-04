using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pokemon : MonoBehaviour
{
    public string pokemonName = "";
    public string Status = "";
    public string prevStatus = "";
    //public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Status = HelloRequester.message;
        //Debug.Log("STATUS: " + Status);
        // gameObject.GetComponent<UnityEngine.UI.Text>().text = gameObject.GetComponent<UnityEngine.UI.Text>().text + "\n" + Status;
        //gameObject.GetComponent<UnityEngine.UI.Text>().text = Status;
        //GetComponent<UnityEngine.UI.Text>().text = Status;

       
        Status = HelloRequester.message;

        if (Status != null && Status != prevStatus)
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = gameObject.GetComponent<UnityEngine.UI.Text>().text + "\n" + HelloRequester.message;
            prevStatus = Status;
        }
    }
}