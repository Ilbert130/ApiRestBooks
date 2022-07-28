using ApiRestBooks.Configurations;
using ApiRestBooks.DTOs;
using ApiRestBooks.Models;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestGetBook()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookCreateDTO, Book>();
                cfg.CreateMap<Book, BookDataDTO>();
            });

            UnitOfWork book = new UnitOfWork(new Mapper(configuration));
            var response = book.Book.Get(1);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestGetListBook()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookCreateDTO, Book>();
                cfg.CreateMap<Book, BookDataDTO>();
            });

            UnitOfWork book = new UnitOfWork(new Mapper(configuration));
            var response = book.Book.Get();

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task TestPostBook()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookCreateDTO, Book>();
                cfg.CreateMap<Book, BookDataDTO>();
            });

            UnitOfWork book = new UnitOfWork(new Mapper(configuration));

            BookCreateDTO bookCreateDTO = new BookCreateDTO()
            {
                Title = "Ilbert",
                Description = "The best programer",
                PageCount = 4000,
                Excerpt = "string",
                PublishDate = Convert.ToDateTime("2022-04-02T09:18:13.667Z")
            };

            var response = await book.Book.Post(bookCreateDTO);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task TestPutBook()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookCreateDTO, Book>();
                cfg.CreateMap<Book, BookDataDTO>();
            });

            UnitOfWork book = new UnitOfWork(new Mapper(configuration));

            BookCreateDTO bookCreateDTO = new BookCreateDTO()
            {
                Title = "Ilbert",
                Description = "The best programer",
                PageCount = 4000,
                Excerpt = "string",
                PublishDate = Convert.ToDateTime("2022-04-02T09:18:13.667Z")
            };

            var response = await book.Book.Put(1, bookCreateDTO);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestDeleteBook()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookCreateDTO, Book>();
                cfg.CreateMap<Book, BookDataDTO>();
            });

            UnitOfWork book = new UnitOfWork(new Mapper(configuration));
            var response = book.Book.Delete(1);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }
    }
}