#include "Enemy.h"
#include "PlayerManager.h"
#include <iostream>

Enemy::~Enemy()
{
}

void Enemy::initialize()
{
}

void Enemy::update()
{
	if (!isInteractable())
	{
		return;
	}
	if (mLife > 0)
	{
		if (!mCanAttack)
		{
			mCanAttack = true;
		}
		else
		{
			std::cout << getName() << std::endl;
			std::cout << getAttackStory() << std::endl;
			bool aVal = false;
			for (auto& iter : getConditionUpdateObjects())
			{
				if (iter->isInteractable())
				{
					iter->makeInteractable(aVal);
				}
				if (iter->isVisible())
				{
					iter->makeVisible(aVal);
				}
			}
			PlayerManager::instance().attackPlayer(this);
			mCanAttack = false;
		}
	}
}

void Enemy::attackEnemy(IInteractable* pWeapon)
{
	if (pWeapon != getConditionalObject() && !PlayerManager::instance().hasInInventory)
	{
		IInteractable::attackEnemy(pWeapon);
	}
	else
	{
		mLife -= 1;
		if (mLife <= 0)
		{
			enemyDeath();
		}
	}
}

void Enemy::blockAttack()
{
	if(PlayerManager::instance().hasShield() && mLife > 0)
	{
		std::cout << getName() << std::endl;
		std::cout << mBlockStory << std::endl;
		PlayerManager::instance().blockAttack();
	}
	else
	{
		IInteractable::blockAttack();
	}
}

void Enemy::enemyDeath()
{
	std::cout << getName() << std::endl;
	std::cout << getDeathStory() << std::endl;
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
	mCanAttack = false;
	makeInteractable(mCanAttack);
	makeVisible(mCanAttack);
}
