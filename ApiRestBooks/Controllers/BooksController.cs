using ApiRestBooks.Configurations;
using ApiRestBooks.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiRestBooks.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<BookShowDTO> Get()
        {
            BookShowDTO response;

            try
            {
                return response = unitOfWork.Book.Get();
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, ex.Message, true, false);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<BookShowDTO> Get(int id)
        {
            BookShowDTO response;

            try
            {
                return response = unitOfWork.Book.Get(id);
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, ex.Message, true, false);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookShowDTO>> Post(BookCreateDTO bookCreateDTO)
        {
            BookShowDTO response;

            try
            {
                return response = await unitOfWork.Book.Post(bookCreateDTO);
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, ex.Message, true, false);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BookShowDTO>> Put(int id, BookCreateDTO bookCreateDTO)
        {
            BookShowDTO response;

            try
            {
                return response = await unitOfWork.Book.Put(id, bookCreateDTO);
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, ex.Message, true, false);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<BookShowDTO> Delete(int id)
        {
            BookShowDTO response;

            try
            {
                return response = unitOfWork.Book.Delete(id);
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, ex.Message, true, false);
            }
        }
    }
}
