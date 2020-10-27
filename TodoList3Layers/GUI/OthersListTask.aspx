<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OthersListTask.aspx.cs" Inherits="TodoList3Layers.GUI.OthersListTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {
            padding: 20px 0;
        }
        .row-title {
            color: green;
            font-size: 22px;
            font-weight: bolder;
            border-bottom: 2px solid #61b751;
            padding-bottom: 0;
        }
         td {
            text-align: center;
            padding: 12px 0px 12px 0px;
        } 

        th {
            text-align: center;
            padding: 15px 0px 15px 0px;
        }

         #gridtask {         
            border-radius: 5px;
            overflow: hidden;          
        }

         .btn-select input[type=button] {
            border: none;
            background-color: #008CBA;
            padding: 8px;
            border-radius: 5px;
            color: white;
        }

         .btn-select input[type=button]:hover {
            border: none;
            background-color: #24728c;
            padding: 8px;
            border-radius: 5px;
            color: white;
        }

    </style>
    <div class="row row-title">
        <span>Danh sách nhân viên</span>
    </div>
    <div class="row" id="gridtask">
        <asp:GridView ID="gridListEmp" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
            DataKeyNames="manv" AutoGenerateColumns="true" OnRowDataBound="gridListTask_RowDataBound" OnSelectedIndexChanged="Select_Btn" Width="100%">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#5CB85C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Xem" ItemStyle-CssClass="btn-select"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
