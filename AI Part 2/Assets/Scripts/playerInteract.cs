using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public GameObject[] pokeList;

    public bool scanActive; 
    // Start is called before the first frame update
    void Start()
    {
       pokeList = GameObject.FindGameObjectsWithTag("pokeCube");
    }

    // Update is called once per frame
    void Update()
    {
        scanActive = false;
        for(int i = 0; i < pokeList.Length; i++){
            if(Vector3.Distance(pokeList[i].transform.position, this.gameObject.transform.position) < 5){
                if(Input.GetButtonDown("Jump")){
                    Debug.Log("It's a fuckin " + pokeList[i].GetComponent<pokeBoy>().pokemonName + " dude.");
                }
            }
        }
    }
}
