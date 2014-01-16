﻿using MvvmLight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight.Design {

    public class DesignServiceClient : IServiceClient {

        public Client Charger() {

            return new Client { Prenom = "Nico", Age = 30, EstBonClient = true };
        }

        public List<Client> ChargerTout() {

            return new List<Client> {

                new Client { Age = 30, EstBonClient = true, Prenom = "Nico"},
                new Client { Age = 20, EstBonClient = false, Prenom = "Jérémie"},
                new Client { Age = 30, EstBonClient = true, Prenom = "Delphine"}
            };
        }
    }
}
