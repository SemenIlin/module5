
namespace Module_5
{
    interface ITrap
    {
        void SetDamage(int damage);
        int GetDamage();

        void SetPositionX(int x);
        int GetPositionX();

        void SetPositionY(int y);
        int GetPositionY();

        void SetIsActiveTrap(bool active);
        bool GetIsActiveTrap();
    }
}
