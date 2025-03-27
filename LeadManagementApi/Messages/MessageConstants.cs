namespace LeadManagementApi.Messages
{
	public static class MessageConstants
	{
		#region Response Messages
		public const string LeadAccepted = "Lead has been accepted.";
		public const string LeadDeclined = "Lead has been declined.";
		public const string OnlyNewLeadsCanBeAccepted = "Only leads with status 'New' can be accepted.";
		public const string OnlyNewLeadsCanBeDeclined = "Only leads with status 'New' can be declined.";
		public const string InternalError = "An internal error occurred.";
		public const string NoLeads = "No leads found.";
		public const string AllLeadsGet = "All leads have been retrieved.";
		#endregion

		#region Log Messages
		public const string GetLeads = "Getting all leads.";
		public const string AcceptLead = "Accepting lead.";
		public const string DeclineLead = "Declining lead.";
		public const string AnUnexpectedErrorOccurred = "An unexpected error occurred: @{Mensagem}. StackTrace: @{StackTrace}. Origem: @{Origem}. Método: @{Método}";
		#endregion

		#region Exception Messages
		public const string ConnectionStringNotConfigured = "Connection string from @{TypeDataBase} is not configured.";
		#endregion
	}
}
