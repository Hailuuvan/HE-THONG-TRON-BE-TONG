<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CamBienCan.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" TagPrefix="asp"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BẢNG GIÁ TRỊ CẢM BIẾN CẠN</title>
<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}


table tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

table tbody tr:hover {
  background-color: #eaeaea;
}

table td {
  vertical-align: middle;
}

table .center {
  text-align: center;
}

table .right {
  text-align: right;
}

table .bold {
  font-weight: bold;
}

table .index {
  width: 20px;
  text-align: center;
}
h2 {
    text-align: center;
    color: blue;
  }
</style>

</head>

<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID ="ToolkitScriptManager1" runat="server">

        </asp:ToolkitScriptManager>
        <div>
            <h2>TẤT CẢ GIÁ TRỊ CẢM BIẾN CẠN</h2>
            <asp:Literal ID="Literal_TatCaGiaTriCB_LOW" runat="server"></asp:Literal>
        </div>
        
    </form>
</body>
</html>
