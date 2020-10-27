<%@ Page Title="Danh sách công việc" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoList3Layers._Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
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
        .search-text {
            font-size: 16px;
            height: 30px;
            max-width: 1000px;
            padding: 15px;
            vertical-align: middle;
        }
        .btn-success {
            font-size: 16px;
            border: 1px solid green;
        }
        .select-status {
            font-size: 16px;
        }
        .select-status > label {
            padding-left: 5px;
        }
        .select-status > input[type=radio] {
            margin: 0 0 5px;
        }
        .filter-active {
            font-size: 16px;
        }
        .filter-active span {
            font-weight: bold;
        }
        .filter-active input[type=submit] {
            height: 50px;
            padding: 0 25px;           
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

        .btn-edit input[type=button] {
            border: none;
            background-color: #e0a800;
            padding: 8px;
            border-radius: 5px;
            color: white;
        }

        .btn-delete input[type=button] {
            border: none;
            background-color: #dc3545;
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

        .btn-edit input[type=button]:hover {
            border: none;
            background-color: #b38c19;
            padding: 8px;
            border-radius: 5px;
            color: white;
        }

        .btn-delete input[type=button]:hover {
            border: none;
            background-color: #bd2d3b;
            padding: 8px;
            border-radius: 5px;
            color: white;
        }

    </style>
    <div class="row row-title">
        <div class="col-md">
            <asp:Label ID="Label4" runat="server" Text="Tìm kiếm"></asp:Label>
        </div>    
    </div>
    <div class="row">
        <div class="col-md" style="padding: 0 20px">
            <asp:TextBox CssClass="search-text" ID="txtSearch" runat="server" Width="500px" placeholder="Tìm kiếm ..." TextMode="Search"></asp:TextBox>
            <asp:Button CssClass="btn btn-success" ID="submitSearch" runat="server" Text="Tìm" OnClick="Search_Btn"/>
        </div>
    </div>
    <div class="row row-title">
        <div class="col-md">
            <asp:Label ID="Label1" runat="server" Text="Lọc công việc"></asp:Label>
        </div>    
    </div>
    <div class="row">
        <div class="col-md-3">
            <asp:RadioButton CssClass="select-status" ID="RadioBtnAll" runat="server" GroupName="TaskStatus" Text="Tất cả" AutoPostBack="true" />
        </div>
        <div class="col-md-3">
            <asp:RadioButton CssClass="select-status" ID="RadioBtnCompleted" runat="server" GroupName="TaskStatus" Text="Hoàn thành" AutoPostBack="true"/>
        </div>
        <div class="col-md-3">
            <asp:RadioButton CssClass="select-status" ID="RadioBtnPending" runat="server" GroupName="TaskStatus" Text="Đang làm" AutoPostBack="true" Checked="true"/>
        </div>
        <div class="col-md-3">
            <asp:RadioButton CssClass="select-status" ID="RadioBtnRejected" runat="server" GroupName="TaskStatus" Text="Trễ hạn" AutoPostBack="true" />
        </div>
    </div>
    <div class="row filter-active">
        <div class="col-md-3">
            <asp:Label ID="Label2" runat="server" Text="Ngày bắt đầu"></asp:Label><br />
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label3" runat="server" Text="Ngày kết thúc"></asp:Label><br />
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Lọc" OnClick="Filter_Btn"/>
        </div>
        <div class="col-md-3">
            <asp:Button CssClass="btn btn-warning" ID="btnAddTask" runat="server" Text="Thêm task" OnClick="AddTask_Btn"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center" style="font-size: 16px; color: red">
            <asp:Literal ID="txtFailure" runat="server" EnableViewState="false" Text=""></asp:Literal>
        </div>
    </div>
    <div class="row row-title">
        <div class="col-md">
            <asp:Label ID="Label5" runat="server" Text="Danh sách công việc"></asp:Label>
        </div>    
    </div>
    <div class="row">
        <div class="col-md" id="gridtask">
            <asp:GridView ID="gridListTask" runat="server"
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" ForeColor="black" GridLines="Vertical" Width="100%"
                DataKeyNames="macv" 
                AutoGenerateColumns="true" OnSelectedIndexChanged="Select_Btn" OnRowEditing="Edit_Btn" OnRowDeleting="Delete_Btn" OnRowDataBound="gridListTask_RowDataBound" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#5cb85c" Font-Bold="True" ForeColor="White"/>
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
                <Columns> 
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ItemStyle-CssClass="btn-select" SelectText="Xem"/>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" ItemStyle-CssClass="btn-edit" EditText="Sửa"/>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ItemStyle-CssClass="btn-delete" DeleteText="Xóa"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

