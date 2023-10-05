using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBookStore.Data;

namespace ODataBookStore.Controllers;

public class PressesControllers : ODataController
{
    private readonly BookStoreContext _db;

    public PressesControllers(BookStoreContext db)
    {
        _db = db;
        if (db.Books.Count() == 0)
        {
            foreach (var book in DataSource.GetBooks())
            {
                db.Books.Add(book);
                db.Presses.Add(book.Press);
            }

            db.SaveChanges();
        }
    }

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_db.Presses);
    }
}