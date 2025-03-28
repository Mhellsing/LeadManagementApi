using LeadManagementApi.Enums;
using LeadManagementApi.Messages;

namespace LeadManagementApi.Models
{
	public class Lead
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateCreated { get; set; }
		public string Suburb { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public LeadStatus Status { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Lead(string firstName, string lastName, DateTime dateCreated, string suburb, string category, string description, double price, string email, string phoneNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			DateCreated = dateCreated;
			Suburb = suburb;
			Category = category;
			Description = description;
			Price = price;
			Status = LeadStatus.New;
			Email = email;
			PhoneNumber = phoneNumber;
		}

		public void Accept()
		{
			if (Status != LeadStatus.New)
			{
				throw new InvalidOperationException(MessageConstants.OnlyNewLeadsCanBeAccepted);
			}

			if(Price > 500)
			{
				ApplyDiscount();
			}			

			Status = LeadStatus.Accepted;
		}

		public void Decline()
		{
			if (Status != LeadStatus.New)
			{
				throw new InvalidOperationException(MessageConstants.OnlyNewLeadsCanBeDeclined);
			}

			Status = LeadStatus.Declined;
		}

		private double ApplyDiscount()
		{
			return Price -= Price * 0.1;
		}
	}
}
