using System.Data;

namespace R5DNCloud.Excel.Export;

public class SheetDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public string SheetName { get; set; }
    
    /// <summary>
    /// 表数据
    /// </summary>
    public DataTable Data { get; set; }
}