using System;
using Server.Items;

namespace Server.Items
{
	public class MagicalRelic : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public MagicalRelic() : this( 1 )
		{
		}

		[Constructable]
		public MagicalRelic( int amount ) : base( 0x2DB3 )
		{
			Name = "magical relic";
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
			ItemValue = ItemValue.Legendary;
		}

		public MagicalRelic( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}