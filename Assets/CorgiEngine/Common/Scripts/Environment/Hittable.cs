using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.Events;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// A class needed on pushable objects if you want your character to be able to detect them
    /// </summary>
    [RequireComponent(typeof(Health))]
    public class Hittable : MonoBehaviour
    {
        public UnityEvent ActionOnHit;
        public UnityEvent ActionOnHitZero;

        protected Health _health;

        protected virtual void Start()
        {
            _health = this.gameObject.GetComponent<Health>();
        }

        protected virtual void OnHit()
        {
            ActionOnHit.Invoke();
        }

        protected virtual void OnHitZero()
        {
            ActionOnHitZero.Invoke();
        }

        /// <summary>
		/// On enable, we bind our respawn delegate
		/// </summary>
		protected virtual void OnEnable()
        {
            if (_health == null)
            {
                _health = GetComponent<Health>();
            }

            if (_health != null)
            {
                _health.OnHit += OnHit;
                _health.OnHitZero += OnHitZero;
            }
        }

        /// <summary>
        /// On disable, we unbind our respawn delegate
        /// </summary>
        protected virtual void OnDisable()
        {
            if (_health != null)
            {
                _health.OnHit -= OnHit;
                _health.OnHitZero -= OnHitZero;
            }
        }
    }
}