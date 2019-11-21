<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="System.Data" %>

<script runat="server" language="VB">
	Sub Application_Start(sender As Object, e As EventArgs)

		'Dim SolrConn As New SolrNet.Impl.SolrConnection(SolrBaseURL)

		SolrNet.Startup.Init(Of SolrNet.Impl.ISolrHeaderResponseParser)(SolrBaseURL)
		SolrNet.Startup.Init(Of SolrNet.Impl.ISolrStatusResponseParser)(SolrBaseURL)

		SolrNet.Startup.Init(Of MyAddressBookEntry)(SolrABURL)
		'SolrNet.Startup.Init(Of SolrNet.ISolrOperations(Of MyAddressBookEntry))(SolrABURL)

		'SolrNet.Startup.Init(Of MyAddressBookEntry)(SolrABURL)
		'SolrNet.Startup.Init(Of SolrNet.ISolrOperations(Of MyAddressBookEntry))(SolrABURL)
	End Sub
</script>