using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public GameObject[] pokeList;
    public static int pokenumber;

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
                    if (pokeList[i].gameObject.name == "PokemonCube")
                    {
                        pokenumber = 0;
                    }
                    else if (pokeList[i].gameObject.name == "PokemonCube (1)")
                    {
                        pokenumber = 1;
                    }
                    else if (pokeList[i].gameObject.name == "PokemonCube (2)")
                    {
                        pokenumber = 2;
                    }
                    else if (pokeList[i].gameObject.name == "PokemonCube (3)")
                    {
                        pokenumber = 3;
                    }
                    else
                    {
                        Debug.Log(this.gameObject.name);
                        pokenumber = 4;
                    }
                    Debug.Log("It's a fuckin " + pokeList[i].GetComponent<pokeBoy>().pokemonName + " dude.");
                }
            }
        }
    }
}
