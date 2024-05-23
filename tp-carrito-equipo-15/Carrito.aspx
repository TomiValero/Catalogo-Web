<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_carrito_equipo_15.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="margin-top: 70px; min-height: 750px">
      <div class="row">
          <div class="col">
              <asp:Repeater runat="server" ID="repetidor1">
                  <ItemTemplate>
                      <div class="card w-75 m-3">
                          <div class="card-body" style="position: relative;">
                              <div style="width: 100px; height: auto; float: left; margin-right: 10px;">
                                  <img src="<%#Eval("Img") %>" class="d-block w-100">
                              </div>
                              <h5 class="card-title">"<%#Eval("Titulo") %>" </h5>

                              <div style="position:static; bottom: 10px; right: 100px">
                                  <asp:Button   runat="server" ID="btnRestar" Text="-" CssClass="btn btn-light" CommandArgument='<%#Eval("Id") %>' CommandName="articuloID"  Onclick="btnRestar_Click" />
                                    <label id="lblCantidad"><%#Eval("Cant") %></label>                  
                                  <asp:Button runat="server" ID="btnSumar" Text="+" CssClass="btn btn-light"  CommandArgument='<%#Eval("Id") %>' CommandName="articuloID2" Onclick="btnSumar_Click" />
                              </div>
                              <label id="lblPrecio" style="position: absolute; bottom: 0; right: 0; margin: 10px;">$<%# Eval("Precio") %></label>
                              <asp:Button ID="btnEliminar" class="btn-close" Style="position: absolute; top: 0; right: 0;" aria-label="Close" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="articuloID" OnClick="btnEliminar_Click" />
                          </div>
                      </div>
                  </ItemTemplate>
              </asp:Repeater>
          </div>
          <div class="col" style="max-width: 30%; ">
              <div class="card" style="width: 18rem; ">
                  <div class="card-body" style="display: flex; flex-direction: column; align-items: start; gap: 10px;">
                      <h5 class="card-title" >Resumen</h5>
                      <a href="Default.aspx" class="btn btn-secondary bg-black"">Continuar Compra</a>
                      <h5 class="card-title">Total</h5>
                      <asp:Label runat="server" ID="lblTotal">$<%=TotalPagoArticulos %> </asp:Label>
                  </div>
              </div>
          </div>
      </div>
  </div>

</asp:Content>