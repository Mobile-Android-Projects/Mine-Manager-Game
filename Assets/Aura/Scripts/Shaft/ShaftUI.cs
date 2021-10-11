using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldDepositText;
    [SerializeField] private TextMeshProUGUI addShaftAmntText;
    [SerializeField] private TextMeshProUGUI shaftLevelText;
    [SerializeField] private TextMeshProUGUI shaftIDText;
    [SerializeField] private Button upgradeShaftBtn;
    [SerializeField] private Button addShaftBtn;

    private Shaft owningShaft;

    private void Awake()
    {
        owningShaft = GetComponent<Shaft>();
    }

    private void Update()
    {
        goldDepositText.text = owningShaft.ShaftDeposit.CurrentGoldDepo.ToString();
    }

    public void AddSHaft()
    {
        ShaftManager.Instance.AddNewShaft();
        addShaftBtn.gameObject.SetActive(false);
    }

    public void SetShaftID(int shaftIndex)
    {
        owningShaft.ShaftID = shaftIndex;
        shaftIDText.text = (owningShaft.ShaftID + 1).ToString();
    }

    public void SetShaftCost(float shaftCost)
    {
        addShaftAmntText.text = shaftCost.ToString();
    }


}
