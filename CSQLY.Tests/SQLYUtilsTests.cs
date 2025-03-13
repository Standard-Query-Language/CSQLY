using System.Collections;
using CSQLY.Core;
using CSQLY.Errors;
using Xunit;

namespace CSQLY.Tests;

public class SQLYUtilsTests
{
    [Fact]
    public void TestParseYaml()
    {
        var yaml = @"
select:
  columns:
    - name
    - email
  from: users
  where:
    active: true
";
        var result = SQLYUtils.ParseYaml(yaml);
        Assert.NotNull(result);
    }

    [Fact]
    public void TestTranslateToSql()
    {
        var query = new Dictionary<string, object>
        {
            ["select"] = new Dictionary<string, object>
            {
                ["columns"] = new[] { "name", "email" },
                ["from"] = "users",
                ["where"] = new Dictionary<string, object>
                {
                    ["active"] = true
                }
            }
        };

        var (sql, parameters) = SQLYUtils.TranslateToSql(query, "sqlite");
        Assert.NotNull(sql);
        Assert.NotNull(parameters);
    }
}
