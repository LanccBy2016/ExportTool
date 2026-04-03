using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExportTool
{
    public class SqlScript
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public List<(string Name, string DefaultValue)> GetVariables()
        {
            var variables = new List<(string Name, string DefaultValue)>();
            if (!string.IsNullOrEmpty(Content))
            {
                var matches = Regex.Matches(Content, @"\$\{(\w+)(?:=(.*?))?\}");
                foreach (Match match in matches)
                {
                    var name = match.Groups[1].Value;
                    var defaultValue = match.Groups[2].Value;
                    if (!variables.Any(v => v.Name == name))
                    {
                        variables.Add((name, defaultValue));
                    }
                }
            }
            return variables;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
