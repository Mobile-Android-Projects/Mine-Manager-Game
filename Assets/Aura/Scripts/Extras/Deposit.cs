using UnityEngine;

namespace Aura.Scripts.Extras
{
    public class Deposit : MonoBehaviour
    {
        public float CurrentGoldDepo { get; private set; }

        public void DepositGold(float goldAmount)
        {
            CurrentGoldDepo += goldAmount;
        }
        
    }
}
