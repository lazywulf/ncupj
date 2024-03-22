using UnityEngine;


namespace Utility
{
	public static class FireCal
	{
		public static void SpreadFire(IFireable fireable, Transform transform, PoolSystem pool, string bulletName, float initSpeed = 10f, int dmg = 1)
		{
			Bullet bullet;
			float angle = transform.eulerAngles.z + (fireable.FireArc / 2);
			float rotAngle = fireable.FireArc / (fireable.BulletQuantity * 3 - 1);

			for (int i = 0; i < fireable.BulletQuantity * 3; ++i, angle -= rotAngle)
			{
				bullet = pool.Get(bulletName).Prepare(transform).GetComponent<Bullet>();
				bullet.Rotation = angle;
				bullet.Speed = new Vector2(0f, initSpeed);
				bullet.damage = dmg;
				MoveCal.RandAngle(bullet, fireable.AngleVar);
				MoveCal.RandSpeed(bullet, fireable.SpeedVar);
				MoveCal.AlignSpeedWithRotation(bullet);
			}
		}

		public static void DefaultFire(IFireable fireable, Transform transform, PoolSystem pool, string bulletName, float initSpeed = 10f, int dmg = 1)
		{
			Bullet bullet;
			bullet = pool.Get(bulletName).Prepare(transform).GetComponent<Bullet>();
			bullet.Speed = new Vector2(0f, initSpeed);
			bullet.damage = dmg;
		}
	}
}
