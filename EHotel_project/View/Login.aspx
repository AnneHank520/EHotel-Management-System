<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EHotel_project.View.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../Assets/Libraries/Bootstrap/css/bootstrap.min.css" />
    <style>
        body {
            background-image:url(../Assets/Images/hotel0.jpg);
            background-size:cover;        
        }
        .container-fluid {
            opacity:0.95;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row" style="height:200px;"></div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4 bg-light rounded-2">
                        <h1 class="text-success text-center">Royal Holiday Hotel</h1>

                        <form>
                            <div class="mb-3">
                                <label for="UserTb" class="form-label">User Name</label>
                                <input type="text" class="form-control" id="UserTb" runat="server" required="required"/>
                            </div>
                            <div class="mb-3">
                                <label for="PasswordTb" class="form-label">Password</label>
                                <input type="password" class="form-control" id="PasswordTb" runat="server" required="required"/>
                            </div>
                            <div class="mb-3">
                                <label id="ErrMsg" class="text-danger" runat="server"></label>
                                <input type="radio" id="AdminCb" runat="server" name="Role"/><label class="text-success">Administrator</label>
                                <input type="radio" id="UserCb" runat="server" name="Role"/><label class="text-success">User</label>
                            </div>
                                <div class="d-grid">
                                    <asp:Button ID="LoginBtn" runat="server" Text="Log in" class="btn btn-success btn-block" OnClick="LoginBtn_Click"/>
                                </div>

                                <br />
                 
                        </form>

                </div>
                <div class="col-md-4"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
