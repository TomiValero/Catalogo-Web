<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="tp_carrito_equipo_15.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin:20px; min-height: 750px">

    <div Class="col-sm-7"> 

      <div id="carouselExampleControls" class="carousel slide" data-ride="carousel" >

          <div class="carousel-inner">
              <div class="carousel-item active">
                  <asp:Image ID="Imagen" runat="server" AlternateText="Imagen no disponible" CssClass ="d-block w-100" style="width:400px; height:400px; object-fit: contain;"/>
              </div> 
          </div>

          <asp:LinkButton ID="BtnAnterior" runat="server" CssClass="carousel-control-prev" OnClick="BtnAnterior_Click">
              <span class="carousel-control-prev-icon bg-black" aria-hidden="true"></span>
          </asp:LinkButton>
           <asp:LinkButton ID="BtnProxima" runat="server" CssClass="carousel-control-next" OnClick="BtnProxima_Click">
               <span class="carousel-control-next-icon bg-black" aria-hidden="true"></span>
          </asp:LinkButton>

      </div>

    </div>

  <div class="col-sm" style="margin:20px">
      <h2 class="h2"><%= art.Nombre.ToString() %></h2>
      <h3 class="h3"><%= "$" + art.Precio.ToString() %></h3>

      <div style="margin:5px;">
          <asp:Label ID="lblMarca" runat="server" Text="Label" class="badge badge-primary bg-black"></asp:Label>
          <asp:Label ID="lblCategoria" runat="server" Text="Label" class="badge badge-primary bg-black"></asp:Label>
          <asp:Label ID="lblCodigo" runat="server" Text="Label" class="badge badge-primary bg-black"></asp:Label>
      </div>
      
      <p class="lead"><%= art.Descripcion.ToString() %></p>
      <div>
          <asp:Label ID="LblCantidad" runat="server" Text="Cantidad:" ></asp:Label>
      </div>
      <div style="margin-bottom:10px">  
          <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="custom-select" style="width:100px;"/>

          <asp:Label ID="lblWarningCant" runat="server" Text="Label" style="color:red;"></asp:Label>
      </div>
      <asp:Button ID="BtnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-secondary btn-lg btn-block bg-black" OnClick="BtnAgregar_Click" />     
  </div>

</asp:Content>
