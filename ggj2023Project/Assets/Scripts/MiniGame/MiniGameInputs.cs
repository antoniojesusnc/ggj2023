//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/MiniGame/MiniGameInputs.inputactions
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

public partial class @MiniGameInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MiniGameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MiniGameInputs"",
    ""maps"": [
        {
            ""name"": ""MiniGame"",
            ""id"": ""fbe007d3-7dcc-4511-a6f3-48396e297f31"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""f6357732-a9d9-4fa5-9f0e-5dbd327cb069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""09348fcb-01b6-4a21-87c3-03c4c5e75261"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""a8661ac4-0d03-45d4-80c4-41a98f747bee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""b28d2025-406c-4559-b6b4-58cda57c22a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d6e47083-aca0-4af3-a5b6-367462ab4de6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""026b2499-74ad-4972-97a3-74c534664bb0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ec223c8-c8bd-421e-afca-9293bef81b44"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51753bae-e580-400c-80ef-abf2179f0407"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed44f575-795c-4749-94f1-b509a8fa15c2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daea5021-d22c-4d00-a2ed-d0945386be6c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8238924a-7e11-4b16-b3d0-6498eac6fe1d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed59b13b-109d-45db-b73c-9027ef2c69fe"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MiniGame
        m_MiniGame = asset.FindActionMap("MiniGame", throwIfNotFound: true);
        m_MiniGame_Left = m_MiniGame.FindAction("Left", throwIfNotFound: true);
        m_MiniGame_Right = m_MiniGame.FindAction("Right", throwIfNotFound: true);
        m_MiniGame_Up = m_MiniGame.FindAction("Up", throwIfNotFound: true);
        m_MiniGame_Down = m_MiniGame.FindAction("Down", throwIfNotFound: true);
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

    // MiniGame
    private readonly InputActionMap m_MiniGame;
    private IMiniGameActions m_MiniGameActionsCallbackInterface;
    private readonly InputAction m_MiniGame_Left;
    private readonly InputAction m_MiniGame_Right;
    private readonly InputAction m_MiniGame_Up;
    private readonly InputAction m_MiniGame_Down;
    public struct MiniGameActions
    {
        private @MiniGameInputs m_Wrapper;
        public MiniGameActions(@MiniGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_MiniGame_Left;
        public InputAction @Right => m_Wrapper.m_MiniGame_Right;
        public InputAction @Up => m_Wrapper.m_MiniGame_Up;
        public InputAction @Down => m_Wrapper.m_MiniGame_Down;
        public InputActionMap Get() { return m_Wrapper.m_MiniGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiniGameActions set) { return set.Get(); }
        public void SetCallbacks(IMiniGameActions instance)
        {
            if (m_Wrapper.m_MiniGameActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnRight;
                @Up.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_MiniGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public MiniGameActions @MiniGame => new MiniGameActions(this);
    public interface IMiniGameActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}