using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        Debug.Log("EntradaOntrigger");
        if(collider.gameObject.name == "Personaje"){
            collider.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collider){
         Debug.Log("SalidaOntrigger");
        if(collider.gameObject.name == "Personaje"){
            collider.gameObject.transform.SetParent(null);
        }
    }
}
