<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soal_Binus.aspx.cs" Inherits="WebApplication1.Soal_Binus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Form</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table>
                <tr>
                   <td style="left: 10px; width: 120px">No Invoice :</td>
                   <td style="left: 60px; width: 30px">
                       <asp:TextBox ID="textNoInvoice" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                   </td>
                   <td style="left: 120px; width: 30px">
                       <asp:Button ID="btnView" runat="server" Text="View" Width="100px" CssClass="form-control" OnClick="btnView_Click" />
                   </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Invoice</td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">No Date :</td>
                   <td style="left: 60px; width: 30px">
                       <asp:TextBox ID="textInvoiceDate" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                   </td>
                   <td style="left: 120px; width: 100px">Ship To :</td>
                   <td style="left: 170px; width: 30px">
                       <asp:TextBox ID="textShipTo" runat="server" Height="200px" Width="200px" CssClass="form-control"></asp:TextBox>
                       <%--<asp:Label ID="labelShipTo" runat="server" Width="200px" CssClass="form-control"></asp:Label>--%>
                   </td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">To :</td>
                   <td style="left: 60px; width: 30px">
                       <asp:TextBox ID="textTo" runat="server" Height="200px" Width="200px" CssClass="form-control"></asp:TextBox>
                   </td>
                   <td style="left: 120px; width: 100px">Payment Type :</td>
                   <td style="left: 170px; width: 30px">
                       <asp:DropDownList ID="ddPaymentType" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList>
                   </td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">Sales Name :</td>
                   <td style="left: 60px; width: 30px">
                       <asp:DropDownList ID="ddSalesName" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList>
                   </td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">Courier :</td>
                   <td style="left: 60px; width: 30px">
                       <asp:DropDownList ID="ddCourier" runat="server" Width="200px" CssClass="form-control"></asp:DropDownList>
                   </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="GridResult" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText ="Item"/>
                    <asp:BoundField DataField="WeightKg" HeaderText ="Weight(kg)"/>
                    <asp:BoundField DataField="Qty" HeaderText ="Qty)"/>
                    <asp:BoundField DataField="Price" HeaderText ="Unit Price"/>
                    <asp:BoundField DataField="Total" HeaderText ="Total"/>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                   <td style="left: 10px; width: 120px">Sub Total</td>
                   <td style="left: 60px; width: 30px">
                       <asp:Label ID="lblSubTotal" Width="200px" runat="server" CssClass="form-control"></asp:Label>
                   </td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">Courier Fee</td>
                   <td style="left: 60px; width: 30px">
                       <asp:Label ID="lblCourierFee" Width="200px" runat="server" CssClass="form-control"></asp:Label>
                   </td>
                </tr>
                <tr>
                   <td style="left: 10px; width: 120px">Total</td>
                   <td style="left: 60px; width: 30px">
                       <asp:Label ID="lblTotal" Width="200px" runat="server" CssClass="form-control"></asp:Label>
                   </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="left: 10px; width: 120px"></td>
                    <td>
                       <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" CssClass="btn btn-md btn-default" OnClick="btnSave_Click" />
                    </td>
               </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
