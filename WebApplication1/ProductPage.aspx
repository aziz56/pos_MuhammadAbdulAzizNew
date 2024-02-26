<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductPage.aspx.vb" Inherits="WebApplication1.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Products</h1>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">About Page</h6>
                </div>
                <div class="card-body">

                    <asp:DropDownList ID="ddHobby" runat="server"></asp:DropDownList><br />
                    <asp:Label ID="lblHobby" runat="server" /><br />
                    <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" runat="server" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>

        <div class="col-lg-12">
            <!-- Basic Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">About Page</h6>
                </div>
                <div class="card-body">
                    <asp:SqlDataSource runat="server"
                        ConnectionString="<%$ ConnectionStrings:pos_restoConnectionString %>"
                        SelectCommand="SELECT * FROM [MasterPelanggan] WHERE ([NamaPelanggan] LIKE '%' + @SearchTerm + '%')"
                        ID="aziz">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSearch" Name="SearchTerm" PropertyName="Text" Type="String" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:TextBox runat="server" ID="txtSearch" />
                    <asp:Button runat="server" Text="Search" OnClick="btnSearch_Click" />

                    <asp:GridView DataSourceID="aziz" runat="server" AutoGenerateColumns="True" DataKeyNames="id_pelanggan" ID="ctl14">
                    </asp:GridView>
                     

                </div>
            </div>
        </div>


    </div>
</asp:Content>
