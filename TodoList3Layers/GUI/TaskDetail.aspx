<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDetail.aspx.cs" Inherits="TodoList3Layers.GUI.TaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .input-form {
            outline: none;
            border: none;
            border-bottom: 2px solid #61b751;
            height: 32px;
            padding-bottom: 5px;
            display: initial !important;
        }
        .list-checkbox {
            height: 100px;
            width: 250px;
            overflow-y: auto;        
            border: none;
            outline: none;
        } 
       /*.list-checkbox option {
            padding-top: 3px;
        }*/
        .btn-success {
            padding: 10px;
            width: 60%;
            font-size: 18px;
            font-weight: bolder;
        }
        .btn-dark {
            padding: 10px;
            width: 60%;
            font-size: 18px;
            background-color: #585f63;
            color: white;
        }
        .btn-dark:hover {
            color: lime;
            opacity: 0.9;
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
        .cmt-box {
            padding: 5px;   
            width: 85%;
            max-width: 100%;
            outline-color: #61b751;
            resize: none;
        }
        .cmt-frame {
            padding: 10px;
            border: 1px solid green; 
            box-shadow: 2px 2px 3px darkgreen;
        }
        .btn-cmt {
            padding: 10px 20px;
            width: 15%;
            font-size: 16px;
            font-weight: bold;
        }
    </style>
    <div class="row">
        <div class="col-md-6">
            <div class="row" style="padding-top: 20px">
                <div class="col-md text-center header text-uppercase">
                    <h3 style="font-weight: bolder; color: white;"><asp:Label ID="labelTitle" runat="server" Text="[Tên công việc]"></asp:Label></h3>
                </div>
            </div>
            <div class="body">
                <div class="row"> 
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label1" runat="server" Text="Ngày bắt đầu"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:Label CssClass="input-form" Width="60%" ID="lblStartDate" runat="server" Text="xx/xx/xxxx"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label2" runat="server" Text="Ngày kết thúc"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:Label CssClass="input-form" Width="60%" ID="lblEndDate" runat="server" Text="xx/xx/xxxx"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label4" runat="server" Text="Quyền riêng tư"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:Label CssClass="input-form" ID="lblPrivacy" Width="30%" runat="server" Text="[Public/Private]"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label7" runat="server" Text="Trạng thái"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:Label CssClass="input-form" Width="45%" ID="lblStatus" runat="server" Text="xxxxxxxxx"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label5" runat="server" Text="Người làm chung"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:ListBox CssClass="list-checkbox" ID="ListPartners" runat="server">
                            <asp:ListItem Text="Người 1"></asp:ListItem>
                            <asp:ListItem Text="Người 2"></asp:ListItem>
                        </asp:ListBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-right text-bold">
                        <asp:Label ID="Label3" runat="server" Text="Tên tập tin đính kèm"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:ListBox CssClass="list-checkbox" ID="FileName" runat="server">
                            <asp:ListItem Text="Tập tin 1"></asp:ListItem>
                            <asp:ListItem Text="Tập tin 2"></asp:ListItem>
                        </asp:ListBox>
                    </div>
                </div>
                <div class="row" style="padding-top: 50px">
                    <div class="col-md-6 text-right">
                        <asp:Button CssClass="btn btn-success rounded-sm" ID="btnEdit" runat="server" Text="Sửa thông tin"  OnClick="Edit_Btn"/>
                    </div>
                    <div class="col-md-6 text-left">
                        <asp:Button CssClass="btn btn-dark rounded-sm" ID="btnBack" runat="server" Text="Quay về" OnClick="GoBack_Btn"/>
                    </div>
                </div>
            </div>
            <!--
            <div class="row">
                <div class="col-md text-center">
                    <hr style="border: 2px solid gray" />
                </div>
            </div>            
            -->
        </div>
        <div class="col-md-1"></div>
        <div class="col-md-5">
            <div class="row" style="padding-top: 20px;">
                <div class="col-md">
                    <h4 class="text-uppercase text-bold"><asp:Label ID="Label6" runat="server" Text="Bình luận"></asp:Label></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md" style="display: flex;">                   
                        <asp:TextBox Rows="3" Columns="100" CssClass="cmt-box" placeholder="Bình luận ở đây..........." ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>

                        <asp:Button CssClass="btn-cmt" ID="btnSubmitCmt" runat="server" Text="Gửi"  OnClick="Comment_Btn"/>
                </div>
            </div>
            <hr style="border: 1px solid #568946" />
            
            <div class="row">                
                <div class="col-md">
                    <h4 class="text-uppercase text-bold" style="margin-bottom: 0"><asp:Label runat="server" Text="Mới nhất"></asp:Label></h4>
                </div>    

                <div style="overflow-y: auto; margin-top: 10px; overflow-y: auto; height: 350px">
                <!-- Bình luận giả -->
                    <!--<div class="col-md" style="padding: 10px 0 5px 0">
                        <div class="cmt-frame">
                            <b><asp:Label Width="100%" runat="server" Text="Jason P"></asp:Label></b>
                            <asp:Label Width="100%" runat="server" Text="This is the first comment This is the first comment This is the first comment \n This is the first commentThis is the first commentThis is the first commentThis is the first commentThis is the first commentThis is the first commentThis is the first comment"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md" style="padding: 10px 0 5px 0">
                        <div class="cmt-frame">
                            <b><asp:Label Width="100%" runat="server" Text="Jason P"></asp:Label></b>
                            <asp:Label Width="100%" runat="server" Text="This is the first comment "></asp:Label>
                        </div>
                    </div>
                    <div class="col-md" style="padding: 10px 0 5px 0">
                        <div class="cmt-frame">
                            <b><asp:Label Width="100%" runat="server" Text="Tác giả"></asp:Label></b>
                            <asp:Label Width="100%" runat="server" Text="Cứu tôi chán quá àaaaaaaaaaaaaaaaa ai đó hãy giải thoát cho tôi đi :("></asp:Label>
                        </div>
                    </div>-->
                <!----------------->

                <!-- Hiển thị các bình luận -->
                    <asp:Repeater ID="RptCmt" runat="server">
                        <ItemTemplate>
                            <div class="col-md" style="padding: 10px 0">
                                <div class="cmt-frame">
                                    <b><asp:Label Width="100%" runat="server" Text='<%#Eval("hoten") %>'>'></asp:Label></b>
                                    <asp:Label Width="100%" runat="server" Text='<%#Eval("binhluan") %>'></asp:Label><br />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                <!--------------------------->
                </div>
            </div>
        </div> 
    </div>
</asp:Content>
