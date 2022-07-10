using System.Collections.Generic;

namespace FireController.Infrastructure.FsFiled
{
    public class FsField
    {
        public IDictionary<FieldKey, FieldValue> FieldKeyValue { get; }

        public FsField(FieldKey key, FieldValue value)
        {
            FieldKeyValue = new Dictionary<FieldKey, FieldValue>
            {
                {key, value}
            };
        }

        public FsField(string key, FieldType valueType, string value)
        {
            FieldKeyValue = new Dictionary<FieldKey, FieldValue>
            {
                {new FieldKey(key), new FieldValue(valueType, value)}
            };
        }
    }


    public class FieldKey
    {
        public string Key { get; }

        public FieldKey(string key)
        {
            Key = key;
        }
    }

    public class FieldValue
    {
        public string Value { get; }
        public FieldType Type { get; }

        public FieldValue(FieldType type, string value)
        {
            Value = value;
            Type = type;
        }
    }
}