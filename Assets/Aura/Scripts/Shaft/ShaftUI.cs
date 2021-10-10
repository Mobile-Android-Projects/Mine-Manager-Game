using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldDepositText;
    private Shaft owningShaft;

    private void Start()
    {
        owningShaft = GetComponent<Shaft>();
    }

    private void Update()
    {
        goldDepositText.text = owningShaft.ShaftDeposit.CurrentGoldDepo.ToString();
    }
}
