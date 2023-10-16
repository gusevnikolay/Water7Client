using System;
public class MetaParameter
{
    public int parameterIndex;
    public bool calib;
    public string comment;
    public int div;
    public Int64 max_value;
    public Int64 min_value;
    public float mul;
    public string name;
    public bool primary;
    public string unit;
    public bool write;

    public MetaType Type;


    public enum MetaType
    {
        Event,
        Parameter,
        Control
    }
}

