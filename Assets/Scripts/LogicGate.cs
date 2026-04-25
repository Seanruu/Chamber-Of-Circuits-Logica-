using UnityEngine;
using System.Collections.Generic;

public enum GateType
{
    AND,
    OR,
    NOT,
    NAND,
    NOR
}

public class LogicGate : MonoBehaviour
{
    public GateType gateType;

    [Header("Inputs")]
    public List<bool> inputs = new List<bool>();

    [Header("Output")]
    public bool output;

    public List<LogicGate> connectedOutputs = new List<LogicGate>();

    public void AddInput(bool value)
    {
        inputs.Add(value);
        Evaluate();
    }

    public void ConnectTo(LogicGate target)
    {
        connectedOutputs.Add(target);
    }

    public void ClearInputs()
    {
        inputs.Clear();
    }

    public void Evaluate()
    {
        switch (gateType)
        {
            case GateType.AND:
                output = inputs.TrueForAll(x => x == true);
                break;

            case GateType.OR:
                output = inputs.Contains(true);
                break;

            case GateType.NOT:
                output = inputs.Count > 0 ? !inputs[0] : false;
                break;

            case GateType.NAND:
                output = !(inputs.TrueForAll(x => x == true));
                break;

            case GateType.NOR:
                output = !(inputs.Contains(true));
                break;
        }

        SendOutput();
    }

    void SendOutput()
    {
        foreach (var gate in connectedOutputs)
        {
            gate.AddInput(output);
        }
    }
}