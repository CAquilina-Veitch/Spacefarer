using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ItemStorage))]
public class Launcher : MonoBehaviour
{
    //[SerializeField] bool requiresPower = false;
    public bool activity;

    public Launchpad destination;


    public void setActivity(bool to)
    {
        activity = to;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gFCall()
    {

    }
}
