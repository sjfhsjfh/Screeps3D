﻿using System.Collections.Generic;
using UnityEngine;

namespace Screeps3D {
    
    /*{
        
        "body":[
            {
                "type":"work",
                "hits":100
            },
            {
                "type":"work",
                "hits":100
            },
            {
                "type":"carry",
                "hits":100
            },
            {
                "type":"carry",
                "hits":100
            },
            {
                "type":"move",
                "hits":100
            }
        ],
        "energy":0,
        "energyCapacity":100,
        "type":"creep",
        "room":"E2S7",
        "user":"5a0da017ab17fd00012bf0e7",
        "hits":500,
        "hitsMax":500,
        "spawning":false,
        "fatigue":0,
        "notifyWhenAttacked":true,
        "ageTime":8598,
        "actionLog":{
            "attacked":null,
            "healed":null,
            "attack":null,
            "rangedAttack":null,
            "rangedMassAttack":null,
            "rangedHeal":null,
            "harvest":null,
            "heal":null,
            "repair":null,
            "build":null,
            "say":null,
            "upgradeController":null,
            "reserveController":null
        }
    }*/
    
    internal class Creep : RoomObject, IEnergyObject {
        
        public string UserId { get; private set; }
        public CreepBody Body { get; private set; }
        public string Name { get; private set; }
        public Dictionary<string, JSONObject> Actions { get; private set; }
        public float Energy { get; set; }
        public float EnergyCapacity { get; set; }

        internal Creep() {
            Body = new CreepBody();
            Actions = new Dictionary<string, JSONObject>();
        }

        internal override void Unpack(JSONObject data) {
            base.Unpack(data);
            var name = data["name"];
            if (name != null)
            {
                Name = name.str;
            }

            var userObj = data["user"];
            if (userObj != null) {
                UserId = userObj.str;
            }
            
            var actionObj = data["actionLog"];
            if (actionObj != null) {
                foreach (var key in actionObj.keys) {
                    Actions[key] = actionObj[key];
                }
            }
            
            UnpackUtility.Energy(this, data);
            
            Body.Unpack(Data);
        }
    }
}