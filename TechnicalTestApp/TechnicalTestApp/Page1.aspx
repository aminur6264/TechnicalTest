<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="TechnicalTestApp.Page1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css">
    <link href="Content/timepicker.min.css" rel="stylesheet" />
    <div class="row">
        <asp:UpdatePanel ID="upSection1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="col-md-10 col-md-offset-1">
                    <div class="text-center" runat="server" id="divErrorMessage" visible="false">
                        <div class="alert alert-danger">
                            <asp:Label runat="server" ID="lblErrorMessage" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="text-center" runat="server" id="divSuccessMessage" visible="false">
                        <div class="alert alert-success">
                            <asp:Label runat="server" ID="lblSuccessMessage" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 col-md-offset-1 well">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon">Title</span>
                                <asp:TextBox ID="txtTitle" runat="server" placeholder="Title" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon">Title</span>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <div class="col-md-12">
                            <div class="input-group">
                                <span class="input-group-addon">Type</span>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AutoPostBack="true">
                                    <asp:ListItem Text="Select One" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="margin-top: 10px">
                        <div class="col-md-3">
                            <div class="input-group">
                                <span class="input-group-addon">Title</span>
                                <asp:TextBox ID="txtDate" runat="server" placeholder="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <span class="input-group-addon">Title</span>
                                <asp:TextBox ID="txtTime" runat="server" placeholder="Time" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon">Title</span>
                                <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 text-center">
                            <asp:Button runat="server" ID="btnAddToList" CssClass="btn btn-primary" OnClick="btnAddToList_Click" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div class="row"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="upSection2" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="col-md-10 col-md-offset-1">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-1 text-center">
                                    <button type="button" class="btn btn-success">?</button>
                                </div>
                                <div class="col-md-11">
                                    <asp:TextBox runat="server" ID="txtSearchBox" OnTextChanged="txtSearchBox_TextChanged" AutoPostBack="true" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView runat="server" ID="tblData" CssClass="table table-borderd table-hover table-striped" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="txtGridRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="btnGridRemove" CssClass="btn btn-danger" OnClick="btnGridRemove_Click" Text="Remove" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-md-10 col-md-offset-1">
                    <asp:Button runat="server" ID="btnSaveData" CssClass="btn btn-success pull-right" OnClick="btnSaveData_Click" Text="Submit" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script src="https://code.jquery.com/ui/1.13.0/jquery-ui.js"></script>
    <%--<script src="/path/to/cdn/jquery.slim.min.js"></script>--%>
    <%--<link rel="stylesheet" href="/path/to/dist/css/timepicker.min.css" />--%>
    <script src="Scripts/timepicker.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            ddlTypeAutocomplete();
            datePicker();
            timePicker();
        });
        var parameter = Sys.WebForms.PageRequestManager.getInstance();

        parameter.add_endRequest(function () {
            ddlTypeAutocomplete();
            datePicker();
            timePicker();
        });

        function ddlTypeAutocomplete() {
            $("#<%= ddlType.ClientID %>").select2({
                placeholder: "Select One"
            });
        }
        function datePicker() {
            $(function () {
                $("#<%= txtDate.ClientID %>").datepicker({
                    dateFormat: "MM dd, yy"
                });
            });
        }
        function timePicker() {
            $(function () {
                $("#<%= txtTime.ClientID %>").timepicker();
            });
        }

    </script>
</asp:Content>
