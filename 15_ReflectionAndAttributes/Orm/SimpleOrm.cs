using System.Reflection;
using System.Text;
using ReflectionAndAttributes.Attributes;

namespace ReflectionAndAttributes.Orm;

public static class SimpleOrm
{
    /// <summary>
    /// Nesneyi okuyup, içindeki attribute'lara göre INSERT SQL cümlesi üretir.
    /// </summary>
    public static string GenerateInsertSql(object entity)
    {
        Type type = entity.GetType();
        
        // 1. Tablo adını bul
        string tableName = type.Name; // Default olarak class adını al
        var tableAttr = type.GetCustomAttribute<TableAttribute>();
        if (tableAttr != null)
        {
            tableName = tableAttr.TableName; // Table attribute varsa oradan al
        }

        // 2. Kolonları ve değerlerini bul
        var columns = new List<string>();
        var values = new List<string>();

        foreach (PropertyInfo prop in type.GetProperties())
        {
            // İlgili property'nin değerini reflection ile alıyoruz
            var val = prop.GetValue(entity);
            if (val == null) continue; // Null değerleri SQL'e eklemiyoruz

            string colName = prop.Name; // Default olarak property adını al
            var colAttr = prop.GetCustomAttribute<ColumnAttribute>();
            if (colAttr != null)
            {
                colName = colAttr.ColumnName; // Column attribute varsa onu kullan
            }

            columns.Add(colName);

            // Tipine göre değer formati (string ise tırnak içine al)
            if (prop.PropertyType == typeof(string))
                values.Add($"'{val}'");
            else
                values.Add(val.ToString()!);
        }

        // 3. SQL Cümlesini birleştir
        return $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)});";
    }
}
