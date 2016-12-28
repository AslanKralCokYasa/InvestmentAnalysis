<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/InvestmentAnalysisMasterPage.Master" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="WebPresentation.Transactions.PortfolioManagement.Portfolio1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .detail .right
        {
            margin: 6px 0 0 125px !important;
        }
        .detail .row
        {
            min-height: 21px;
        }
        .actionButtons
        {
            margin-bottom: 20px;
        }
        button.blue
        {
            width: 120px;
        }

        #wrapper #container #left {

            margin-left: 0px;
        }
    </style>
    <%-- <script src="../../Content/Js/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section">
        <div class="box">
            <div class="title">
                Portfolio Listesi <span class="hide"></span>
            </div>

            <div runat="server" class="content" id="contentOrgList">
                <asp:GridView ID="portfolioListGridView" runat="server" AutoGenerateColumns="False"
                    CellPadding="0" BorderStyle="None" BorderWidth="0px" OnRowCancelingEdit="portfolioListGridView_RowCancelingEdit"
                    OnRowDeleting="portfolioListGridView_RowDeleting" OnRowEditing="portfolioListGridView_RowEditing"
                    OnRowUpdating="portfolioListGridView_RowUpdating">
                    <Columns>
                      <%--  <asp:BoundField DataField="OrganizationName" HeaderText="Organizasyon İsmi" />
                        <asp:BoundField DataField="SignBoardName" HeaderText="Tabela İsmi" />
                        <asp:BoundField DataField="DescriptiveName" HeaderText="Tanımlayıcı İsmi" />
                        <asp:BoundField DataField="FoundationDate" HeaderText="Kuruluş Tarihi" DataFormatString="{0:d}" />
                        <asp:CommandField CausesValidation="false" ShowCancelButton="true" CancelText="Iptal"
                            ShowDeleteButton="true" DeleteText="Sil" ShowEditButton="true" EditText="Düzenle"
                            UpdateText="Kaydet" />--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
  <%--  <div id="NewRecordPanel" class="section detail">
        <div class="box">
            <div class="title">
                Yeni Organizasyon Ekleme <span class="hide"></span>
            </div>
            <div id="addNewRecordContent" class="content" runat="server">
                <div class="row">
                    <label>
                        Organizasyon İsmi</label>
                    <div class="right">
                        <input type="text" runat="server" id="newOrganizationNameText" maxlength="50" class="{validate:{required:true, messages:{required:'Organizasyon İsmi Girilmesi Zorunlu'}}}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="newOrganizationNameText"
                            runat="server" />
                    </div>
                </div>
                <div class="row">
                    <label>
                        Tabela İsmi</label>
                    <div class="right">
                        <input type="text" runat="server" id="newSignBoardNameText" maxlength="50" class="{validate:{required:true, messages:{required:'Tabela İsmi Girilmesi Zorunlu'}}}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="newSignBoardNameText"
                            runat="server" />
                    </div>
                </div>
                <div class="row">
                    <label>
                        Tanımlayıcı İsmi</label>
                    <div class="right">
                        <input type="text" runat="server" id="newDescriptiveNameText" maxlength="50" class="{validate:{required:true, messages:{required:'Tanımlayıcı İsim Girilmesi Zorunlu'}}}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="newDescriptiveNameText"
                            runat="server" />
                    </div>
                </div>
                <div class="row">
                    <label>
                        Kuruluş Tarihi</label>
                    <div class="right">
                        <input type="text" runat="server" id="newFoundationDateText" maxlength="10" onkeydown="return false;"
                            class="datepicker" />
                    </div>
                </div>
                <div class="row">
                    <div class="right">
                        <div class="actionButtons">
                            <button id="AddButton" runat="server" class="blue" onserverclick="addButton_ServerClick">
                                <span>Kaydet</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <script type="text/javascript">
        $(document).ready(function () {
<%--            var gridID = '<%= portfolioListGridView.ClientID %>';
            $('#' + gridID + '>tbody>tr>td:nth-child(4)').find('input').keydown(function () {
                return false;
            });
            $('#' + gridID + '>tbody>tr>td:nth-child(4)').find('input').addClass('firatCustomDatePicker');
            $(".firatCustomDatePicker").datepicker({
                dateFormat: 'dd.mm.yy'
            });--%>
        });
    </script>
</asp:Content>