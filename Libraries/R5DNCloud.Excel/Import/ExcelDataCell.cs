namespace R5DNCloud.Excel.Import;

/// <summary>
/// Excel数据单元格
/// </summary>
public class ExcelDataCell : ExcelColumnProperty
{
    public ExcelDataCell(ExcelColumnProperty property)
    {
        Column = property.Column;
        DictionaryGroupCode = property.DictionaryGroupCode;
        Title = property.Title;
        Name = property.Name;
    }
    
    /// <summary>
    /// 单元格的值
    /// </summary>
    public string Value { get; set; }
}