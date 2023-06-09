using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Route("allDetails")]
    public IActionResult GetAllUserDetails()
    {
        var users = _dbContext.Users
            .Include(u => u.Reserves)
            .ThenInclude(r => r.Book)
            .ToList();

        var userDetailsList = users.Select(user =>
        {
            var lastReserve = user.Reserves.OrderByDescending(r => r.Reserved_At).FirstOrDefault();
            var reservesLastMonth = user.Reserves.Count(r => r.Reserved_At >= DateTime.Now.AddMonths(-1));

            return new
            {
                user.Name,
                user.Faculty,
                Date_Last_Reserve = lastReserve?.Reserved_At,
                Cant_Reserves_Last_Month = reservesLastMonth,
                Reserves = user.Reserves.Select(r => new
                {
                    r.Id,
                    r.Code,
                    r.Book.book,
                    r.Book.Description
                })
            };
        });

        return Ok(userDetailsList);
    }

    [HttpGet]
    [Route("booksWithReserves")]
    public IActionResult GetBooksWithReserves()
    {
        var books = _dbContext.Books
            .Include(b => b.Reserves)
            .ThenInclude(r => r.User)
            .ToList();

        var bookDetailsList = books.Select(book => new
        {
            book.book,
            book.Description,
            Reserves = book.Reserves.Select(r => new
            {
                r.Id,
                r.User.Name,
                r.User.Faculty
            })
        });

        return Ok(bookDetailsList);
    }
}
