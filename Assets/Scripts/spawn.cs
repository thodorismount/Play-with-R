using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour
{
    // public GameObject[] slots;
    //public List<GameObject> slots = new List<GameObject>();
    public GameObject myPrefabObject = null;
    //  public GameObject parent;
    // public Transform prefab;

    void Start()
    {
      /*  for (int i = 0; i < 0; i++)
        {
            Instantiate(myPrefabObject, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            Debug.Log("aris");
        }*/
        // Instantiate(item);
        Instantiate(myPrefabObject, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Debug.Log("aris");
        //myPrefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}