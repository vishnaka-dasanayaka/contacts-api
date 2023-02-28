using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using contacts_API.Data;
using contacts_API.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contacts_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {

        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }
    }
}

