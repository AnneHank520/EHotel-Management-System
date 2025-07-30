<%@ Page Title="" Language="C#" MasterPageFile="~/View/Users/UserMaster.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="EHotel_project.View.Users.Booking" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <div class="mb-3">
                                    <label for="RNameTb" class="form-label">Room Name</label>
                                    <input type="text" class="form-control" id="RNameTb" runat="server"/>
                                </div>
                                <div class="mb-3">
                                    <label for="CheckinTb" class="form-label">Check-in</label>
                                    <input type="date" class="form-control" id="CheckinTb" runat="server"/>
                                </div>
                            </div>
                            <div class="col">
                                <div class="mb-3">
                                    <label for="CheckoutTb" class="form-label">Check-out</label>
                                    <input type="date" class="form-control" id="CheckoutTb" runat="server"/>
                                </div>
                                <div class="mb-3">
                                    <label for="PriceTb" class="form-label">Price</label>
                                    <input type="text" class="form-control" id="PriceTb" runat="server"/>
                                </div>
                            </div>
                        </div>
                                               
                        <div class="row">
                            <div class="col">
                                <div>
                                    <label id="ErrMsg" runat="server" class="text-danger"></label>
                                    <asp:Button ID="BookBtn" runat="server" Text="BOOK" class="btn btn-warning" OnClick="BookBtn_Click"/>
                                    <asp:Button ID="ResetBtn" runat="server" Text="RESET" class="btn btn-danger"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3 class="text-primary">Room Available</h3>
                <asp:GridView ID="RoomsGV" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="RoomsGV_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
            <div class="col">
                <div class="row">
                    <div class="col"></div>
                    <div class="col"><h2 class="text-primary">Room Order Settlement</h2></div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="BookingGV" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
