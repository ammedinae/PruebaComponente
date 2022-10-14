using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaComponente.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaInicial();
            }
        }

        protected void CargaInicial()
        {
            try
            {
                CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                var resultado = crudService.Consulta();

                tablaValores.DataSource = resultado;
                tablaValores.DataBind();
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                string id = btn.CommandArgument;

                Response.Redirect("About?id="+id);
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                var id = btn.CommandArgument;

                if (id != "")
                {
                    CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                    var resultado = crudService.Eliminar(Convert.ToInt64(id));

                    if (resultado.Respuesta)
                    {
                        Util.util.Succes(Page, "Usuario eliminado exitosamente", "Default");
                    }
                    else
                    {
                        Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponse contextResponse = Response;
                contextResponse.Clear();
                contextResponse.ClearContent();
                contextResponse.ClearHeaders();
                contextResponse.Buffer = true;
                contextResponse.ContentEncoding = Encoding.UTF8;
                contextResponse.Cache.SetCacheability(HttpCacheability.NoCache);

                CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                var resultado = crudService.Consulta();

                ExcelPackage excel = new ExcelPackage();
                excel.Workbook.Worksheets.Add("Usuarios");
                ExcelWorksheet sheet = excel.Workbook.Worksheets[1];

                int row = 2;

                sheet.Cells[1, 1].Value = "Nombre";
                sheet.Cells[1, 2].Value = "FechaNacimiento";
                sheet.Cells[1, 3].Value = "Sexo";

                sheet.Cells["A1:C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:C1"].Style.Font.Bold = true;
                sheet.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#bf251d"));
                sheet.Cells["A1:C1"].Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FFFFFF"));
                sheet.Cells["A1:C1"].Style.Font.Size = 20;

                foreach (var item in resultado)
                {
                    sheet.Cells[row, 1].Value = item.Nombre;
                    sheet.Cells[row, 2].Value = item.FechaNacimiento.ToString("yyyy-MM-dd");
                    sheet.Cells[row, 3].Value = item.Sexo;

                    row++;
                }

                sheet.Cells.AutoFitColumns();

                using (var memoryStream = new MemoryStream())
                {
                    var fecha = DateTime.Now.ToString("yyyyMMdd");

                    contextResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    contextResponse.AddHeader("content-disposition", "attachment; filename=Usuarios" + fecha + ".xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(contextResponse.OutputStream);

                    contextResponse.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    contextResponse.End();
                }
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }
    }
}