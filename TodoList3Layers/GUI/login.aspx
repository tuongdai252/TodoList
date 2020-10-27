<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TodoList3Layers.GUI.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .input-form {
            width: 80%;
            outline: none;
            border: none;
            border-bottom: 2px solid #61b751;
            font-size: 16px;
        }
        .btn-success {
            padding: 15px;
            width: 60%;
        }
        .error-message {
            color: red;
            font-size: 16px;
            font-weight: bold;
        }
    </style>
    <script>
        $(document).ready(function () {
            $(".navbar").hide();
            $("footer").hide();
        });
    </script>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6" style="padding: 50px">
            <div class="row">
                <div class="col-md-12 text-center" style="background-color: #61b751; padding: 15px 0; border-radius: 20px 20px 0 0; border: 1px solid green">
                    <h3 class="text-uppercase" style="color: white;">Đăng nhập</h3>
                </div>
            </div>
            <div style="margin: 0 -15px; border: 1px solid green; border-top: none">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
                <div class="row" style="padding: 35px 0 20px 0;">
                    <div class="col-md-6 text-right" style="padding-right: 30px; font-weight: bold;">
                        <asp:Label ID="Label1" runat="server" Text="Email" Style="font-size: large"></asp:Label>
                    </div>
                    <div class="col-md-6" style="padding-left: 0">
                        <asp:TextBox CssClass="input-form" ID="txtEmail" placeholder="Example@example.com" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding: 20px 0">
                    <div class="col-md-6 text-right" style="padding-right: 30px; font-weight: bold;">
                        <asp:Label ID="Label2" runat="server" Text="Password" Style="font-size: large"></asp:Label>
                    </div>
                    <div class="col-md-6" style="padding-left: 0">
                        <asp:TextBox CssClass="input-form" ID="txtPassword" placeholder="***************" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="padding: 20px 0">
                    <div class="text-center error-message">
                        <asp:Literal  ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 20px">
                    <div class="col-md-12 text-center">
                        <asp:Button CssClass="btn btn-success" ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="LoginButton_Click" Style="font-size: large" />
                    </div>
                </div>
                </asp:Panel>
            </div>
        </div>

        <div class="col-md-3"></div>        
    </div>
</asp:Content>
