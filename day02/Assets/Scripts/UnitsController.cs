using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class UnitsController : MonoBehaviour
{
    public List<GameObject> units = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D unit;

            unit = Physics2D.OverlapPoint(target);
            if (unit != null)
            {
                if (unit.gameObject.CompareTag("Footman"))
                {
                    if (Input.GetKey(KeyCode.LeftControl) == true)
                    {
                        if (!units.Contains(unit.gameObject))
                        {
                            units.Add(unit.gameObject);
                        }
                    }
                    else
                    {
                        if (units.Count == 0)
                            units.Add(unit.gameObject);
                        else
                        {
                            units.Clear();
                            units.Add(unit.gameObject);
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
            units.Clear();
    }
}
