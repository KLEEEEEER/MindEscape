using DifferentPlanetSession.Core.Player.InteractState;
using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player
{
    [System.Serializable]
    public enum InteractStateIndex
    {
        CameraCursor,
        Trigger,
    }
    public class PlayerInteractFSM : MonoBehaviour
    {
        [Header("Main Properties")]
        [SerializeField] private InteractStateIndex startInteractingState = InteractStateIndex.Trigger;
        [SerializeField] public Inventory Inventory;
        public PlayerInteract playerInteract;

        protected Dictionary<InteractStateIndex, PlayerInteractBaseState> m_states = new Dictionary<InteractStateIndex, PlayerInteractBaseState>();
        protected PlayerInteractBaseState m_currentState;

        private void Start()
        {
            m_states.Add(InteractStateIndex.CameraCursor, new PlayerInteractCameraCursorState(this));
            m_states.Add(InteractStateIndex.Trigger, new PlayerInteractTriggerState(this));

            m_currentState = m_states[startInteractingState];
            SetCurrentState(startInteractingState);
        }
        public void Add(InteractStateIndex key, PlayerInteractBaseState state)
        {
            m_states.Add(key, state);
        }
        public PlayerInteractBaseState GetState(InteractStateIndex key)
        {
            return m_states[key];
        }

        public void SetCurrentState(InteractStateIndex stateIndex)
        {
            if (m_currentState != null)
            {
                m_currentState.OnExit();
            }

            m_currentState = m_states[stateIndex];

            if (m_currentState != null)
            {
                m_currentState.OnEnter();
            }
        }
        public void Update()
        {
            if (m_currentState != null)
            {
                m_currentState.Update();
            }
        }

        public void FixedUpdate()
        {
            if (m_currentState != null)
            {
                m_currentState.FixedUpdate();
            }
        }

        public void LateUpdate()
        {
            if (m_currentState != null)
            {
                m_currentState.LateUpdate();
            }
        }
    }
}