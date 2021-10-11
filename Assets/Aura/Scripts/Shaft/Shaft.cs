using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aura.Scripts.Miner;
using Aura.Scripts.Extras;

public class Shaft : MonoBehaviour
{
    //shaft properties
    public int ShaftID { get; set; }

    [Header("Prefabs")]
    [SerializeField] private GameObject minerPrefab;
    [SerializeField] private GameObject depositChestPrefab;

    [Header("Spawn Locations")]
    [SerializeField] private Transform depositLocation;//location where miner does deposit action
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositChestLocation;//location where gold chest will be spawned

    //access properties
    public Transform DepositLocation => depositLocation;
    public Transform MiningLocation => miningLocation;
    public Deposit ShaftDeposit { get; private set; }

    private void Start()
    {
        CreateMiner();
        CreateDepositChest();
    }

    private void CreateDepositChest()
    {
        var depoChest = Instantiate(depositChestPrefab, depositChestLocation.position, Quaternion.identity);
        ShaftDeposit = depoChest.GetComponent<Deposit>();
        depoChest.transform.SetParent(transform);
    }

    private void CreateMiner()
    {
        //instantiate miner and cache in reference
        var miner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        ShaftMiner shaftMinerRef = miner.GetComponent<ShaftMiner>();
        shaftMinerRef.OwningShaft = this;
        miner.transform.SetParent(transform);
    }
}
