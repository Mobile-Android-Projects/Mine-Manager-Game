using System.Collections;
using UnityEngine;

namespace Aura.Scripts.Miner
{
    public class ShaftMiner : BaseMiner
    {
        #region Member Variables

        //get animator triggers and cache as animator hash id's
        int minerWalking = Animator.StringToHash("walking");
        int minerMining = Animator.StringToHash("mining");

        //reference to the owning shaft
        public Shaft OwningShaft { get; set; }

        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                MoveMiner(OwningShaft.MiningLocation.position);
            }
        }

        #region Utility Methods
        protected override void MoveMiner(Vector3 goalPos)
        {
            base.MoveMiner(goalPos);
            _animator.SetTrigger(minerWalking);
        }

        protected override void CollectGold()
        {
            _animator.SetTrigger(minerMining);
            float timeToCollect = CollectCapacity / CollectPaSecond;
            StartCoroutine(IECollect(CollectCapacity, timeToCollect));
        }

        protected override void DepositGold()
        {
            OwningShaft.ShaftDeposit.DepositGold(CurrentGold);
            CurrentGold = 0;
            FlipMiner(1);
            MoveMiner(OwningShaft.MiningLocation.position);
            SwitchGoal();
        }

        #endregion

        #region Coroutines
        protected override IEnumerator IECollect(float gold, float time)
        {
            yield return new WaitForSeconds(time);
            CurrentGold = gold;
            FlipMiner(-1);
            MoveMiner(OwningShaft.DepositLocation.position);
            SwitchGoal();
        } 
        #endregion
    }
}
