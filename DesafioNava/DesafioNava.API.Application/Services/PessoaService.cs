using DesafioNava.API.Application.Interfaces;
using DesafioNava.API.Domain.Model;
using System;

namespace DesafioNava.API.Application.Services
{
    public class PessoaService : IPessoaService
    {
        public Pessoa[] Get()
        {
            var result = new Pessoa[]{
            new Pessoa
            {
                Name = "João",
                LastName = "Silva",
                DocumentNumber = "123456789",
                Telephone = "987654321",
                DateBirthday = new DateTime(1990, 5, 15),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                Status = 1
            }
        };

            return result;
        }
    }

}