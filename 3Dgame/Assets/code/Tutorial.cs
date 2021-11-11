using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    bool firsttxt1 = true;
    bool firsttxt2 = true;
    bool firsttxt3 = true;
    

    void Start()
    {
        txt1.SetActive(true);
        txt2.SetActive(false);
        txt3.SetActive(false);

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
                        if (firsttxt1 == true){
                            txt1.SetActive(false);
                            txt2.SetActive(true);
                            firsttxt1 = false;
                        }
                        
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

                    if (firsttxt2 == true){
                        txt2.SetActive(false);
                        StartCoroutine(ShowMessage(txt3, 10));
                        firsttxt2 = false;
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

    IEnumerator ShowMessage (GameObject txt3, float delay) {
        if (firsttxt3 == true){
            txt3.SetActive(true);
            yield return new WaitForSeconds(delay);
            txt3.SetActive(false);
        }
        
        firsttxt3 = false;
    }
}