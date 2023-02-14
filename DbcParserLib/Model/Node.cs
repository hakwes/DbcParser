using System;
using System.Collections.Generic;

namespace DbcParserLib.Model
{
    public class Node
    {
        public string Name;
        public string Comment;
    }

    public class Message
    {
        public uint ID;
        public bool IsExtID;
        public string Name;
        public ushort DLC;
        public string Transmitter;
        public string Comment;
        public int CycleTime;
        public List<Signal> Signals = new List<Signal>();
    }

    public class Signal
    {
        private DbcValueType m_ValueType = DbcValueType.Signed;

        public uint ID;
        public string Name;
        public ushort StartBit;
        public ushort Length;
        public byte ByteOrder = 1;
        [Obsolete("Please use ValueType instead. IsSigned will be removed in future releases")]
        public byte IsSigned { get; private set; } = 1;
        public DbcValueType ValueType
        {
            get
            {
                return m_ValueType;
            }
            set
            {
                m_ValueType = value;
                IsSigned = (byte)(value == DbcValueType.Unsigned ? 0 : 1);
            }
        }
        public double InitialValue;
        public double Factor = 1;
        public bool IsInteger = false;
        public double Offset;
        public double Minimum;
        public double Maximum;
        public string Unit;
        public string[] Receiver;
        public string ValueTable;
        public Dictionary<double, string> Descriptions = new Dictionary<double, string>();
        public string Comment;
        public string Multiplexing;
    }

    public enum DbcValueType
    {
        Signed, Unsigned, IEEEFloat, IEEEDouble
    }
}