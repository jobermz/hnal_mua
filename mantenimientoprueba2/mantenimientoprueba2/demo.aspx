<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="demo.aspx.vb" Inherits="mantenimientoprueba2.demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DEMO DE MANTENIMIENTO</title>
    
<!-- Template stylesheet -->
<link href="css/blue/screen.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/blue/datepicker.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/tipsy.css" rel="stylesheet" type="text/css" media="all"/>
<link href="js/visualize/visualize.css" rel="stylesheet" type="text/css" media="all"/>
<link href="js/jwysiwyg/jquery.wysiwyg.css" rel="stylesheet" type="text/css" media="all"/>
<link href="js/fancybox/jquery.fancybox-1.3.0.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/tipsy.css" rel="stylesheet" type="text/css" media="all"/>
 
<!--[if IE]>
	<link href="css/ie.css" rel="stylesheet" type="text/css" media="all">
	<script type="text/javascript" src="js/excanvas.js"></script>
<![endif]-->
 
<!-- Jquery and plugins -->
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/jquery-ui.js"></script>
<script type="text/javascript" src="js/jquery.img.preload.js"></script>
<script type="text/javascript" src="js/hint.js"></script>
<script type="text/javascript" src="js/visualize/jquery.visualize.js"></script>
<script type="text/javascript" src="js/jwysiwyg/jquery.wysiwyg.js"></script>
<script type="text/javascript" src="js/fancybox/jquery.fancybox-1.3.0.js"></script>
<script type="text/javascript" src="js/jquery.tipsy.js"></script>
<script type="text/javascript" src="js/custom_blue.js"></script>
    <style type="text/css">
        .style1
        {
            height: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- Begin footer -->
<div id="footer">
	        <asp:Button ID="Btnañadir" class='btn btnadd' runat="server" Text="  Añadir" 
                Height="26px" Font-Size="Small"/>
            <asp:Button ID="btngrabar" class='btn btnonuser' runat="server" Text="  Grabar" 
                EnableTheming="True" Height="26px" Font-Size="Small" />
            <asp:Button ID="btnactualizar" class='btn btnapply' runat="server" 
                Text="  Aplicar modificaciones" EnableTheming="True" Height="26px" Font-Size="Small"/>
             <asp:Button ID="btneliminar"  class="btn btndelete" runat="server" 
                text="  Eliminar" Height="26px" Font-Size="Small"/>
			<asp:Button ID="btnbuscar" class='btn btnfind' runat="server" text="  Buscar" 
                Height="26px" Font-Size="Small"/>
                           <asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
 		</div>
		<!-- End footer -->
        
  <div class="content">
      <asp:Panel ID="PanelWarning" runat="server" Visible="False">
      
						<div class="alert_warning" style="margin-top:0">
							<p>
								<img src="images/icon_warning.png" alt="success" class="mid_align"/>
                                Warning Notification.<asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Button ID="Btnsi" runat="server" Text="Aceptar" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Btnno" runat="server" Text="Cancelar" />
							</p>
						</div>
       </asp:Panel>
       <asp:Panel ID="PanelInfo" runat="server" Visible="False">
						<div class="alert_info">
							<p>
								<img src="images/icon_info.png" alt="success" class="mid_align"/>
								Information Notification.<asp:Label ID="LblInfo" runat="server" Text=""></asp:Label>
							</p>
						</div>
        </asp:Panel>
        <asp:Panel ID="PanelSucces" runat="server" Visible="False">
						<div class="alert_success">
							<p>
								<img src="images/icon_accept.png" alt="success" class="mid_align"/>
								Success Notification.<asp:Label ID="LblSucces" runat="server" Text=""></asp:Label>
							</p>
						</div>
        </asp:Panel>
        <asp:Panel ID="PanelErros" runat="server" Visible="False">
						<div class="alert_error">
							<p>
								<img src="images/icon_error.png" alt="delete" class="mid_align"/>
								Error Notification.<asp:Label ID="LblError" runat="server" Text=""></asp:Label>
							</p>
						</div>
        </asp:Panel>
                        	</div>
  <!-- Begin one column window -->
  <div class="onecolumn">
    <div class="header"> <span>Demo de Mantenimiento </span> </div>
    <br class="clear"/>
    <div class="content">
      </div>
      <asp:Panel ID="Paneltabla" runat="server">
      
        <table class="data" width="100%"  border="1">
                         <tr>
                           <th>Dni:</th>
                           <td width="2000">
                           <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                           </td>
                         </tr>
                         <tr>
                           <th class="style1">Apellido Paterno</th>
                           <td width="2000">
                               <asp:TextBox ID="txtPaterno" runat="server"></asp:TextBox>
                             </td>
                         </tr>
                           <tr>
                           <th class="style1">Apellido Materno</th>
                           <td width="2000" id="Td1">
                               <asp:TextBox ID="TxtMaterno" runat="server"></asp:TextBox>
                             </td>
                         </tr>
                           <tr>
                           <th class="style1">Nombres</th>
                           <td width="2000" id="Td2">
                               <asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
                             </td>
                         </tr>
                          <tr>
                           <th class="style1">Departamento:</th>
                           <td width="2000">
                               <asp:DropDownList ID="cmbdepartamentos" runat="server" Width="119px" 
                                   DataSourceID="SqlDataSourceXEFredy" DataTextField="DEPARTAMENTOSNOMBRE" 
                                   DataValueField="DEPARTAMENTOSCODIGO" AutoPostBack="True">
                                   <asp:ListItem>[.:Seleccionar:.]</asp:ListItem>
                               </asp:DropDownList>
                               <asp:SqlDataSource ID="SqlDataSourceXEFredy" runat="server" 
                                   ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                   ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                   SelectCommand="SELECT DEPARTAMENTOSCODIGO, DEPARTAMENTOSNOMBRE FROM DEPARTAMENTOS">
                               </asp:SqlDataSource>
                             </td>
                           </tr>
                            <tr>
                           <th class="style1">Provincia:</th>
                           <td width="2000">
                               <asp:DropDownList ID="cmbprovincia" runat="server" Width="119px" 
                                   AutoPostBack="True">
                                   <asp:ListItem>[.:Seleccionar:.]</asp:ListItem>
                               </asp:DropDownList>
                             </td>
                           </tr>
                            <tr>
                           <th class="style1">Distrito:</th>
                           <td width="2000">
                               <asp:DropDownList ID="cmbdistritos" runat="server" Width="119px" 
                                   AutoPostBack="True">
                                   <asp:ListItem>[.:Seleccionar:.]</asp:ListItem>
                               </asp:DropDownList>
                             </td>
                           </tr>

                         <tr>
                           <th class="style1">Direccion:<br />
                             </th>
                           <td width="2000">
                               <asp:TextBox ID="txtDireccion" runat="server" Height="20px" Width="362px"></asp:TextBox>
                             </td>
                         </tr>
                  </table>
                  </asp:Panel>
      <!--                  
		-->
      <!-- End bar chart table-->
      
      
    </div>
    
  </div>
 <!-- Begin one column window -->
			<div class="onecolumn">
				<div class="header">
					<span>Lista de datos</span>
				</div>
				<br class="clear"/>
				<div class="content">
					<!-- End bar chart table-->
					
					<!-- Begin pagination -->
					<!-- End pagination -->
					
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
					
				</div>
			</div>
			</form>
			<!-- End one column window -->
</div>
</form>
</body>
</html>    

