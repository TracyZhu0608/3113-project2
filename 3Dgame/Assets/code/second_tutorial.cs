using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class second_tutorial : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    bool firsttxt1 = true;
    bool firsttxt2 = true;
    public UITest dialogue;
    public radar_rotate radar;
    public GameObject fog;
    public AudioSource yes;
    void Start()
    {
        txt1.SetActive(true);
        txt2.SetActive(false);
    }

    RaycastHit hit;
    int layer;
    List<UnitController> selected = new List<UnitController>();
    bool isDragging = false;
    Vector3 mousePosition;
    //GameObject [] agents;
    // Start is called before the first frame update
    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.green);
        }
    }

    void Update()
    {
        //print(isDragging);
        if(radar.rotate&&firsttxt1==true){
            txt1.SetActive(false);
            firsttxt1=false;
            txt2.SetActive(true);
            dialogue.Next();
                        //StartCoroutine(ShowMessage(txt3, 10));
            //firsttxt2 = true;
            fog.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            mousePosition = Input.mousePosition;
            DeselectUnit();
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                foreach (var ai in GameObject.FindGameObjectsWithTag("ai"))
                {
                    if (IsWithinSelect(ai.transform))
                    {
                        SelectUnit(ai.gameObject.GetComponent<UnitController>(), true);
                     
                    }
                }
                isDragging = false;
            }
            //isDragging = false;
        }

        if (Input.GetMouseButtonDown(1) && selected.Count > 0)
        {
            int layer = 1 << 10;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layer))
            {
                foreach (var ai in selected)
                {
                    ai.MoveUnit(hit.point);
                    if(ai.GetComponent("player") as player==null&&firsttxt1==false&&firsttxt2!=false){
                        txt2.SetActive(false);
                        dialogue.NextandButton();
                        //StartCoroutine(ShowMessage(txt3, 10));
                        firsttxt2 = false;
                    }
                    else if(ai.GetComponent("player") as player==null){
                        yes.Play();
                    }
                }
            }
        }
    }

    private void SelectUnit(UnitController unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect) { DeselectUnit(); }
        selected.Add(unit);
        //print("true"+(selected.Count));
        unit.SetSelected(true);
    }

    private void DeselectUnit()
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].SetSelected(false);
        }
        selected.Clear();
    }

    private bool IsWithinSelect(Transform transform)
    {
        if (!isDragging) { return false; }
        var camera = Camera.main;
        var Bounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return Bounds.Contains(camera.WorldToViewportPoint(transform.position));
    }
    /*
    IEnumerator ShowMessage (GameObject txt3, float delay) {
        if (firsttxt3 == true){
            txt3.SetActive(true);
            yield return new WaitForSeconds(delay);
            txt3.SetActive(false);
        }
        
        firsttxt3 = false;
    }
    */
}

