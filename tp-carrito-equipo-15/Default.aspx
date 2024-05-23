<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_carrito_equipo_15.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <asp:Repeater ID="imagenesBanner" runat="server">
                <ItemTemplate>
                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                        <img src='<%# Container.DataItem %>' class="d-block w-100" alt="...">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <div class="w-25 mt-5 mx-auto">
        <asp:TextBox runat="server" ID="filter" CssClass="form-control" AutoPostBack="true" OnTextChanged="filter_TextChanged" placeholder="Buscar Articulo">  </asp:TextBox>
    </div>
    <div class="row row-cols-1 row-cols-md-4 g-4 m-5 mx-auto w-75">
        <asp:Repeater runat="server" id="listaArticulos" OnItemDataBound="listaArticulos_ItemDataBound">
            <ItemTemplate>
                <div class="col" style="max-width: 75%">
                    <div class="card h-100">
                        <picture style="min-height: 100px; border-bottom: 1px solid rgba(0, 0, 0, 0.175)">
                            <asp:Image runat="server" ID="imagenArticulo" Style="max-width: 100%;" AlternateText="Imagen no disponible"/>
                        </picture>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text text-success">$ <%#Eval("Precio")%></p>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                        </div>
                        <button type="button" Style="margin: 5px; border:none; background-color:white;">
                            <a href="Detalles.aspx?id=<%#Eval("Id")%>" class="btn btn-secondary bg-black">Ver detalle</a>
                        </button>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
