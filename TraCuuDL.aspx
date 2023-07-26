<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TraCuuDL.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" TagPrefix="asp"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>TRA CỨU GIÁ TRỊ CẢM BIẾN</title>
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
.text-input {
    width: 30%;
    margin: 0 auto;
    padding: 10px;
    font-size: 16px;
}
.btn-submit {
        width: 10%;
        margin: 0 auto;
        padding: 10px;
        font-size: 16px;
    }
.form-container {
        display: flex;
        justify-content: flex-end;
        margin-right: auto;
}

</style>
    <link rel="stylesheet" href="Styles/TemPlate.css"/>
    <link rel="stylesheet" href="Styles/FA_THEMES.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID ="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
        <div>
            <header class="w3-container w3-center w3-padding-32"> 
        <h1><b>TRA CỨU DỮ LIỆU CẢM BIẾN</b></h1>
        </header>
            <h2></h2>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-container">
                          <asp:TextBox ID="txbName" runat="server" class="text-input" placeholder="Tên"></asp:TextBox>
                          <asp:TextBox ID="txbStartTime" runat="server" class="text-input" placeholder="Thời gian bắt đầu"></asp:TextBox>
                          <asp:TextBox ID="txbEndTime" runat="server" class="text-input" placeholder="Thời gian kết thúc"></asp:TextBox>
                          <asp:Button ID="btn" runat="server" Text="Xem Giá Trị" OnClick="btn_Click" class="btn-submit" />
                        </div>

                        <div class="result-container">
                          <asp:Literal ID="Literal_HienThiGiaTriCB" runat="server"></asp:Literal>
                        </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
