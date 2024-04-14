using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointer : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private List<Transform> targets;
    [SerializeField] private Transform bridge;
    [SerializeField] private TextMeshProUGUI meter;
    [SerializeField] private Vector3 offset;

    public static bool isSoulsCollected;

    private Transform target;
    private float minDis;
    private int index;

    private void Awake()
    {
        isSoulsCollected = false;
        index = 0;
        minDis = Vector3.Distance(transform.position, targets[index].position);
    }

    private void Update()
    {
        if (targets.Count > 0)
        {
            if (!isSoulsCollected)
                FindTarget();
        }

        if(isSoulsCollected)
            target = bridge;

        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        img.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";

        
    }
    
    public void FindTarget()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (Vector3.Distance(transform.position, targets[i].position) < minDis || minDis == 0)
            {
                index = i;
                minDis = Vector3.Distance(transform.position, targets[i].position);
            }
        }

        minDis = 0;
        target = targets[index];
    }

    public void Remove(Transform soul) =>
        targets.Remove(soul);
}