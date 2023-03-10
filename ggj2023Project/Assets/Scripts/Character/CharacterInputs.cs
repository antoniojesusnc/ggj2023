//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Character/CharacterInputs.inputactions
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

namespace Character
{
    public partial class @CharacterInputs : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CharacterInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInputs"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""7f99ac3e-aa7d-404f-8891-77e76557357e"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""cf7f89ca-b269-4351-b783-fde2b9d22048"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Backwards"",
                    ""type"": ""Value"",
                    ""id"": ""7f7d2507-8f33-4267-967a-8776a3ed4c0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Value"",
                    ""id"": ""55efa2ec-7ff3-4827-91ef-51799c5a01b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Value"",
                    ""id"": ""b726de2f-1a0c-4673-bbf3-97ec93a0ae1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""2933eab6-494f-4c82-b40e-5ce56d209636"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9c15f58a-ecb8-4d9c-b4ff-4b230e1c77e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc7561c4-a714-4338-ba65-62ea4fe644a8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8508457c-62ef-4638-871c-7f865815673d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ae858b7-9f48-4ab0-8864-daf8451bd082"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d249cd8-c88f-4e11-ac7f-0bd63c8b0e73"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7847b00-4304-43c0-aa43-3ffc235f82bc"",
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
                    ""id"": ""498453d1-7e54-48d3-9055-e529166ba0c9"",
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
                    ""id"": ""2f1918aa-25f0-48c8-b3cb-49bc846f275e"",
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
                    ""id"": ""e846c066-20cf-4711-9e77-9ff9d3902bf4"",
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
                    ""id"": ""9719feba-1ce3-4f1c-9a5d-67bf838e974d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc6303c9-59bd-41f5-b15e-fd31f68f37b9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Forward = m_Character.FindAction("Forward", throwIfNotFound: true);
            m_Character_Backwards = m_Character.FindAction("Backwards", throwIfNotFound: true);
            m_Character_Left = m_Character.FindAction("Left", throwIfNotFound: true);
            m_Character_Right = m_Character.FindAction("Right", throwIfNotFound: true);
            m_Character_Run = m_Character.FindAction("Run", throwIfNotFound: true);
            m_Character_Interact = m_Character.FindAction("Interact", throwIfNotFound: true);
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

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Forward;
        private readonly InputAction m_Character_Backwards;
        private readonly InputAction m_Character_Left;
        private readonly InputAction m_Character_Right;
        private readonly InputAction m_Character_Run;
        private readonly InputAction m_Character_Interact;
        public struct CharacterActions
        {
            private @CharacterInputs m_Wrapper;
            public CharacterActions(@CharacterInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Forward => m_Wrapper.m_Character_Forward;
            public InputAction @Backwards => m_Wrapper.m_Character_Backwards;
            public InputAction @Left => m_Wrapper.m_Character_Left;
            public InputAction @Right => m_Wrapper.m_Character_Right;
            public InputAction @Run => m_Wrapper.m_Character_Run;
            public InputAction @Interact => m_Wrapper.m_Character_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Forward.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnForward;
                    @Forward.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnForward;
                    @Forward.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnForward;
                    @Backwards.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBackwards;
                    @Backwards.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBackwards;
                    @Backwards.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnBackwards;
                    @Left.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRight;
                    @Run.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                    @Interact.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Forward.started += instance.OnForward;
                    @Forward.performed += instance.OnForward;
                    @Forward.canceled += instance.OnForward;
                    @Backwards.started += instance.OnBackwards;
                    @Backwards.performed += instance.OnBackwards;
                    @Backwards.canceled += instance.OnBackwards;
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);
        public interface ICharacterActions
        {
            void OnForward(InputAction.CallbackContext context);
            void OnBackwards(InputAction.CallbackContext context);
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
    }
}
