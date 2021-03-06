﻿using System;
 using FluentValidation;
using Superdigital.CoreShared.DomainObjects;
using Superdigital.CoreShared.ValueObjects;
using Superdigital.Domain.Entities.AggregateCliente;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Superdigital.Domain.Entities.AggregatePessoa
{
    public class Enderecos : Entity
    {
        public string Endereco { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public CepVo Cep { get; private set; }
        public UfVo Estado { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }
        public Guid ClienteId { get; private set; }


        // EF propriedades de navegacao
        public Cliente Cliente { get; private set; }

        public Enderecos(string endereco, string complemento, string bairro, string cidade, CepVo cep, UfVo estado, Guid clienteId)
        {
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Estado = estado;
            ClienteId = clienteId;
            Ativo = true;
        }

        internal ValidationResult ValidarEndereco()
        {
            return new EnderecoAplicavelValidation().Validate(this);
        }
    }

    internal class EnderecoAplicavelValidation : AbstractValidator<Enderecos>
    {
        public EnderecoAplicavelValidation()
        {
            RuleFor(e => e.Endereco)
                .NotEmpty().WithMessage("O Endereço precisa ser fornecido")
                .Length(2, 150).WithMessage("O Endereço precisa ter entre 2 e 150 caracteres");

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("O Bairro precisa ser fornecido")
                .Length(2, 100).WithMessage("O Bairro precisa ter entre 2 e 150 caracteres");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O Cidade precisa ser fornecido")
                .Length(2, 100).WithMessage("O Cidade precisa ter entre 2 e 150 caracteres");
            RuleFor(e => e.ClienteId)
                .Must(ValidadeClienteId)
                .WithMessage("Este  Id Cliente é inválido.");
            RuleFor(e => e.Cep)
                .Must(ValidadeCep)
                .WithMessage("Este Cep inválido.");

            RuleFor(e => e.Estado)
                .Must(ValidadeUf)
                .WithMessage("Este Estado inválido.");

        }

        private static bool ValidadeCep(CepVo cep)
        {
            return cep.Validar();
        }

        private static bool ValidadeUf(UfVo estado)
        {
            return estado.Validar();
        }
        private static bool ValidadeClienteId(Guid pessoaId)
        {
            return pessoaId.Equals(Guid.Empty);
        }

    }
}