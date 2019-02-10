using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Evento: Entity<Evento>
    {
        public Evento(string nome, DateTime dataInicio, DateTime dataFim, bool gratuito, decimal valor, bool online, string nomeDaEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            NomeDaEmpresa = nomeDaEmpresa;
        }


        public string Nome { get; private set; }

        public string DescricaoCurta { get; private set; }

        public string DescricaoLonga { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }

        public bool Gratuito { get; private set; }

        public decimal Valor { get; private set; }

        public bool Online { get; private set; }

        public string NomeDaEmpresa { get; private set; }

        public Categoria Categoria { get; private set; }

        public ICollection<Tags> Tags { get; private set; }

        public Endereco Endereco { get; private set; } 

        public Organizador Organizador { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidationResult = Validate(this);

        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do evento é obrigatório")
                .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(1, 50000)
                    .WithMessage("O valor deve estar entre 1 e 50000");

            if (Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(0, 0).When(e => e.Gratuito)
                    .WithMessage("Evento gratuito não deve ter valor");
        }

        #endregion
    }
}
 