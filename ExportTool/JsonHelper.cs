using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace ExportTool
{
    public static class JsonHelper
    {
        private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static string Serialize(object obj)
        {
            return serializer.Serialize(obj);
        }

        public static string SerializeIndented(object obj)
        {
            var json = serializer.Serialize(obj);
            return FormatJson(json);
        }

        public static T Deserialize<T>(string json)
        {
            return serializer.Deserialize<T>(json);
        }

        private static string FormatJson(string json)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < json.Length; i++)
            {
                var ch = json[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            indent++;
                            for (int j = 0; j < indent; j++)
                                sb.Append("  ");
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            indent--;
                            for (int j = 0; j < indent; j++)
                                sb.Append("  ");
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && json[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            for (int j = 0; j < indent; j++)
                                sb.Append("  ");
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
