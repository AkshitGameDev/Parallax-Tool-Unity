using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//please read all the comments and .readme file or else you will dieeeeeeeeeeeeeeeeeeeeeeeeeeeeee

public class ParallaxManager : MonoBehaviour
{
    //Singelton 
    public static ParallaxManager instance = null;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    // This class is for layers you want to add in your paralax
    [System.Serializable]
    public class Layer
    {
        public Sprite[] fragments; // add your stripes manually or with stripe sheets
        public bool isStatic = false; // wether you want to make it static or not

        
        public void Update(int Index)
        {
            Debug.Log("i am " + Index);
        }
    }

    [SerializeField]
    private Layer[] Layers;
    [SerializeField]
    float MoveSpeed = 1.3f;
    float decrement = 0.34f;

    [SerializeField]
    bool onMove = false;
    [SerializeField]
    bool isDemo = false;


    void Update()
    {

        if (onMove){

            if (isDemo) return;

            for (int i = 0; i < Layers.Length; i++)
            {

                Layers[i].Update(i);

            }
        }
        
    }



}

/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject bgCardFragment = null;
    public int Count = 0;
    int fragIndex = -1;
    public Color[] fragColors;
    public GameObject BgObject = null;
    int fragItteration = 0;
    int curpos = 0;
    GameObject[] allFrags;
    public float speed = 1.0f;
    public GameObject MinusPoint = null;
    public GameObject PlusPoint = null;
    void Start()
    {
        fragColors = new Color[Count];
        allFrags = new GameObject[Count];
        for (int i = 0; i < Count; i++)
        {
            float hue = UnityEngine.Random.Range(0f, 1f);
            float saturation = 1.0f;
            float value = 1.0f;
            fragColors[i] = Color.HSVToRGB(hue, saturation, value);
        }

        MinusPoint.transform.position = new Vector3(MinusPoint.transform.position.x - (Screen.width / Count),
        MinusPoint.transform.position.y,
        MinusPoint.transform.position.z);

        int heighPerFragment = Screen.height;
        int WidthPerFragment = (Screen.width + (Screen.width / Count)) / Count;
        for (int i = 0; i < Count; i++)
        {
            fragIndex++;
            spawnBgCardFragment(WidthPerFragment, heighPerFragment);
        }
    }

    public void spawnBgCardFragment(int width, int height)
    {

        GameObject frag = Instantiate(bgCardFragment, BgObject.transform);
        RectTransform fragRectTransform = frag.GetComponent<RectTransform>();
        GameObject _frag = frag.transform.GetChild(0).gameObject;
        var _fragRectTransform = _frag.GetComponent<RectTransform>();
        _fragRectTransform.sizeDelta = new Vector2(width, height);
        Image renderer = _frag.GetComponent<Image>();
        renderer.color = fragColors[fragIndex]; // Use the index to access the color

        fragRectTransform.position = new Vector3(curpos, height / 2, 0);
        allFrags[fragIndex] = frag;
        curpos += width;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active)
        {
            for (int i = 0; i < Count; i++)
            {
                if (allFrags[i].gameObject.GetComponent<RectTransform>().position.x != MinusPoint.transform.position.x)
                {
                    MoveIndividualBlocks(i);
                }
                else
                {
                    RepositionIndividualBlock(i);
                }
            }
        }
        void MoveIndividualBlocks(int index)
        {
            allFrags[index].gameObject.transform.position = new Vector3(
                allFrags[index].gameObject.transform.position.x - speed
                , allFrags[index].gameObject.transform.position.y
                , allFrags[index].gameObject.transform.position.z);
        }

        void RepositionIndividualBlock(int index)
        {
            allFrags[index].gameObject.GetComponent<RectTransform>().position = new Vector3(
                PlusPoint.transform.position.x
                , allFrags[index].gameObject.transform.position.y
                , allFrags[index].gameObject.transform.position.z);
        }
    }
}
*/