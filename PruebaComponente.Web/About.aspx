<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PruebaComponente.Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br />
        <br />
        <br />

        <div class="row">
            <div class="col-md-8 col-md-offset-2">                
                <h4 id="lblTitulo" class="text-center" runat="server">Crear Usuario</h4>

                <br />
                <br />

                <div class="form-group row text-center" id="divId" visible="false" runat="server">
                    <label class="col-md-6">Id</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese un Id"
                            ControlToValidate="txtId" Display="Dynamic" ForeColor="Red"
                            ValidationGroup="Formulario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row text-center">
                    <label class="col-md-6">Nombre</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un Nombre"
                            ControlToValidate="txtNombre" Display="Dynamic" ForeColor="Red"
                            ValidationGroup="Formulario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row text-center">
                    <label class="col-md-6">Fecha Nacimiento</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese una Fecha de Nacimiento"
                            ControlToValidate="txtFechaNacimiento" Display="Dynamic" ForeColor="Red"
                            ValidationGroup="Formulario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row text-center">
                    <label class="col-md-6">Sexo</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlSexo" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" ErrorMessage="Seleccione un Sexo"
                            ControlToValidate="ddlSexo" Display="Dynamic" ForeColor="Red"
                            ValidationGroup="Formulario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-12 text-center">
                    <asp:LinkButton ID="btnGuardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="Formulario" runat="server"><i class="fa fa-floppy-o" aria-hidden="true"></i> Guardar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
