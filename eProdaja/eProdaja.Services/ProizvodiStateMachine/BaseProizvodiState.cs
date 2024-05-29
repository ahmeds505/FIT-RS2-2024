﻿using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using eProdaja.Model;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class BaseProizvodiState
    {
        public EProdajaContext Context { get; set; }

        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public BaseProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = context;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }
        public virtual Model.Proizvodi Insert(ProizvodiInsert request)
        {
            throw new UserException("Metoda nije dozvoljena");
        }

        public virtual Model.Proizvodi Update(int id, ProizvodiUpdate request)
        {
            throw new UserException("Metoda nije dozvoljena");

        }

        public virtual Model.Proizvodi Activate(int id)
        {
            throw new UserException("Metoda nije dozvoljena");

        }

        public virtual Model.Proizvodi Hide(int id)
        {
            throw new UserException("Metoda nije dozvoljena");
        }

        public virtual Model.Proizvodi Edit(int id)
        {
            throw new UserException("Metoda nije dozvoljena");
        }

        public virtual List<string> AllowedActions(Database.Proizvodi entity) 
        {
            throw new UserException("Metoda nije dozvoljena");
        }

        public BaseProizvodiState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialProizvodiState>();
                case "draft":
                    return ServiceProvider.GetService<DraftProizvodiState>();
                case "active":
                    return ServiceProvider.GetService<ActiveProizvodiState>();
                case "hidden":
                    return ServiceProvider.GetService<HiddenProizvodiState>();

                default: throw new Exception("State not recognized");
            }
        }

    }
}
//initial, draft, active, hidden, active
