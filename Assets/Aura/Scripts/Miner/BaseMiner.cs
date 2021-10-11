using System.Collections;
using DG.Tweening;
using UnityEngine;

/*
 * Base class for miners. 
 * has basic miner functionality
 * such as moving,collecting and depositing.
 */
namespace Aura.Scripts.Miner
{
    //TODO:Organize the members into regions
    public class BaseMiner : MonoBehaviour,IClickable
    {
        [Header("Movement Properties")]
        [SerializeField] protected float moveSpeed;

        [Header("Initial Values")]
        [SerializeField] protected float initialCollectingCapacity;
        [SerializeField] protected float initialCollectPaSecond;
        [SerializeField]protected float CollectCapacity { get; set; }
        [SerializeField]protected float CollectPaSecond { get; set; }
        protected float CurrentGold { get; set; }
        protected bool IsTimeToCollect { get; set; }

        protected Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            CollectPaSecond = initialCollectPaSecond;
            CollectCapacity = initialCollectingCapacity;
            IsTimeToCollect = true;
        }
        protected virtual void MoveMiner(Vector3 goalPos)
        {
            var tweakedGoalPos = new Vector3(goalPos.x, transform.position.y);
            transform.DOMove(tweakedGoalPos, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                if (IsTimeToCollect)
                {
                    CollectGold();
                }
                else
                {
                    DepositGold();
                }
            }).Play();
        }

        public virtual void OnClick()
        {
            
        }


        protected virtual IEnumerator IECollect(float gold, float time)
        {
            yield return null;
        }
        
        protected virtual void CollectGold()
        {
        
        }
        protected virtual void DepositGold()
        {

        }
        protected void SwitchGoal()
        {
            IsTimeToCollect = !IsTimeToCollect;
        }
        protected void FlipMiner(int direction)
        {
            //where if direction is 1 miner is facing right
            //if direction is -1 miner is facing left
            if (direction == 1)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (direction == -1)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }
}
