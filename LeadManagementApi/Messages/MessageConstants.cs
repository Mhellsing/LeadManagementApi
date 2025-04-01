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
		public const string AllLeadsWithNewStatusGet = "All leads with 'New' status have been retrieved.";
		public const string AllLeadsWithAcceptedStatusGet = "All leads with 'Accepted' status have been retrieved.";
		public const string LeadIdMustBeGreaterThanZero = "Lead ID must be greater than zero.";
		public const string LeadAcceptanceFailed = "Lead acceptance failed.";
		public const string LeadDeclineFailed = "Lead decline failed.";
		public const string WrongStatusToAcceptOrDecline = "Only leads with status 'New' can be accepted or declined.";
		#endregion

		#region Log Messages
		public const string InitiatingProcessToGetAllLeadsWithStatusNew = "Initiating process to getting all leads with status: New.";
		public const string FinishingProcessToGetAllLeadsWithStatusNew = "Finishing process to getting all leads with status: New.";
		public const string InitiatingAcceptLeadProcess = "Initiating the lead acceptance process.";
		public const string FinishingLeadAcceptProcess = "Finishing the lead acceptance process.";
		public const string InitiatingDeclineLeadProcess = "Initiating the lead rejection process.";
		public const string FinishingLeadDeclineProcess = "Finishing the lead rejection process.";
		public const string AnUnexpectedErrorOccurred = "An unexpected error occurred: @{Mensagem}. StackTrace: @{StackTrace}. Origem: @{Origem}. Método: @{Método}";
		#endregion

		#region Exception Messages
		public const string ConnectionStringNotConfigured = "Connection string from {TypeDataBase} is not configured.";
		#endregion
	}
}
