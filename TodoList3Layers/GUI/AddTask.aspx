<%@ Page Title="Thêm công việc" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TodoList3Layers.GUI.AddTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .input-form {
            outline: none;
            border: none;
            border-bottom: 2px solid #61b751;
            height: 32px;
        }
        .list-checkbox {
            height: 100px;
            width: 250px;
            overflow-y: scroll;        
            padding-top: 5px;
        }        
        .list-checkbox label {
            padding-left: 5px;
            font-weight: normal;
        }
        .file-upload {
            height: 32px;
            padding-top: 5px;
        }
        .btn-success {
            padding: 10px;
            width: 60%;
            font-size: 18px;
            font-weight: bolder;
        }
        .btn-dark {
            padding: 5px;
            width: 30%;
            font-size: 16px;
            background-color: #585f63;
            color: white;
        }
        .btn-dark:hover {
            color: lime;
            opacity: 0.9;
        }
        .error-message {
            color: red;        
            font-weight: bold;
        }
        .header {
            background-color: #61b751; 
            padding: 15px 0; 
            border-radius: 20px 20px 0 0; 
            border: 1px solid green;
            
        }
        .body {
            border: 1px solid green;
            border-top: none;
            margin: 0 -15px;
            padding-bottom: 20px;
        }
        .body .row:first-child {
            padding-top: 20px;
        }
        .body .row {
            padding: 10px;
            font-size: 16px;
        }
        .text-bold {
            font-weight: bold;
        }
        .text-right {
            padding: 5px;
            top: 0px;
            left: 0px;
        }
    </style>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="row" style="padding-top: 20px;">
                <div class="col-md text-center header text-uppercase">
                    <h3 style="font-weight: bolder; color: white;">Thêm công việc</h3>
                </div>
            </div>
            <div class="body">
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label1" runat="server" Text="Tên công việc"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox CssClass="input-form" Width="80%" ID="txtTaskName" runat="server" placeholder="Điền tên công việc...."></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right"">
                        <asp:Label CssClass="text-bold" ID="Label2" runat="server" Text="Ngày bắt đầu"></asp:Label><br />
                        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-6" style="padding: 5px 15px;">
                        <asp:Label CssClass="text-bold" ID="Label3" runat="server" Text="Ngày kết thúc"></asp:Label><br />
                        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label4" runat="server" Text="Quyền riêng tư"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList CssClass="input-form" ID="choosePrivacy" runat="server">
                            <asp:ListItem Text="Công khai" Value="Công khai"></asp:ListItem>
                            <asp:ListItem Text="Chỉ 1 mình tôi" Value="Chỉ 1 mình tôi"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label5" runat="server" Text="Người làm chung"></asp:Label>
                    </div>
                    <div class="col-md-6 list-checkbox">
                        <asp:CheckBoxList ID="choosePartners" runat="server" OnSelectedIndexChanged="btnAddTask_Click">
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label6" runat="server" Text="Chọn tập đính kèm"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:FileUpload CssClass="file-upload" Width="250px" AllowMultiple="true" ID="FileUploadTask" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md text-center error-message">
                        <asp:Literal ID="txtFailure" runat="server" EnableViewState="false"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md text-center">
                        <asp:Button CssClass="btn btn-success rounded-sm" ID="btnAddTask" runat="server" Text="Tạo" OnClick="btnAddTask_Click" />
                    </div>
                </div>
                <div class="row" style="padding-top: 0">
                    <div class="col-md text-center">
                        <asp:Button CssClass="btn btn-dark rounded-sm" ID="btnCancel" runat="server" Text="Quay về" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    
</asp:Content>
