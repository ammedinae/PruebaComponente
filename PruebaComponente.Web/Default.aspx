<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaComponente.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br />
        <br />
        <br />

        <div class="row">
            <div class="col-md-6 text-center">
                <asp:LinkButton ID="btnCrear" CssClass="btn btn-success" ToolTip="Crear" OnClick="btnCrear_Click" runat="server"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="col-md-6 text-center">
                <asp:LinkButton ID="btnExcel" CssClass="btn btn-info" ToolTip="Exportar a Excel" OnClick="btnExcel_Click" runat="server"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
            </div>
        </div>
        <br />
        <br />

        <div class="row">

            <div class="col-md-8 col-md-offset-2">
                <div class="card">
                    <div class="card-body">
                        <div class="col-md-12">
                            <table class="table table-bordered table-hover table-responsive-sm" id="myTable">
                                <thead>
                                    <tr class="tableColor">
                                        <th>Id</th>
                                        <th>Nombre</th>
                                        <th>Fecha Nacimiento</th>
                                        <th>Sexo</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="tablaValores" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval ("Id")%></td>
                                                <td><%#Eval ("Nombre")%></td>
                                                <td><%#Eval ("FechaNacimiento")%></td>
                                                <td><%#Eval ("Sexo")%></td>
                                                <td class="text-center">
                                                    <asp:LinkButton ID="btnEditar" CommandArgument='<%#Eval ("Id")%>' ToolTip="Editar" OnClick="btnCrear_Click" runat="server"><i class="fa fa-pencil-square-o editar" aria-hidden="true"></i></asp:LinkButton>
                                                    <%--<asp:Button ClientIDMode="Static" ID="btnEliminar" OnClientClick="confirmarEliminacion" OnClick="btnEliminar_Click" Text="El" runat="server" />--%>
                                                    <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval ("Id")%>' ToolTip="Eliminar" OnClientClick="confirmarEliminacion" OnClick="btnEliminar_Click" runat="server"><i class="fa fa-trash-o eliminar" aria-hidden="true"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $('#myTable').DataTable();
        });
    </script>

</asp:Content>
