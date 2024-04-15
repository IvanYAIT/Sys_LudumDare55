using Character;
using System;
using UI;
using UnityEngine;
using Zenject;

public class BridgeBuilder : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject bridge;
    [SerializeField] private Transform bridgeNormalPos;
    [SerializeField] private float bridgeSpeed;

    private int _playerLayer;
    private bool isBrigeMoving;
    private float _time;
    private TaskList _taskList;

    [Inject]
    public void Construct(TaskList taskList)
    {
        _taskList = taskList;
    }

    void Start()
    {
        _playerLayer = (int)Math.Log(playerLayerMask.value, 2);
    }

    private void Update()
    {
        if (isBrigeMoving)
        {
            bridge.transform.position = Vector3.Lerp(bridge.transform.position, bridgeNormalPos.position, bridgeSpeed * _time);
            _time += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == _playerLayer)
        {
            if (SoulCounter.isEnoghSouls)
            {
                hint.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SummonBridge();
                    _taskList.NextTask();
                }
            }        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == _playerLayer)
        {
            hint.SetActive(false);
        }
    }

    public void SummonBridge()
    {
        bridge.gameObject.SetActive(true);
        isBrigeMoving = true;
    }
}
