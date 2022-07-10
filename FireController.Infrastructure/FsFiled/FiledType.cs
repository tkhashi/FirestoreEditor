namespace FireController.Infrastructure.FsFiled
{
    public enum FieldType
    {
        String,
        Number,
        Bool,
        Map,
        Array,
        Null,
        TimeStamp,
        GeoPoint,
        Reference,
    }

    public static class FieldTypeExtensions
    {
        public static FieldType ToFieldType(this string type)
        {
            return type switch
            {
                "string" => FieldType.String,
                "number" => FieldType.Number,
                "boolean" => FieldType.Bool,
                "map" => FieldType.Map,
                "array" => FieldType.Array,
                "null" => FieldType.Null,
                "timestamp" => FieldType.TimeStamp,
                "geoPoint" => FieldType.GeoPoint,
                "reference" => FieldType.Reference,
                _ => FieldType.Null,
            };
        }

        public static string ToTypeString(this FieldType type)
        {
            return type switch
            {
                FieldType.String => "string",
                FieldType.Number => "number",
                FieldType.Bool => "boolean",
                FieldType.Map => "map",
                FieldType.Array => "array",
                FieldType.Null => "null",
                FieldType.TimeStamp => "timestamp",
                FieldType.GeoPoint => "geopoint",
                FieldType.Reference => "reference",
                _ => "null",
            };
        }
    }
}