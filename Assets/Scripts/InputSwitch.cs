using UnityEngine;

public class InputSwitch : MonoBehaviour
{
    public bool state;
    public LogicGate outputGate;

    public void Toggle()
    {
        state = !state;

        outputGate.ClearInputs();
        outputGate.AddInput(state);
    }
}