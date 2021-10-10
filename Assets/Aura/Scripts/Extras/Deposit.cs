using UnityEngine;

namespace Aura.Scripts.Extras
{
    public class Deposit : MonoBehaviour
    {
        private float CurrentGoldDepo { get; set; }

        public void DepositGold(float goldAmount)
        {
            CurrentGoldDepo += goldAmount;
        }
        
    }
}
