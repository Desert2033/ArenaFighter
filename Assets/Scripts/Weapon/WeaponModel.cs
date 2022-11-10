namespace Weapon
{
    public class WeaponModel
    {
        public float CoolDown { get; set; }

        public float CurrentCoolDown { get; set; }

        public WeaponModel(float coolDown)
        {
            CoolDown = coolDown;

            CurrentCoolDown = CoolDown;
        }

    }
}
