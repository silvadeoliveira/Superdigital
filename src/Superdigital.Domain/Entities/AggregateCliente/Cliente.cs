﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Superdigital.CoreShared.DomainObjects;
using Superdigital.CoreShared.Enum;
using Superdigital.CoreShared.ValueObjects;
using Superdigital.Domain.Entities.AggregatePessoa;

namespace Superdigital.Domain.Entities.AggregateCliente
{
    public class Cliente: Entity, IAggregateRoot
    {
        protected Cliente(bool ativo)
        {
            Ativo = ativo;
            _enderecosLista = new List<Enderecos>();
        }

        public Cliente(string nomePessoa, DateTime dtNascimento, string nomeMae, string nomePai, string nomeSocial, CpfCnpjVo cpf, EmailVo email, TipoCliente tipoCliente)
        {
            NomePessoa = nomePessoa;
            DtNascimento = dtNascimento;
            NomeMae = nomeMae;
            NomePai = nomePai;
            NomeSocial = nomeSocial;
            Cpf = cpf;
            Email = email;
            TipoCliente = tipoCliente;
            Ativo = true;
            DataCriacao = DateTime.Now;
            _enderecosLista = new List<Enderecos>();
        }
        public string NomePessoa { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public string NomeMae { get; private set; }
        public string NomePai { get; private set; }
        public string NomeSocial { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public CpfCnpjVo Cpf { get; private set; }
        public EmailVo Email { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IReadOnlyCollection<Enderecos> Enderecos => _enderecosLista;
        public bool Ativo { get; private set; }
         
        // EF propriedades de navegacao
        public IEnumerable<ContaCorrente> ContaCorrente { get; private set; }
        private readonly List<Enderecos> _enderecosLista;

        public ValidationResult AdicionarEndereco(Enderecos endereco)
        {
            var validationResult = endereco.ValidarEndereco();
            if (!validationResult.IsValid) return validationResult;
            if (ExistenteEndereco(endereco))
            {
                validationResult.Errors.Add(new ValidationFailure("Entity Endereco", "existe."));
            }

            _enderecosLista.Add(endereco);
            return validationResult;

        }

        public bool ExistenteEndereco(Enderecos endereco)
        {
            return _enderecosLista.Any(p => true);
        }

        public ValidationResult RemoverItem(Enderecos endereco)
        {
            var validationResult = endereco.ValidarEndereco();
            if (!validationResult.IsValid) return validationResult;

            var existente = Enderecos.FirstOrDefault(e => e.Id == endereco.Id);
            if (existente == null) validationResult.Errors.Add(new ValidationFailure("Entity Endereco", "O Endereço não Existe"));
            _enderecosLista.Remove(existente);
            return validationResult;
        }
    }
}