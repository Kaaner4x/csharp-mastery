namespace ReflectionAndAttributes.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class TableAttribute : Attribute
{
    public string TableName { get; }

    public TableAttribute(string tableName)
    {
        TableName = tableName;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class ColumnAttribute : Attribute
{
    public string ColumnName { get; }

    public ColumnAttribute(string columnName)
    {
        ColumnName = columnName;
    }
}
