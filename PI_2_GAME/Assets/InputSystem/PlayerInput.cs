//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/InputSystem/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""134dbbd6-6251-4fad-85e9-93657a5bd5da"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""02cce161-10fa-4d71-9d17-ae7c75b21bf7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b4d2aa67-0078-4501-9ab1-956ddc84bd3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bc046d69-2054-40f4-8247-f344c0189f16"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cc649215-e396-4fdb-a2e3-054fabd8032e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""429c2529-03c6-4463-ad04-1b5d795ea96e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""14d803e9-eb8d-4d2d-b84e-6efea6f0174e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""724e77e1-23c9-4a2d-9e4a-2ca1cf5ae321"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0bc25000-77f9-43eb-9c44-f0f9d470b21e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Powers"",
            ""id"": ""8e83c501-a844-4320-a641-c172d4985d18"",
            ""actions"": [
                {
                    ""name"": ""CastSpell"",
                    ""type"": ""Button"",
                    ""id"": ""aa359aad-cd16-458b-8f3a-1868a825d3f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ad8484d-a077-42a2-a72a-8e7aa444c208"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PAUSE"",
            ""id"": ""64005390-b087-45f4-ab65-b75ee5c5048c"",
            ""actions"": [
                {
                    ""name"": ""pause"",
                    ""type"": ""Button"",
                    ""id"": ""095f09c5-da1a-4fac-8947-8e3b0777dc0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2571e5ea-4211-4ca4-aeb0-458ae907f687"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // Powers
        m_Powers = asset.FindActionMap("Powers", throwIfNotFound: true);
        m_Powers_CastSpell = m_Powers.FindAction("CastSpell", throwIfNotFound: true);
        // PAUSE
        m_PAUSE = asset.FindActionMap("PAUSE", throwIfNotFound: true);
        m_PAUSE_pause = m_PAUSE.FindAction("pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Powers
    private readonly InputActionMap m_Powers;
    private List<IPowersActions> m_PowersActionsCallbackInterfaces = new List<IPowersActions>();
    private readonly InputAction m_Powers_CastSpell;
    public struct PowersActions
    {
        private @PlayerInput m_Wrapper;
        public PowersActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastSpell => m_Wrapper.m_Powers_CastSpell;
        public InputActionMap Get() { return m_Wrapper.m_Powers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PowersActions set) { return set.Get(); }
        public void AddCallbacks(IPowersActions instance)
        {
            if (instance == null || m_Wrapper.m_PowersActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PowersActionsCallbackInterfaces.Add(instance);
            @CastSpell.started += instance.OnCastSpell;
            @CastSpell.performed += instance.OnCastSpell;
            @CastSpell.canceled += instance.OnCastSpell;
        }

        private void UnregisterCallbacks(IPowersActions instance)
        {
            @CastSpell.started -= instance.OnCastSpell;
            @CastSpell.performed -= instance.OnCastSpell;
            @CastSpell.canceled -= instance.OnCastSpell;
        }

        public void RemoveCallbacks(IPowersActions instance)
        {
            if (m_Wrapper.m_PowersActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPowersActions instance)
        {
            foreach (var item in m_Wrapper.m_PowersActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PowersActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PowersActions @Powers => new PowersActions(this);

    // PAUSE
    private readonly InputActionMap m_PAUSE;
    private List<IPAUSEActions> m_PAUSEActionsCallbackInterfaces = new List<IPAUSEActions>();
    private readonly InputAction m_PAUSE_pause;
    public struct PAUSEActions
    {
        private @PlayerInput m_Wrapper;
        public PAUSEActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @pause => m_Wrapper.m_PAUSE_pause;
        public InputActionMap Get() { return m_Wrapper.m_PAUSE; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PAUSEActions set) { return set.Get(); }
        public void AddCallbacks(IPAUSEActions instance)
        {
            if (instance == null || m_Wrapper.m_PAUSEActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PAUSEActionsCallbackInterfaces.Add(instance);
            @pause.started += instance.OnPause;
            @pause.performed += instance.OnPause;
            @pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPAUSEActions instance)
        {
            @pause.started -= instance.OnPause;
            @pause.performed -= instance.OnPause;
            @pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPAUSEActions instance)
        {
            if (m_Wrapper.m_PAUSEActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPAUSEActions instance)
        {
            foreach (var item in m_Wrapper.m_PAUSEActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PAUSEActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PAUSEActions @PAUSE => new PAUSEActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IPowersActions
    {
        void OnCastSpell(InputAction.CallbackContext context);
    }
    public interface IPAUSEActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
