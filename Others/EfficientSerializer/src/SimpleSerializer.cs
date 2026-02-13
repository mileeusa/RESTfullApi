using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EfficientSerializer.src
{
    public class SimpleSerializer
    {
        public static string Serialize(object obj)
        {
            var sb = new StringBuilder();
            SerializeValue(obj, sb);
            return sb.ToString();
        }

        public static T Deserialize<T>(string str) where T : new()
        {
            int index = 0;
            object? obj = ParseValue(typeof(T), str, ref index);
            return (T)obj!;
        }

        private static void SerializeValue(object? obj, StringBuilder sb)
        {
            if (obj == null)
            {
                sb.Append("null");
                return;
            }

            var type = obj.GetType();

            // Handle simple types
            if (type.IsPrimitive || obj is decimal)
            {
                sb.Append(obj.ToString());
            }
            else if (obj is string s)
            {
                sb.Append('"').Append(s.Replace("\"", "\\\"")).Append('"');
            }
            else if (obj is IEnumerable enumerable)
            {
                sb.Append("[");
                bool first = true;
                foreach (var item in enumerable)
                {
                    if (!first) sb.Append(", ");
                    SerializeValue(item, sb);
                    first = false;
                }
                sb.Append("]");
            }
            else
            {
                // Complex object – use reflection
                sb.Append("{");
                bool first = true;
                foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!prop.CanRead) continue;

                    if (!first) sb.Append(", ");
                    sb.Append('"').Append(prop.Name).Append("\": ");
                    SerializeValue(prop.GetValue(obj), sb);
                    first = false;
                }

                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!first) sb.Append(", ");
                    sb.Append('"').Append(field.Name).Append("\": ");
                    SerializeValue(field.GetValue(obj), sb);
                    first = false;
                }
                sb.Append("}");
            }
        }

        private static object? ParseValue(Type targetType, string str, ref int index)
        {
            SkipWhitespace(str, ref index);

            if (str[index] == '{') // object
            {
                index++; // skip '{'
                var obj = Activator.CreateInstance(targetType)!;
                while (true)
                {
                    SkipWhitespace(str, ref index);
                    if (str[index] == '}') { index++; break; }

                    string propName = ParseString(str, ref index);
                    SkipWhitespace(str, ref index);
                    if (str[index] != ':') throw new Exception("Expected ':'");
                    index++; // skip ':'

                    // Find property or field
                    var prop = targetType.GetProperty(propName);
                    var field = targetType.GetField(propName);
                    Type memberType = prop?.PropertyType ?? field?.FieldType ?? throw new Exception($"No member {propName}");

                    object? val = ParseValue(memberType, str, ref index);

                    if (prop != null && prop.CanWrite) prop.SetValue(obj, val);
                    else if (field != null) field.SetValue(obj, val);

                    SkipWhitespace(str, ref index);
                    if (str[index] == ',') index++; // next
                }
                return obj;
            }
            else if (str[index] == '[') // array / list
            {
                index++; // skip '['
                var listType = typeof(List<>).MakeGenericType(targetType.IsArray ? targetType.GetElementType()! : targetType.GetGenericArguments()[0]);
                var list = (IList)Activator.CreateInstance(listType)!;

                while (true)
                {
                    SkipWhitespace(str, ref index);
                    if (str[index] == ']') { index++; break; }
                    var elemType = targetType.IsArray ? targetType.GetElementType()! : targetType.GetGenericArguments()[0];
                    var elem = ParseValue(elemType, str, ref index);
                    list.Add(elem);
                    SkipWhitespace(str, ref index);
                    if (str[index] == ',') index++;
                }

                if (targetType.IsArray)
                {
                    var arr = Array.CreateInstance(targetType.GetElementType()!, list.Count);
                    list.CopyTo(arr, 0);
                    return arr;
                }
                return list;
            }
            else if (str[index] == '"') // string
            {
                return ParseString(str, ref index);
            }
            else // primitive
            {
                return ParsePrimitive(targetType, str, ref index);
            }
        }

        private static string ParseString(string str, ref int index)
        {
            index++; // skip opening '"'
            var sb = new StringBuilder();
            while (str[index] != '"')
            {
                if (str[index] == '\\') { index++; sb.Append(str[index]); index++; }
                else sb.Append(str[index++]);
            }
            index++; // skip closing '"'
            return sb.ToString();
        }

        private static object ParsePrimitive(Type targetType, string str, ref int index)
        {
            int start = index;
            while (index < str.Length && !char.IsWhiteSpace(str[index]) && ",]}".IndexOf(str[index]) == -1)
                index++;
            string token = str.Substring(start, index - start);

            if (targetType == typeof(int)) return int.Parse(token);
            if (targetType == typeof(long)) return long.Parse(token);
            if (targetType == typeof(float)) return float.Parse(token);
            if (targetType == typeof(double)) return double.Parse(token);
            if (targetType == typeof(bool)) return bool.Parse(token);
            if (targetType == typeof(decimal)) return decimal.Parse(token);
            if (targetType.IsEnum) return Enum.Parse(targetType, token);
            throw new Exception($"Unsupported type {targetType}");
        }

        private static void SkipWhitespace(string str, ref int index)
        {
            while (index < str.Length && char.IsWhiteSpace(str[index])) index++;
        }
    }
}
