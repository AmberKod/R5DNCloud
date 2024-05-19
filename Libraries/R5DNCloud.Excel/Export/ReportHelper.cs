using System.Dynamic;
using System.Text;
using OfficeOpenXml;

namespace R5DNCloud.Excel.Export;

/// <summary>
/// 报表内置函数，所有 Excel 开头的函数只能在 Excel 报表中使用，Html 开头的只能在 Html 中使用。未标注的，则通用
/// </summary>
public static class ReportHelper
{
        public static string ExcelCheckbox(object value)
    {
        //☑☑🗹☑☑☑☑■
        return value is bool ? (bool)value ? "☑" : "□" : "□";
    }

    /// <summary>
    /// 日期格式化
    /// </summary>
    /// <param name="value"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string ExcelDateFormat(object value, string format)
    {
        if (value == null)
        {
            return string.Empty;
        }

        if (value is DateTime date)
        {
            return date.ToString(format);
        }

        if (DateTime.TryParse(value.ToString(), out date))
        {
            return date.ToString(format);
        }

        return string.Empty;
    }

    /// <summary>
    /// 对比人均收入
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static string ExcelCompareIncomePer(object value, string minValue, string maxValue)
    {
        if (value == null)
        {
            return ExcelCheckbox(false);
        }

        if (!decimal.TryParse(minValue, out decimal minIncome))
        {
            return ExcelCheckbox(false);
        }

        if (!decimal.TryParse(maxValue, out decimal maxIncome))
        {
            return ExcelCheckbox(false);
        }

        decimal incomePer;

        if (value is decimal)
        {
            incomePer = (decimal)value;
        }
        else
        {
            if (!decimal.TryParse(value.ToString(), out incomePer))
            {
                return ExcelCheckbox(false);
            }
        }

        return ExcelCheckbox(incomePer > minIncome && incomePer < maxIncome);
    }

    /// <summary>
    /// 逻辑与计算，计算传入的值是否都为真
    /// </summary>
    /// <returns></returns>
    public static string ExcelLogicalConjunction(List<object> args)
    {
        return ExcelCheckbox(args.Select(a => a == null ? false : (bool)a).Any(a => a));
    }

    /// <summary>
    /// 比较两个值，只支持 数值类型比较
    /// </summary>
    /// <param name="value"></param>
    /// <param name="method"></param>
    /// <param name="compareValue"></param>
    /// <returns></returns>
    public static string ExcelCompare(object value, string method, string compareValue)
    {
        if (value == null)
        {
            return ExcelCheckbox(false);
        }

        if (string.IsNullOrWhiteSpace(method))
        {
            return ExcelCheckbox(false);
        }

        if (string.IsNullOrWhiteSpace(compareValue))
        {
            return ExcelCheckbox(false);
        }

        var source = (decimal)Convert.ChangeType(value, typeof(decimal));
        var standard = (decimal)Convert.ChangeType(compareValue, typeof(decimal));

        switch (method.Trim())
        {
            case ">":
                return ExcelCheckbox(source > standard);

            case "<":
                return ExcelCheckbox(source < standard);

            case "=":
                return ExcelCheckbox(source == standard);

            case ">=":
                return ExcelCheckbox(source >= standard);

            case "<=":
                return ExcelCheckbox(source <= standard);

            case "!=":
                return ExcelCheckbox(source != standard);
        }

        return ExcelCheckbox(false);
    }

    /// <summary>
    /// 取反，目前只支持 Bool 类型
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExcelNegate(object value)
    {
        return ExcelCheckbox(value is bool && !(bool)value);
    }

    /// <summary>
    /// 在 Excel 中插入图片，目前只支持 PNG 格式的 Base64 图片
    /// </summary>
    /// <param name="sheet"></param>
    /// <param name="name"></param>
    /// <param name="pictureBase64"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="rowOffset"></param>
    /// <param name="columnOffset"></param>
    public static void InsertPicture(ExcelWorksheet sheet, string name, string pictureBase64, int row, int column, int width, int height, int rowOffset, int columnOffset)
    {
        pictureBase64 = pictureBase64.Replace("data:image/png;base64,", "");
        var bytes = Convert.FromBase64String(pictureBase64);

        using var stream = new MemoryStream(bytes);

        var picture = sheet.Drawings.AddPicture(name, stream);

        picture.SetSize(width, height);

        picture.SetPosition(row, rowOffset, column, columnOffset);
    }

    /// <summary>
    /// 在 Excel 中插入图片，byte数组
    /// </summary>
    /// <param name="sheet"></param>
    /// <param name="name"></param>
    /// <param name="bytes"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="rowOffset"></param>
    /// <param name="columnOffset"></param>
    public static void InsertPicture(ExcelWorksheet sheet, string name, byte[] bytes, int row, int column, int width, int height, int rowOffset, int columnOffset)
    {
        using var stream = new MemoryStream(bytes);
        var picture = sheet.Drawings.AddPicture(name, stream);

        picture.SetSize(width, height);

        picture.SetPosition(row, rowOffset, column, columnOffset);
    }

    /// <summary>
    /// 在 Html 中插入图片
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string InsertPictureInHtml(object value)
    {
        if (value == null || (value is string base64 && string.IsNullOrWhiteSpace(base64)))
        {
            return string.Empty;
        }

        return $"<img src=\"{value}\" class=\"sign-picture\" />";
    }

    /// <summary>
    /// 如果数据为空或者 null ， 则显示默认值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static string Default(object value, string defaultValue)
    {
        if (value is null)
        {
            return defaultValue;
        }

        if (value is string str)
        {
            return string.IsNullOrWhiteSpace(str) ? defaultValue : str;
        }

        return value.ToString();
    }

    public static string InsertProblem(object value)
    {
        if (value == null)
        {
            return string.Empty;
        }

        if (value is List<ExpandoObject> problems)
        {
            var problemBuilder = new StringBuilder();
            foreach (var problem in problems)
            {
                var problemContent = problem.SingleOrDefault(a => a.Key == "Content").Value?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(problemContent))
                {
                    problemBuilder.AppendLine(problemContent);
                }
            }

            return problemBuilder.ToString();
        }

        return string.Empty;
    }

    public static string DecimalDivision(object value, string divisor)
    {
        if (value == null)
        {
            return string.Empty;
        }

        if (!decimal.TryParse(value.ToString(), out var decimalValue))
        {
            return string.Empty;
        }

        if (!decimal.TryParse(divisor, out var divisorValue))
        {
            return string.Empty;
        }

        if (divisorValue == 0)
        {
            return string.Empty;
        }

        return Math.Round(decimalValue / divisorValue, 2).ToString();
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="value"></param>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    public static string Substring(object value, string startPos, string endPos)
    {
        if (value is not string str)
        {
            return string.Empty;
        }

        var start = int.Parse(startPos);
        var end = int.Parse(endPos);

        if (str.Length < end)
        {
            return string.Empty;
        }

        return str.Substring(start, end - start);
    }

    /// <summary>
    /// 对比两个值是否相等
    /// </summary>
    /// <param name="value"></param>
    /// <param name="compareValue"></param>
    /// <returns></returns>
    public static string CompareValue(object value, string compareValue)
    {
        var sv = value?.ToString() ?? "";
        return ExcelCheckbox(sv == compareValue);
    }

    /// <summary>
    /// Html Checkbox
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string HtmlCheckbox(object value)
    {
        //☑☑🗹☑☑☑☑■□
        return value is bool ? (bool)value ? "■" : "□" : "□";
    }

    public static string HtmlCompareValue(object value, string compareValue)
    {
        var sv = value?.ToString() ?? "";
        return HtmlCheckbox(sv == compareValue);
    }

    public static string HtmlIfValue(object value, object compareValue, string resultValue1 = "", string resultValue2 = "")
    {
        return value == compareValue ? resultValue1 : resultValue2;
    }
}