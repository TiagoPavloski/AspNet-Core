﻿using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;

        public CommandHandler(IUnitOfWork uow, IBus bus)
        {
            _uow = uow;
            _bus = bus;
        }
        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _bus.RaiseEvent();
            }
        }

        protected bool Commit()
        {
            var commandResponse = _uow.Commit();
            if (commandResponse.Success)
                return true;

            //Erro
            _bus.RaiseEvent();
            return false;
        }
    }
}
