<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/GMPMasterPage.master"
    AutoEventWireup="true" CodeFile="Dealer.aspx.cs" Inherits="Transactions_DealerManagement_Dealer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="transactionPanel" runat="server">
        <div class="box">
            <div class="title">
                Bayi Listesi <span class="hide"></span>
            </div>
            <div class="content" id="contentDealerList" runat="server">
                <div id="organizationListPanel">
                    <select runat="server" id="organizationList" onchange="javascript:form.submit();"
                        onserverchange="organizationList_ServerChange">
                    </select>
                </div>
                <asp:GridView ID="dealerListGridView" runat="server" AutoGenerateColumns="False"
                    CellPadding="0" BorderStyle="None" BorderWidth="0px" DataKeyNames="ID" OnRowCancelingEdit="dealerListGridView_RowCancelingEdit"
                    OnRowDeleting="dealerListGridView_RowDeleting" OnRowEditing="dealerListGridView_RowEditing"
                    OnRowUpdating="dealerListGridView_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="LocationName" HeaderText="Yer" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Eklenme Tarihi" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="LocationAdress" HeaderText="Yer Adres" />
                        <asp:CheckBoxField DataField="IsActive" HeaderText="Aktif mi?" />
                        <asp:CommandField CausesValidation="false" ShowEditButton="true" EditText="Düzenle" UpdateText="Kaydet" ShowCancelButton="true"
                            CancelText="Iptal" ShowDeleteButton="true" DeleteText="Sil" />
                    </Columns>
                </asp:GridView>
            </div>
    </div>
    </div>
    <div id="newRecordPanel" runat="server">
        <div class="box">
            <div class="title">
                Yeni Bayi Ekleme <span class="hide"></span>
            </div>
            <div id="addNewRecordContent" class="content" runat="server">
                <div class="row">
                    <label>
                        Yer</label>
                    <div class="right">
                        <input type="text" runat="server" id="txtNewYer" maxlength="50" class="{validate:{required:true, messages:{required:'Yer İsmi Girilmesi Zorunlu'}}}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtNewYer"
                            runat="server" />
                    </div>
                </div>
                <div class="row">
                    <label>
                        Eklenme Tarihi</label>
                    <div class="right">
                        <input type="text" runat="server" id="txtNewEklenmeTarihi" maxlength="10" onkeydown="return false;"
                            class="datepicker" />
                    </div>
                </div>
                <div class="row">
                    <label>
                        Adres</label>
                    <div class="right">
                        <input type="text" runat="server" id="txtYerAdres" maxlength="50" class="{validate:{required:true, messages:{required:'Adres Girilmesi Zorunlu'}}}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtYerAdres"
                            runat="server" />
                    </div>
                </div>
                <div class="row">
                    <label style="margin-top:-8px;">
                        Aktif mi?</label>
                    <div class="right" id="test">
                        <input type="checkbox" runat="server" id="txtAktifMi" maxlength="50"  style="margin-left:-222px;" />
                    </div>
                </div>
                <div class="row">
                    <div class="right">
                        <div class="actionButtons">
                            <button id="btnEkle" runat="server" class="blue" onserverclick="btnEkle_ServerClick">
                                <span>Kaydet</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#test .custom-checkbox').removeClass('custom-checkbox');
            var gridID = '<%= dealerListGridView.ClientID %>';
            $('#' + gridID + '>tbody>tr>td:nth-child(2)').find('input').keydown(function () {
                return false;
            });
            $('#' + gridID + '>tbody>tr>td:nth-child(2)').find('input').addClass('firatCustomDatePicker');
            $(".firatCustomDatePicker").datepicker({
                dateFormat: 'dd.mm.yy'
            });
        });
    </script>
</asp:Content>
