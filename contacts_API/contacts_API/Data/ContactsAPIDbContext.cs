using Microsoft.EntityFrameworkCore;
using contacts_API.Models;
using System;

namespace contacts_API.Data
{
	public class ContactsAPIDbContext : DbContext
	{
		public ContactsAPIDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Contact> Contacts { get; set;}
    }
}

