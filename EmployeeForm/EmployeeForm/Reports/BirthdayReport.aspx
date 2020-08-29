<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BirthdayReport.aspx.cs" Inherits="EmployeeForm.Reports.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 789px">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
    </form>
</body>
</html>
