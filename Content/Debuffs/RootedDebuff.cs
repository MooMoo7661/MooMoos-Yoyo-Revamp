namespace CombinationsMod.Content.Debuffs
{
    public class RootedDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }
    }
}
