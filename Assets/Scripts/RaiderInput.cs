using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaiderInput : MonoBehaviour
{
    private Raider MyRaider;
    private LineRenderer lRenderer;
    private bool isDragging;
    
    private void Start()
    {
        MyRaider = GetComponent<Raider>();
        lRenderer = GetComponent<LineRenderer>() ?? gameObject.AddComponent<LineRenderer>();
    }

    private void Update()
    {
        if (isDragging)
        {
            lRenderer.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                lRenderer.SetPosition(1, hit.point);
            }
        }
        else
        {
            lRenderer.SetPosition(0, transform.position);
            lRenderer.SetPosition(1, transform.position);
        }
    }

    #region Draggin Controls
    void OnMouseDrag()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            OnDragRelease();
            isDragging = false;
        }
    }

    private void OnDragRelease()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
        {
            if (ClickHelper.IsUIClick())
                return;
            if (ClickHelper.IsCharacter(hit))
            {
                MyRaider.Assist(hit.transform.GetComponent<Raider>());
            }
            else if (ClickHelper.IsEnemy(hit))
            {
                MyRaider.Engage(hit.transform.GetComponent<Enemy>());
            }
            else if (ClickHelper.IsTerrain(hit))
            {
                MyRaider.GoTo(hit.point);
            }
        }
    }
    #endregion
}
