using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an goblin corpse" )]
	public class EnslavedGreenGoblin : BaseCreature
	{
		//public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public EnslavedGreenGoblin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Enslaved Green Goblin";
			Body = 334;
			BaseSoundID = 0x45A;

			SetStr( 326, 326 );
			SetDex( 71, 71 );
			SetInt( 126, 126 );

			SetHits( 184, 184 );
			SetStam( 71, 71 );
			SetMana( 126, 126 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 40 );
			SetResistance( ResistanceType.Fire, 38, 39 );
			SetResistance( ResistanceType.Cold, 31, 32 );
			SetResistance( ResistanceType.Poison, 12, 12 );
			SetResistance( ResistanceType.Energy, 10, 11 );

			SetSkill( SkillName.MagicResist, 121.6, 122.9 );
			SetSkill( SkillName.Tactics, 80.0, 81.2 );
			SetSkill( SkillName.Anatomy, 82.0, 83.4 );
			SetSkill( SkillName.Wrestling, 99.2, 99.4 );


			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

			// Loot - 30-40gold, magicitem,gem,goblin blood, essence control
			switch ( Utility.Random( 20 ) )
			{
				case 0: PackItem( new Scimitar() ); break;
				case 1: PackItem( new Katana() ); break;
				case 2: PackItem( new WarMace() ); break;
				case 3: PackItem( new WarHammer() ); break;
				case 4: PackItem( new Kryss() ); break;
				case 5: PackItem( new Pitchfork() ); break;
			}

			PackItem( new ThighBoots() );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new BolaBall() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		//public override bool IsEnemy( Mobile m )
		//{
		//	if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
		//		return false;

		//	return base.IsEnemy( m );
		//}

		//public override void AggressiveAction( Mobile aggressor, bool criminal )
		//{
			//base.AggressiveAction( aggressor, criminal );

			//Item item = aggressor.FindItemOnLayer( Layer.Helm );

			//if ( item is OrcishKinMask )
			//{
			//	AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
			//	item.Delete();
			//	aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
			//	aggressor.PlaySound( 0x307 );
			//}
		//}

		public EnslavedGreenGoblin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
