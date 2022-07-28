using ApiRestBooks.Utilities;

namespace ApiRestBooks.DTOs
{
    public class BookShowDTO : Response
    {
        public BookShowDTO(List<BookDataDTO> Data, int StatusCode, string Message, bool IsError, bool IsSucces)
        {
            this.Data = Data;
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.IsError = IsError;
            this.IsSuccess = IsSucces;
        }
        public List<BookDataDTO> Data { get; set; }
    }

    public class BookDataDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
