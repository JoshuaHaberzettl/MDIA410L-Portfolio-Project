// GENERATED AUTOMATICALLY FROM 'Assets/PauseMenu/PauseAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PauseAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PauseAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PauseAction"",
    ""maps"": [
        {
            ""name"": ""Pause"",
            ""id"": ""809c9c3a-3b78-4ee5-9784-5d4fb1512968"",
            ""actions"": [
                {
                    ""name"": ""PauseAction"",
                    ""type"": ""Button"",
                    ""id"": ""d0ceb60c-1acb-4fc9-a1d1-74bdd81ef52a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""550bbf6b-e8af-4bbe-9236-27da4ba7b0da"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9898f13-9452-418d-b15f-c09788b7afda"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_PauseAction = m_Pause.FindAction("PauseAction", throwIfNotFound: true);
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

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_PauseAction;
    public struct PauseActions
    {
        private @PauseAction m_Wrapper;
        public PauseActions(@PauseAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseAction => m_Wrapper.m_Pause_PauseAction;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @PauseAction.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseAction;
                @PauseAction.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseAction;
                @PauseAction.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseAction;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseAction.started += instance.OnPauseAction;
                @PauseAction.performed += instance.OnPauseAction;
                @PauseAction.canceled += instance.OnPauseAction;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);
    public interface IPauseActions
    {
        void OnPauseAction(InputAction.CallbackContext context);
    }
}
