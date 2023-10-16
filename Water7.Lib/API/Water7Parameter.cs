using System;
public class  Water7Parameter
{

    public event onValueChange onValueChangeEvent;
    public delegate void onValueChange(Water7Parameter p);

    private Int64 _value = 0;
    private StateFlag _state = StateFlag.Undefined;
    public string Name; 
    public string Description;
    public string Unit;
    public Int64 ValueSynchronizedWithServer;

    public Int64 MinValue;
    public Int64 MaxValue;
    public bool IsPrimary;
    public bool IsReadOnly;
    public float Multiplier = 1;
    public int Index;
    public MetaParameter.MetaType Type;
    public Int64 Value
    {
        get => _value;
        set
        {
            bool isNewValue = _value != value;
            _value = value;
            if (onValueChangeEvent != null && isNewValue) onValueChangeEvent(this);
        }
    }

    public StateFlag State
    {
        get =>  _state ;
        set
        {
            bool isNewValue = _state != value;
            _state = value;
            if (onValueChangeEvent != null && isNewValue) onValueChangeEvent(this);
        }
    }
    public override bool Equals(object obj)
    {
        return (obj is Water7Parameter) && ((Water7Parameter)obj).Name == Name &&
            (obj is Water7Parameter) && ((Water7Parameter)obj).Value == Value;
    }

    public enum StateFlag
    {
        Undefined,
        SynchronizedWithServer,
        ModifiedByUser,
        SentToServer,
        WaitingDeviceResponse
    }
}
