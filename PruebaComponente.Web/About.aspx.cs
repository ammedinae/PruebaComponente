using PruebaComponente.Web.CrudServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaComponente.Web
{
    public partial class About : Page
    {
        public static long id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Id = Request["id"];
                if (!string.IsNullOrWhiteSpace(Id))
                {
                    id = Convert.ToInt64(Id);
                }
                else
                {
                    id = 0;
                }
                CargaSelector();
                CargaInicial();
            }
        }

        protected void CargaSelector()
        {
            try
            {
                ddlSexo.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
                ddlSexo.Items.Insert(1, new ListItem("MASCULINO", "M"));
                ddlSexo.Items.Insert(2, new ListItem("FEMENINO", "F"));
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }

        protected void CargaInicial()
        {
            try
            {
                if (id > 0)
                {
                    lblTitulo.InnerText = "Editar Usuario";

                    CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                    var resultado = crudService.ConsultaId(id);

                    divId.Visible = true;

                    txtId.Text = resultado.Id.ToString();
                    txtNombre.Text = resultado.Nombre;
                    txtFechaNacimiento.Text = resultado.FechaNacimiento.ToString("yyyy-MM-dd");
                    ddlSexo.SelectedValue = resultado.Sexo;

                    txtId.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    RequestEditarUsuario requestEditarUsuario = new RequestEditarUsuario()
                    {
                        Id = id,
                        Nombre = txtNombre.Text,
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        Sexo = ddlSexo.SelectedValue
                    };

                    CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                    var respuesta = crudService.Editar(requestEditarUsuario);

                    if (respuesta.Respuesta)
                    {
                        Util.util.Succes(Page, "Usuario actualizado exitosamente", "Default");
                        id = 0;
                    }
                    else
                    {
                        Util.util.Error(Page, GetType(), "Algo ocurrio, intente nuevamente");
                    }
                }
                else
                {
                    RequestCrearUsuario requestCrearUsuario = new RequestCrearUsuario()
                    {
                        Nombre = txtNombre.Text,
                        FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                        Sexo = ddlSexo.SelectedValue
                    };

                    CrudServiceReference.CrudServiceClient crudService = new CrudServiceReference.CrudServiceClient();
                    var respuesta = crudService.Crear(requestCrearUsuario);

                    if (respuesta.Respuesta)
                    {
                        Util.util.Succes(Page, "Usuario creado exitosamente", "Default");
                        id = 0;
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
    }
}