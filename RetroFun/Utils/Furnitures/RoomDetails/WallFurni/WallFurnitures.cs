﻿using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroFun.Utils.Furnitures.FloorFurni
{
    public class WallFurnitures
    {
        public static List<HWallItem> Furni = new List<HWallItem>();
        public static List<HWallItem> Snapshot_Wall_furnis_In_room = new List<HWallItem>();

        public static List<HWallItem> GetWallFurnis()
        {
            return Furni;
        }

        public static void SetSnapshotWall()
        {
            Snapshot_Wall_furnis_In_room = GetWallFurnis();
        }

        public static List<HWallItem> Getsnapshot()
        {
            SetSnapshotWall();
            return Snapshot_Wall_furnis_In_room;
        }

        public static HMessage PacketBuilder(IList<HWallItem> items, ushort header)
        {
            var itemsMessage = new HMessage(header);
            var owners = items.GroupBy(i => i.OwnerId).Select(g => g.First());

            itemsMessage.WriteInteger(owners.Count());
            foreach (var owner in owners)
            {
                itemsMessage.WriteInteger(owner.OwnerId);
                itemsMessage.WriteString(owner.OwnerName);
            }

            itemsMessage.WriteInteger(items.Count);
            foreach (var obj in items)
            {


                itemsMessage.WriteString(obj.Id.ToString());
                itemsMessage.WriteInteger(obj.TypeId);
                itemsMessage.WriteString(obj.Location);
                itemsMessage.WriteString(obj.State);
                itemsMessage.WriteInteger(obj.SecondsToExpiration);
                itemsMessage.WriteInteger((int)obj.UsagePolicy);
                itemsMessage.WriteInteger(obj.OwnerId);
            }
            return itemsMessage;

        }

        public static List<HWallItem> BobbaParser(HMessage packet)
        {
            int ownersCount = packet.ReadInteger();
            for (int i = 0; i < ownersCount; i++)
            {
                packet.ReadInteger();
                packet.ReadString();
            }

            var wallItems = new HWallItem[packet.ReadInteger()];
            for (int i = 0; i < wallItems.Length; i++)
            {
                wallItems[i] = new HWallItem(packet);
            }
            return wallItems.ToList();
        }




    }
}
