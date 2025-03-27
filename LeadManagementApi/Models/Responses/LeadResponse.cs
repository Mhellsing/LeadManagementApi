using System.Net;

namespace LeadManagementApi.Models.Responses
{
	public class LeadResponse
	{
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public List<Lead> Leads { get; set; }

		public LeadResponse(string message, HttpStatusCode statusCode, List<Lead> leads)
		{
			Message = message;
			StatusCode = statusCode;
			Leads = leads;
		}
	}
}
