﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonderland_Private_Server.Network;
using Wonderland_Private_Server.Code.Objects;
using Wonderland_Private_Server.Code.Enums;
using Wlo.Core;

namespace Wonderland_Private_Server.ActionCodes
{
    public class AC23 : AC
    {
        public override int ID { get { return 23; } }
        public override void ProcessPkt(ref Player r, RecvPacket p)
        {
            switch (p.B)
            {
                // case 1: Recv1(ref r, p); break;
                case 2: Recv2(ref r, p); break; // Get item ground
                case 3: Recv3(ref r, p); break; // drop item g round
                case 10: Recv10(ref r, p); break;//move item inv
                case 11: Recv11(ref r, p); break;//item selected to wear in inv
                case 12: Recv12(ref r, p); break; //item selected to remove
                case 15: Recv15(ref r, p); break; // OPen tent
                case 124: Recv124(ref r, p); break; //confirm destroy 
                default: Utilities.LogServices.Log("AC " + p.A + "," + p.B + " has not been coded"); break;
            }
        }
        void Recv1(ref Player p, RecvPacket r)
        {
            try
            {

            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv2(ref Player p, RecvPacket r)
        {
            try
            {
                byte pos = r.Unpack8();
                p.CurrentMap.PickUpItem(pos, ref p);
               
            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv3(ref Player p, RecvPacket r)
        {
            try
            {
                byte pos = r.Unpack8();
                byte qnt = r.Unpack8();
                byte ukn = r.Unpack8();
                var item = p.Inv[pos];

                if (item != null)
                {

                  if (item.Dropable)                    
                    {
                        cItem ret = null;                        
                            if ((ret = p.CurrentMap.DropItem(item, p)) != null)
                            {
                                item.CopyFrom(ret);
                                p.Inv.RemoveItem(pos, qnt);
                                // p.Inv.AddItem(item, pos, false);

                            }
                    }
                  else
                  {
                      // test need ASK destroy
                      SendPacket s = new SendPacket();
                      s.Pack(new byte[] { 23, 212, 255 });
                      s.Pack(pos);
                      s.Pack(item.ItemID);
                      s.Pack(qnt);
                      p.Send(s);

                  }
                }
            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv10(ref Player p, RecvPacket r) // move item inventory
        {
            try
            {
                byte src = r[2];
                byte ammt = r[3];
                byte dst = r[4];

                if (((src > 0) && (src < 51)) && ((dst > 0) && (dst < 51)) && ((ammt > 0) && (ammt < 51)))
                    p.Inv.MoveItem(src, dst, ammt);

            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv11(ref Player p, RecvPacket r)
        {
            try
            {
                
            byte loc = r[2];
            if ((loc > 0) && (loc < 51))
            {
                //TODO do any checks here to make sure we can wear item or in Equipment class
                p.WearEQ(loc);
            }

            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv12(ref Player p, RecvPacket r) //item selected to remove
        {
            try
            {
                byte loc = r[2];
                byte dst = r[3];
                if ((loc > 0) && (loc < 7) && (dst > 0) && (dst < 51))
                {
                    p.unWearEQ(loc, dst);
                }
            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv54(ref Player p, RecvPacket r)
        {
            try
            {
                
            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv15(ref Player p, RecvPacket r)
        {          
            try
            {               
                    byte pos = r.Unpack8();
                    if (p.Inv[pos].ItemID == 36002)
                    {
                        p.Tent.Open();
                    }                
            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
        void Recv124(ref Player p, RecvPacket r)
        {
            
            try
            {
                byte pos = r.Unpack8();
                byte qnt = r.Unpack8();
                byte ukn = r.Unpack8(); //??
                var item = p.Inv[pos];
                if (item != null)
                {
                    // test confirm destroy item
                    SendPacket s = new SendPacket();
                    s.Pack(new byte[] { 23, 26 });
                    s.Pack(item.ItemID);
                    s.Pack(qnt);
                    p.Send(s);
                    p.Inv.RemoveItem(pos, qnt);
                }

            }
            catch (Exception t) { Utilities.LogServices.Log(t); }
        }
    }
}