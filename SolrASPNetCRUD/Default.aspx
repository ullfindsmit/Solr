<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="SolrASPNetCRUD._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
			<div class="col-12">
				<div class="alert alert-danger">
					<asp:Literal ID="litError" runat="server" />
				</div>
			</div>
			<div class="col-6">
				<table>
					<thead>
						<tr>
							<th>
								DATA
							</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td>
								TBD
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div class="col-6">
				<div class="well well-sm">
					<legend>
						Add
					</legend>
					
					<asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" />
					<br />
					<asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" />
					<br />
					<asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" />
					<br />
					<asp:TextBox ID="txtEmail" runat="server" placeholder="Email" />
					<br />
					<asp:Button ID="btnSave" runat="server" Text="Save" />
					<br />

				</div>
			</div>
        </div>
    </form>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
