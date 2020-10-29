using DifferentPlanetSession.Core.Player.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DifferentPlanetSession.Core.Player
{
    public enum StateIndex
    {
        Idle,
        Running,
        Jumping,
        DisabledMovement,
        DisabledCamera,
        DisabledBoth
    }

    public class PlayerFSM : MonoBehaviour
    {
        public PlayerCamera playerCamera;
        public PlayerMovement playerMovement;

        [Header("Properties")]
        [SerializeField] private bool _canAirControl = false;
        [SerializeField] private bool _isStuckInIdle = false;
        public bool CanAirControl => _canAirControl;
        public bool IsStuckInIdle => _isStuckInIdle;

        protected Dictionary<StateIndex, PlayerBaseState> m_states = new Dictionary<StateIndex, PlayerBaseState>();

        protected PlayerBaseState m_currentState;

        private void Start()
        {
            m_states.Add(StateIndex.Idle, new PlayerIdleState(this));
            m_states.Add(StateIndex.Running, new PlayerRunningState(this));
            m_states.Add(StateIndex.Jumping, new PlayerJumpingState(this));
            m_states.Add(StateIndex.DisabledMovement, new PlayerDisabledMovementState(this));
            m_states.Add(StateIndex.DisabledCamera, new PlayerDisabledCameraState(this));
            m_states.Add(StateIndex.DisabledBoth, new PlayerDisabledBothState(this));

            //SetCurrentState(StateIndex.Idle);
            m_currentState = m_states[StateIndex.Idle];
            SetCurrentState(StateIndex.DisabledBoth);

            //Debug.Log($"Setting states. Currently {m_states.Count} states.");
        }

        public void Add(StateIndex key, PlayerBaseState state)
        {
            m_states.Add(key, state);
        }
        public PlayerBaseState GetState(StateIndex key)
        {
            return m_states[key];
        }

        public void SetCurrentState(StateIndex stateIndex)
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