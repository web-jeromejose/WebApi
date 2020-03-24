using ExpensesAPI.Data;
using ExpensesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpensesAPI.Controllers
{

    // url of angular or the requestor url note: "/" in the string .  install web api cors dll in nuget
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EntriesController : ApiController
    {
        // install nuget web api cross origin then go to webapiconfig.
        //   [DisableCors] //if you dont want to include this
        public IHttpActionResult GetEntries()
        {
            try
            {
                using (var context = new AppDbContext()) //using run then close thread
                {

                    var entries = context.Entries.ToList();
                    return Ok(entries);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        public IHttpActionResult PostEntry([FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                using (var context = new AppDbContext())
                {
                    context.Entries.Add(entry);
                    context.SaveChanges();
                    return Ok("Entry was created!");
                }

            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
