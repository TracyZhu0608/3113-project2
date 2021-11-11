using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifebar : MonoBehaviour
{

    private Slider hpSlider;
    private RectTransform rectTrans;

    public Transform target;
    public Root3 myRoot;
    public Vector3 offsetPos; //头顶偏移量
    private float fullhp;
    private float currenthp;




    private void Start()
    {
        hpSlider = GetComponent<Slider>();
        rectTrans = GetComponent<RectTransform>();
        fullhp = myRoot.hp;
        currenthp = myRoot.hp;
        hpSlider.value = currenthp/fullhp;
    }

    private void Update()
    {
        currenthp = myRoot.hp;
        print(currenthp);
        hpSlider.value = currenthp/fullhp;
        if(target==null) return;

        //通过Collider来获取头顶坐标
        var col = target.GetComponent<Collider>();
        var topAhcor = new Vector3(col.bounds.center.x, col.bounds.max.y, col.bounds.center.z);   
        //加上头顶偏移量
        Vector3 tarPos = topAhcor;

        var viewPos = Camera.main.WorldToViewportPoint(tarPos); //得到视窗坐标


        Vector2 screenPos;

        if (viewPos.z > 0f && viewPos.x > 0f && viewPos.x < 1f && viewPos.y > 0f && viewPos.y < 1f)
        {

            //获取屏幕坐标
            screenPos =  Camera.main.WorldToScreenPoint(tarPos+offsetPos); //加上头顶偏移量
        }
        else
        {
            //不在可视窗口的模型，把名字移动到视线外
            screenPos = Vector3.up * 3000f;
        }


        //转化为屏幕坐标
        rectTrans.position = screenPos;
    }
}