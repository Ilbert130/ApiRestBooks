using ApiRestBooks.DTOs;
using ApiRestBooks.Models;
using ApiRestBooks.Repositories.Interfaces;
using AutoMapper;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static ApiRestBooks.Utilities.ResponseMessageEnum;

namespace ApiRestBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMapper mapper;
        public BookRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public BookShowDTO Get()
        {
            BookShowDTO response;
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;
            List<Book> booksDeserialize;
            List<BookDataDTO> booksDataDTO;
            string result;

            try
            {
                httpClient = new HttpClient();
                httpResponseMessage = httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books").Result;

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, httpResponseMessage.RequestMessage.ToString(), true, false);
                }
                else
                {
                    result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    booksDeserialize = JsonConvert.DeserializeObject<List<Book>>(result);
                    booksDataDTO = mapper.Map<List<BookDataDTO>>(booksDeserialize);
                    return response = new BookShowDTO(booksDataDTO, (int)httpResponseMessage.StatusCode, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetSuccess), false, true);
                }
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.InternalServerError, ex.Message, true, false);
            }
        }

        public BookShowDTO Get(int id)
        {
            BookShowDTO response;
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;
            Book booksDeserialize;
            BookDataDTO booksDataDTO;
            string result;

            try
            {
                httpClient = new HttpClient();
                httpResponseMessage = httpClient.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}").Result;

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, httpResponseMessage.RequestMessage.ToString(), true, false);
                }
                else
                {
                    result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    booksDeserialize = JsonConvert.DeserializeObject<Book>(result);
                    booksDataDTO = mapper.Map<BookDataDTO>(booksDeserialize);
                    return response = new BookShowDTO(new List<BookDataDTO> { booksDataDTO }, (int)httpResponseMessage.StatusCode, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetSuccess), false, true);
                }
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.InternalServerError, ex.Message, true, false);
            }
        }

        public async Task<BookShowDTO> Post(BookCreateDTO bookCreateDTO)
        {
            BookShowDTO response;
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;
            Book bookSeserialize;
            StringContent data;
            string result;

            try
            {
                if (bookCreateDTO.Equals(null))
                {
                    return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetDataNull), true, false);
                }

                httpClient = new HttpClient();
                bookSeserialize = mapper.Map<Book>(bookCreateDTO);
                result = JsonConvert.SerializeObject(bookSeserialize);
                data = new StringContent(result, Encoding.UTF8, "application/json");
                httpResponseMessage = await httpClient.PostAsync("https://fakerestapi.azurewebsites.net/api/v1/Books", data);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, httpResponseMessage.RequestMessage.ToString(), true, false);
                }
                else
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetSuccess), false, true);
                }
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.InternalServerError, ex.Message, true, false);
            }
        }
        public async Task<BookShowDTO> Put(int id, BookCreateDTO bookCreateDTO)
        {
            BookShowDTO response;
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;
            Book bookSeserialize;
            StringContent data;
            string result;

            try
            {
                if (bookCreateDTO.Equals(null))
                {
                    return response = new BookShowDTO(null, (int)HttpStatusCode.BadRequest, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetDataNull), true, false);
                }

                httpClient = new HttpClient();
                bookSeserialize = mapper.Map<Book>(bookCreateDTO);
                result = JsonConvert.SerializeObject(bookSeserialize);
                data = new StringContent(result, Encoding.UTF8, "application/json");
                httpResponseMessage = await httpClient.PutAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}", data);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, httpResponseMessage.RequestMessage.ToString(), true, false);
                }
                else
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetSuccess), false, true);
                }
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.InternalServerError, ex.Message, true, false);
            }
        }

        public BookShowDTO Delete(int id)
        {
            BookShowDTO response;
            HttpClient httpClient;
            HttpResponseMessage httpResponseMessage;

            try
            {
                httpClient = new HttpClient();
                httpResponseMessage = httpClient.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}").Result;

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, httpResponseMessage.RequestMessage.ToString(), true, false);
                }
                else
                {
                    return response = new BookShowDTO(null, (int)httpResponseMessage.StatusCode, GetEnumMemberValue<ResponseMessageEnumBook>(ResponseMessageEnumBook.GetSuccess), false, true);
                }
            }
            catch (Exception ex)
            {
                return response = new BookShowDTO(null, (int)HttpStatusCode.InternalServerError, ex.Message, true, false);
            }
        }
    }
}
