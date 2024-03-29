using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class BuildingConstructionMenu : MonoBehaviour
{
    [SerializeField] Buildings bM;
    [SerializeField] TileManager tM;
    List<Building> constructables;


    public GameObject bgObj;
    public GameObject iconPrefab;
    public Transform scrollParent;

    public List<GameObject> Icons;
    public float scrollValue;
    float maxLength;
    float offset = -100;
    float howManyOnScreen = 6;
    float screenWidth = 800;
    
    float scrollAcceleration = 20;
    float maxScrollSpeed = 40;
    float maxScrollDistance = 2200;
    public float scrollingFor;
    public float currentScrollDirection;

    private void OnEnable()
    {
        initiate();
        maxScrollDistance = 2400 / 1920 * Screen.width + 400;
    }

    void initiate()
    {
        constructables = new List<Building>((Building[])bM.buildings.ToArray().Clone());
        for(int i = 0; i < constructables.Count; i++)
        {
            GameObject Icon = Instantiate(iconPrefab, scrollParent);
            Icon.GetComponent<RectTransform>().anchoredPosition = new Vector3(screenWidth * ((i+1 ) / (howManyOnScreen+1)), 15);
            Icon.GetComponent<BuildingIcon>().initiate(constructables[i],i);
            Icon.name = constructables[i].name;
            Icons.Add(Icon);
        }
    }
    public void OptionClicked(int num)
    {
        tM.SetDraft(num);
    }

    public void scrollRight(bool v)
    {
        currentScrollDirection = v ? -1 : 0;
        scrollingFor = v ? scrollingFor : 0;
    }
    public void scrollLeft(bool v)
    {
        currentScrollDirection = v ? 1 : 0;
        scrollingFor = v ? scrollingFor : 0;
    }
    private void FixedUpdate()
    {
        if (currentScrollDirection != 0)
        {
                scrollingFor += Time.deltaTime*scrollAcceleration;
                scrollValue += Mathf.Clamp(scrollingFor, 0, maxScrollSpeed) * currentScrollDirection;
                scrollValue = Mathf.Clamp(scrollValue, -maxScrollDistance,0);
                scrollParent.transform.position = new Vector3(scrollValue, 0);
        }
    }

    public void DeactivateBuildButton(string id)
    {
        Icons.Find(x => x.name == id).GetComponent<BuildingIcon>().CanBeClicked(false);
    }
    public void ActivateBuildButton(string id)
    {
        Icons.Find(x => x.name == id).GetComponent<BuildingIcon>().CanBeClicked(true);
    }


}
